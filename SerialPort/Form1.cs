using System;
using System.Management;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Windows;
using System.Text.RegularExpressions;
using System.Drawing;

namespace SerialPort
{
    public partial class Form1 : Form
    {
        int completeDevice = 0;

        // Follow arrays are used to hold the property of every line in richBoxText1. 
        // If want to change property of a line, set the arrays first and then call showMsgToRichTextBox().
        HorizontalAlignment[] richTextBoxAlignment = { HorizontalAlignment.Center, HorizontalAlignment.Center, HorizontalAlignment.Left };
        int[] richTextBoxFontSize = { 12, 20, 8 };
        Color[] richTextBoxColor = { Color.Black, Color.Red, Color.Orange };

        // sport will be null when declared
        public System.IO.Ports.SerialPort dutPort;
        public System.IO.Ports.SerialPort refPort;

        // 0: didn't receive, 1: received with success, 2: received with error
        Int16 isDUTReceivedTxTestEvt = 0;
        Int16 isDUTReceivedRxTestEvt = 0;
        Int16 isDUTReceivedTestEndEvt = 0;

        Int16 isREFReceivedTxTestEvt = 0;
        Int16 isREFReceivedRxTestEvt = 0;
        Int16 isREFReceivedTestEndEvt = 0;

        Int32 DUTreceivedPacketsNum = 0;
        Int32 REFreceivedPacketsNum = 0;

        private delegate void SetTextCallback(string text);
        private delegate void SetRichTextCallback(String text, int line);

        public Form1()
        {
            InitializeComponent();
            initAdvancedPanel();
            advancedPanel.Visible = false;
            showMsgToRichTextBox("Complete devices: " + completeDevice, 0);
        }

        private void initEvtReceivedFlags()
        {
            isDUTReceivedTxTestEvt = 0;
            isDUTReceivedRxTestEvt = 0;
            isDUTReceivedTestEndEvt = 0;
            isREFReceivedTxTestEvt = 0;
            isREFReceivedRxTestEvt = 0;
            isREFReceivedTestEndEvt = 0;
            DUTreceivedPacketsNum = 0;
            REFreceivedPacketsNum = 0;
        }

        private void showMsgToTextBox(string text)
        {
            this.txtReceive.AppendText(text + Environment.NewLine + Environment.NewLine);
        }

        private void showMsgToRichTextBox(String text, int line)
        {
            richTextBox1.DeselectAll();

            while (richTextBox1.Lines.Length <= line)
            {
                // if current lines are not enough, insert line. Otherwise it will crash.
                richTextBox1.AppendText("\n");
            }

            String[] lines = richTextBox1.Lines;
            lines[line] = text;
            richTextBox1.Lines = lines;

            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                int start = richTextBox1.GetFirstCharIndexFromLine(i);
                int length = richTextBox1.Lines[i].Length;
                richTextBox1.Select(start, length);

                richTextBox1.SelectionColor = richTextBoxColor[i];
                richTextBox1.SelectionAlignment = richTextBoxAlignment[i];
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectedText, richTextBoxFontSize[i]);
            }
        }
        
        private List<string> autoGetSerialPort()
        {
            List<string> comports = new List<string>();

            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (queryObj["Caption"].ToString().Contains("(COM"))
                    {
                        comports.Add(queryObj["Caption"].ToString());
                    }
                }
            }
            catch (ManagementException)
            {
                MessageBox.Show("Failed to autodetect serial port.", "Error");
            }

            return comports;
        }

        // Automatically detect com port if not selected. When advanced penal is disabled, this function will be used.
        private bool autoDetectAndConnectPort(string deviceSignature, ref System.IO.Ports.SerialPort sportobject)
        {
            bool returnStatus = false;   //set to unsuccess first
            List<string> comports = autoGetSerialPort();
            String portName;

            int baudrate = 115200;
            Parity parity = (Parity)Enum.Parse(typeof(Parity), "None");
            int databits = 8;
            StopBits stopbits = (StopBits)Enum.Parse(typeof(StopBits), "One");

            foreach (string description in comports)
            {
                string portNamePattern = "(COM[0-9])";
                Match portNameMatch = Regex.Match(description, portNamePattern, RegexOptions.IgnoreCase);
                Match descriptionMatch = Regex.Match(description, deviceSignature, RegexOptions.IgnoreCase);

                if (descriptionMatch.Success == true)
                {
                    portName = portNameMatch.Groups[1].ToString();
                    returnStatus = serialPortConnect(portName, baudrate, parity, databits, stopbits, ref sportobject);
                    break;
                }
            }

            return returnStatus;
        }
        
        private void initAdvancedPanel()
        {
            disconnectButton.Enabled = false;
            sendButton.Enabled = false;

            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
            {
                comboBoxDUTPort.Items.Add(s);
                comboBoxREFPort.Items.Add(s);
            }

            // add selection items for buad rate
            comboBoxBaudrate.Items.Add("115200");
            comboBoxBaudrate.Items.Add("3000000");

            // set default Serial Port configuration
            comboBoxBaudrate.Text = "115200";
        }

        public void StartProc(string exePath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = exePath;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            Process.Start(startInfo);
        }

        // Event handler that will be called when Serial Port receving data. Will check sender to determine if DUT or REF send this event.
        private void serialPortDataReceived(object sender, SerialDataReceivedEventArgs e) 
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            // determine the sender is DUT or REF 
            String portname = getPortNameFromSenderOrPortObject(sender);
            System.IO.Ports.SerialPort sport = getPortObjectFromSender(sender);

            // use List class to store variable length bytes data.
            List<byte> bytesReceived = new List<byte>();
            int dataLen = sport.BytesToRead;

            while (dataLen-- > 0) 
            {
                bytesReceived.Add(Convert.ToByte(sport.ReadByte()));
            }
            byte[] bytesReceivedArray = bytesReceived.ToArray();

            // check if we received targeted HCI events, and set flags to inform StartButton thread, so that we know the test result.
            checkReceivedEventAndSetFlags(sender, bytesReceivedArray);

            // convert byte list to byte array, then to string.
            String ReceivedHexStr = BitConverter.ToString(bytesReceivedArray);
            // add "[time] Received" to string
            ReceivedHexStr = "[" + dtn + "] " + portname + " Received" + Environment.NewLine + ReceivedHexStr;

            // invoke UI thread to show received data on txtReceive. Use delegate.
            txtReceive.BeginInvoke(new SetTextCallback(showMsgToTextBox), ReceivedHexStr);
        }

        // Called by Send Button Event Handler. Will send hci cmd to both DUT and REF.
        private void serialPortSendHCICommand(byte[] bytesToSend, int len, String hciCmdName, System.IO.Ports.SerialPort sport)
        {
            if (sport != null && sport.IsOpen == true)
            {
                DateTime dt = DateTime.Now;
                String dtn = dt.ToShortTimeString();
                String portname = getPortNameFromSenderOrPortObject(sport);

                try
                {
                    // send hex array. ex 0x01, 0x31, 0xf3, 0x01, 0x16
                    sport.Write(bytesToSend, 0, len);
                }
                catch(Exception)
                {
                    MessageBox.Show("Failed to write to serial port.", "Error");
                }

                // convert hex array to string. ex. convert hex bytes array {0x01, 0x31, 0xf3, 0x01, 0x16} to string 01-31-fe-01-16
                String bytesToSendHexString = BitConverter.ToString(bytesToSend);

                // show hex format string to log window.
                String ReceivedHexStr = "[" + dtn + "] " + "Sent Command   <<< " + hciCmdName + " >>>  to " + portname +
                    Environment.NewLine + bytesToSendHexString;
                txtReceive.BeginInvoke(new SetTextCallback(showMsgToTextBox), ReceivedHexStr);
            }
        }
        
        // called by event handler to check the sender is dutPort or refPort, and return "DUT" or "REF".
        public String getPortNameFromSenderOrPortObject(object sender)
        {
            String portname = null;

            if (sender == dutPort)
                portname = "DUT";
            else if (sender == refPort)
                portname = "REF";

            return portname;
        }

        // called by event handler to check the sender is dutPort or refPort, and return dutPort or refPort.
        public System.IO.Ports.SerialPort getPortObjectFromSender(object sender)
        {
            System.IO.Ports.SerialPort sport = null;

            if (sender == dutPort)
                sport = dutPort;
            else if (sender == refPort)
                sport = refPort;

            return sport;
        }

        public bool serialPortConnect(String com, int baudrate , Parity parity, int databits, StopBits stopbits, ref System.IO.Ports.SerialPort sportobject) 
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();
            String portname = getPortNameFromSenderOrPortObject(sportobject);

            try
            {
                sportobject = new System.IO.Ports.SerialPort(com, baudrate, parity, databits, stopbits);
                sportobject.Open();
                disconnectButton.Enabled = true;
                connectButton.Enabled = false;
                sendButton.Enabled = true;
                txtReceive.AppendText("[" + dtn + "] " + portname + " is Connected\n");
                txtReceive.AppendText("\n");

                // add event hander to sportobject. this will change the content of the object, that's why we use "ref" keyword.
                sportobject.DataReceived += new SerialDataReceivedEventHandler(serialPortDataReceived);

                return true;
            }
            catch (Exception) { 
                MessageBox.Show("Failed to onnect to serial port.", "Error");
                return false; 
            }
        }

        // Check if we received targeted HCI events, and set flags to inform StartButton thread, so that we know the test result.
        private void checkReceivedEventAndSetFlags(object receivedPort, byte[] eventBytes)
        {
            if (eventBytes.Length < 7 || eventBytes[0] != 0x04 || eventBytes[1] != 0x0e || eventBytes[3] != 0x00)
            {
                // not a valid hci event packet. do nothing for now.
                return;
            }

            byte length = eventBytes[2];
            byte status = eventBytes[6];

            // 0: didn't receive, 1: received with success, 2: received with error
            Int16 flagValue = 1;

            // check for HCI_LE_Transmitter_Test: 0x201e.
            if (eventBytes[4] == 0x1e && eventBytes[5] == 0x20)
            {
                if (length != 0x04 || status != 0x00 || eventBytes.Length != 7)
                    flagValue = 2;

                if (receivedPort == dutPort)
                    isDUTReceivedTxTestEvt = flagValue;
                else if (receivedPort == refPort)
                    isREFReceivedTxTestEvt = flagValue;
            }
            // check for HCI_LE_Receiver_Test: 0x201d
            else if (eventBytes[4] == 0x1d && eventBytes[5] == 0x20)
            {
                if (length != 0x04 || status != 0x00 || eventBytes.Length != 7)
                    flagValue = 2;

                if (receivedPort == dutPort)
                    isDUTReceivedRxTestEvt = flagValue;
                else if (receivedPort == refPort)
                    isREFReceivedRxTestEvt = flagValue;
            }
            // check for HCI_Test_End: 0x201f
            else if (eventBytes[4] == 0x1f && eventBytes[5] == 0x20)
            {
                if (length != 0x06 || status != 0x00 || eventBytes.Length != 9)
                    flagValue = 2;

                if (receivedPort == dutPort)
                {
                    isDUTReceivedTestEndEvt = flagValue;
                    DUTreceivedPacketsNum = (Int32)eventBytes[7] + ((Int32)eventBytes[8] << 8);
                }
                else if (receivedPort == refPort)
                {
                    isREFReceivedTestEndEvt = flagValue;
                    REFreceivedPacketsNum = (Int32)eventBytes[7] + ((Int32)eventBytes[8] << 8);
                }
            }
        }

        private void testThreadMain()
        {
            // LE Transmitter Test: channel 37, byte length 1, pattern 10101010
            byte[] HCIHCI_LE_Transmitter_Test = { 0x01, 0x1E, 0x20, 0x03, 0x25, 0x01, 0x02 };
            // HCI_LE_Receiver_Test: channel 37
            byte[] HCI_LE_Receiver_Test = { 0x01, 0x1D, 0x20, 0x01, 0x25 };
            // HCI_LE_Test_End
            byte[] HCI_LE_Test_End = { 0x01, 0x1F, 0x20, 0x00 };

            bool testresult = true;

            richTextBoxColor[1] = Color.Blue;
            richTextBox1.BeginInvoke(new SetRichTextCallback(showMsgToRichTextBox), new object[] { "Test in progress...", 1 });

            ///////////////////////////////////////////////// DUT Tx & REF Rx /////////////////////////////////////////////////////

            initEvtReceivedFlags();

            serialPortSendHCICommand(HCI_LE_Receiver_Test, HCI_LE_Receiver_Test.Length, "HCI_LE_Receiver_Test", refPort);
            serialPortSendHCICommand(HCIHCI_LE_Transmitter_Test, HCIHCI_LE_Transmitter_Test.Length, "HCIHCI_LE_Transmitter_Test", dutPort);
            // sleep for 1 sec
            Thread.Sleep(1000);
            serialPortSendHCICommand(HCI_LE_Test_End, HCI_LE_Test_End.Length, "HCI_LE_Test_End", dutPort);
            serialPortSendHCICommand(HCI_LE_Test_End, HCI_LE_Test_End.Length, "HCI_LE_Test_End", refPort);

            // sleep for 1 sec to wait for all events.
            Thread.Sleep(1000);

            if (isDUTReceivedTxTestEvt == 1 && isREFReceivedRxTestEvt == 1 && isDUTReceivedTestEndEvt == 1 && isREFReceivedTestEndEvt == 1)
            {
                txtReceive.BeginInvoke(new SetTextCallback(showMsgToTextBox), "===================================================");
                txtReceive.BeginInvoke(new SetTextCallback(showMsgToTextBox), "REF Received " + REFreceivedPacketsNum + " Packets");
                txtReceive.BeginInvoke(new SetTextCallback(showMsgToTextBox), "===================================================");

                if (REFreceivedPacketsNum < 1500)
                    testresult = false;
            }
            else
            {
                testresult = false;
            }

            ///////////////////////////////////////////////// REF Tx & DUT Rx /////////////////////////////////////////////////////

            initEvtReceivedFlags();

            serialPortSendHCICommand(HCI_LE_Receiver_Test, HCI_LE_Receiver_Test.Length, "HCI_LE_Receiver_Test", dutPort);
            serialPortSendHCICommand(HCIHCI_LE_Transmitter_Test, HCIHCI_LE_Transmitter_Test.Length, "HCIHCI_LE_Transmitter_Test", refPort);
            // sleep for 1 sec
            Thread.Sleep(1000);
            serialPortSendHCICommand(HCI_LE_Test_End, HCI_LE_Test_End.Length, "HCI_LE_Test_End", refPort);
            serialPortSendHCICommand(HCI_LE_Test_End, HCI_LE_Test_End.Length, "HCI_LE_Test_End", dutPort);

            // sleep for 2 sec to wait for all events.
            Thread.Sleep(1000);

            if (isREFReceivedTxTestEvt == 1 && isDUTReceivedRxTestEvt == 1 && isDUTReceivedTestEndEvt == 1 && isREFReceivedTestEndEvt == 1)
            {
                txtReceive.BeginInvoke(new SetTextCallback(showMsgToTextBox), "===================================================");
                txtReceive.BeginInvoke(new SetTextCallback(showMsgToTextBox), "DUT Received " + DUTreceivedPacketsNum + " Packets");
                txtReceive.BeginInvoke(new SetTextCallback(showMsgToTextBox), "===================================================");

                if (DUTreceivedPacketsNum < 1500)
                    testresult = false;
            }
            else
            {
                testresult = false;
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (testresult == true)
            {
                txtReceive.BeginInvoke(new SetTextCallback(showMsgToTextBox), "Test Passed!");
                richTextBoxColor[1] = Color.Green;
                richTextBox1.BeginInvoke(new SetRichTextCallback(showMsgToRichTextBox), new object[] { "Test Passed!", 1 });
                completeDevice++;
                richTextBox1.BeginInvoke(new SetRichTextCallback(showMsgToRichTextBox), new object[] { "Complete devices: " + completeDevice, 0 });
            }
            else
            {
                txtReceive.BeginInvoke(new SetTextCallback(showMsgToTextBox), "Test Failed!");
                richTextBoxColor[1] = Color.Red;
                richTextBox1.BeginInvoke(new SetRichTextCallback(showMsgToRichTextBox), new object[] { "Test Failed!", 1 });
                completeDevice++;
                richTextBox1.BeginInvoke(new SetRichTextCallback(showMsgToRichTextBox), new object[] { "Complete devices: " + completeDevice, 0 });
            }

            // initialize all flags
            initEvtReceivedFlags();

            try
            {
                // Close comport here because worker could disconnect the devices. When test button is pressed next time, we will detect and connect again.
                if (dutPort != null)
                    dutPort.Close();

                if (refPort != null)
                    refPort.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Failed to close serial port.", "Error");
            }
        }

        // Start Test Button
        private void startTestButton_Click(object sender, EventArgs e)
        {
            bool dutDetected = true;
            bool refDetected = true;

            // make sure sport is already assigned a value by serialPortConnect method.
            if (dutPort == null || !dutPort.IsOpen)
            {
                dutDetected = autoDetectAndConnectPort("COM4", ref dutPort);
            }

            if (refPort == null || !refPort.IsOpen)
            {
                refDetected = autoDetectAndConnectPort("COM9", ref refPort);
            }

            if (!dutDetected || !refDetected)
            {
                richTextBoxColor[1] = Color.Red;
                richTextBox1.BeginInvoke(new SetRichTextCallback(showMsgToRichTextBox), new object[] { "Cannot connect to devices!", 1 });
                return;
            }

            System.Threading.Thread startButtonThread = new System.Threading.Thread(new System.Threading.ThreadStart(testThreadMain));
            startButtonThread.Start();
        }

        private void startBurnButton_Click(object sender, EventArgs e)
        {
            startBurnButton.Enabled = false;
            StartProc("C:\\Program Files (x86)\\Texas Instruments\\SmartRF Tools\\Flash Programmer\\bin\\SmartRFProg.exe");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                advancedPanel.Visible = true;
            else
                advancedPanel.Visible = false;
        }
        
        // Connect Button. Will connect both DUT and REF.
        private void connectButton_Click(object sender, EventArgs e)
        {
            String dutComName = comboBoxDUTPort.Text;
            String refComName = comboBoxREFPort.Text;

            // if port is not selected
            if (dutComName == "" || refComName == "")
                return;

            int baudrate = Convert.ToInt32(comboBoxBaudrate.Text);
            Parity parity = (Parity)Enum.Parse(typeof(Parity), "None");
            int databits = 8;
            StopBits stopbits = (StopBits)Enum.Parse(typeof(StopBits), "One");

            // connect DUT
            serialPortConnect(dutComName, baudrate, parity, databits, stopbits, ref dutPort);
            // connect REF
            serialPortConnect(refComName, baudrate, parity, databits, stopbits, ref refPort);
        }
        
        // Send Button. Send msg to both REF and DUT.
        private void sendButton_Click(object sender, EventArgs e)
        {
            // make sure sport is already assigned a value by serialPortConnect method.
            if (refPort == null || dutPort == null || txtDatatoSend.Text.Trim() == "")
                return;

            // get text on send box, and then split input text into byte array. Trim() will remove start and end space.
            String inputText = txtDatatoSend.Text.Trim();
            byte[] bytesToSend = inputText.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray();

            // call serialPortSendHCICommand() to send out
            serialPortSendHCICommand(bytesToSend, bytesToSend.Length, "Test Command", dutPort);
            serialPortSendHCICommand(bytesToSend, bytesToSend.Length, "Test Command", refPort);
        }

        // Disconnect Button. Disconnect both DUT and REF.
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            if (dutPort.IsOpen) 
            {
                dutPort.Close();
                txtReceive.AppendText("[" + dtn + "] " + "DUT is Disconnected\n");
                txtReceive.AppendText("\n");
            }

            if (refPort.IsOpen)
            {
                refPort.Close();
                txtReceive.AppendText("[" + dtn + "] " + "REF is Disconnected\n");
                txtReceive.AppendText("\n");
            }

            disconnectButton.Enabled = false;
            connectButton.Enabled = true;
            sendButton.Enabled = false;
        }
    }
}
