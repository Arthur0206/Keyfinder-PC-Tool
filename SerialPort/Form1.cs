using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Windows;

namespace SerialPort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            disconnectButton.Enabled = false;
            startBurnButton.Enabled = false;
            startTestButton.Enabled = false;
            sendButton.Enabled = false;

            foreach (String s in System.IO.Ports.SerialPort.GetPortNames()) 
            {
                DUTPort.Items.Add(s);
                REFPort.Items.Add(s);
            }

            // add selection items for buad rate
            cmbbaudrate.Items.Add("115200");
            cmbbaudrate.Items.Add("3000000");

            // set default Serial Port configuration
            cmbbaudrate.Text = "115200";
        }

        // sport will be null when declared
        public System.IO.Ports.SerialPort dutPort;
        public System.IO.Ports.SerialPort refPort;

        // called by event handler to check the sender is dutPort or refPort, and return "DUT" or "REF".
        public String getPortNameFromSenderOrPortObject(object sender)
        {
            String portname = null;

            if (sender == dutPort)
            {
                portname = "DUT";
            }
            else if (sender == refPort)
            {
                portname = "REF";
            }

            return portname;
        }

        // called by event handler to check the sender is dutPort or refPort, and return dutPort or refPort.
        public System.IO.Ports.SerialPort getPortObjectFromSender(object sender)
        {
            System.IO.Ports.SerialPort sport = null;

            if (sender == dutPort)
            {
                sport = dutPort;
            }
            else if (sender == refPort)
            {
                sport = refPort;
            }

            return sport;
        }

        public void serialport_connect(String com, int baudrate , Parity parity, int databits, StopBits stopbits, ref System.IO.Ports.SerialPort sportobject) 
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();
            String portname = getPortNameFromSenderOrPortObject(sportobject);

            sportobject = new System.IO.Ports.SerialPort(
            com, baudrate, parity, databits, stopbits);

            try
            {
                sportobject.Open();
                disconnectButton.Enabled = true;
                connectButton.Enabled = false;
                startBurnButton.Enabled = true;
                startTestButton.Enabled = true;
                sendButton.Enabled = true;
                txtReceive.AppendText("[" + dtn + "] " + portname + " is Connected\n");
                txtReceive.AppendText("\n");

                // add event hander to sportobject. this will change the content of the object, that's why we use "ref" keyword.
                sportobject.DataReceived += new SerialDataReceivedEventHandler(sport_DataReceived);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error"); }
        }

        // Connect Button. Will connect both DUT and REF.
        private void connectButton_Click(object sender, EventArgs e)
        {
            String DUT_com = DUTPort.Text;
            String REF_com = REFPort.Text;

            // if port is not selected
            if (DUT_com == "" || REF_com == "")
                return;

            int baudrate = Convert.ToInt32(cmbbaudrate.Text);
            Parity parity = (Parity)Enum.Parse(typeof(Parity), "None");
            int databits = 8;
            StopBits stopbits = (StopBits)Enum.Parse(typeof(StopBits), "One");

            // connect DUT
            serialport_connect(DUT_com, baudrate, parity, databits, stopbits, ref dutPort);
            // connect REF
            serialport_connect(REF_com, baudrate, parity, databits, stopbits, ref refPort);
        }

        private delegate void SetTextCallback(string text);

        private void showReceivedData(string text)
        {
            this.txtReceive.AppendText(text + Environment.NewLine + Environment.NewLine);
        }

        // Event handler that will be called when Serial Port receving data. Will check sender to determine if DUT or REF send this event.
        private void sport_DataReceived(object sender, SerialDataReceivedEventArgs e) 
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

            // convert byte list to byte array, then to string.
            String ReceivedHexStr = BitConverter.ToString(bytesReceived.ToArray());
            // add "[time] Received" to string
            ReceivedHexStr = "[" + dtn + "] " + portname + " Received" + Environment.NewLine + ReceivedHexStr;

            // invoke UI thread to show received data on txtReceive. Use delegate.
            txtReceive.BeginInvoke(new SetTextCallback(showReceivedData), ReceivedHexStr);
        }

        // Called by Send Button Event Handler. Will send hci cmd to both DUT and REF.
        private void sendHexArray(byte[] bytesToSend, int len, String hciCmdName, System.IO.Ports.SerialPort sport)
        {
            if (sport != null && sport.IsOpen == true)
            {
                DateTime dt = DateTime.Now;
                String dtn = dt.ToShortTimeString();
                String portname = getPortNameFromSenderOrPortObject(sport);

                // send hex array. ex 0x01, 0x31, 0xf3, 0x01, 0x16
                sport.Write(bytesToSend, 0, len);

                // convert hex array to string. ex. convert hex bytes array {0x01, 0x31, 0xf3, 0x01, 0x16} to string 01-31-fe-01-16
                String bytesToSendHexString = BitConverter.ToString(bytesToSend);

                // show hex format string to log window.
                String ReceivedHexStr = "[" + dtn + "] " + "Sent Command   <<< " + hciCmdName + " >>>  to " + portname +
                    Environment.NewLine + bytesToSendHexString;
                txtReceive.BeginInvoke(new SetTextCallback(showReceivedData), ReceivedHexStr);
            }
        }

        // Send Button. Send msg to both REF and DUT.
        private void sendButton_Click(object sender, EventArgs e)
        {
            // make sure sport is already assigned a value by serialport_connect method.
            if (refPort == null || dutPort == null || txtDatatoSend.Text.Trim() == "")
                return;

            // get text on send box, and then split input text into byte array. Trim() will remove start and end space.
            String inputText = txtDatatoSend.Text.Trim();
            byte[] bytesToSend = inputText.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray();

            // call sendHexArray() to send out
            sendHexArray(bytesToSend, bytesToSend.Length, "Test Command", dutPort);
            sendHexArray(bytesToSend, bytesToSend.Length, "Test Command", refPort);
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
            startBurnButton.Enabled = false;
            startTestButton.Enabled = false;
            sendButton.Enabled = false;
        }

        private void cmbbaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*
        // Event handler when 1 sec timer expired. Send out HCI test end command to both DUT and REF.
        public void oneSecTimerExpired(object sender, System.Timers.ElapsedEventArgs e)
        {
            // HCI_LE_Test_End
            byte[] HCI_LE_Test_End = { 0x01, 0x1F, 0x20, 0x00 };
            sendHexArray(HCI_LE_Test_End, HCI_LE_Test_End.Length, "HCI_LE_Test_End", dutPort);
            sendHexArray(HCI_LE_Test_End, HCI_LE_Test_End.Length, "HCI_LE_Test_End", refPort);
        }
        */

        private void startButtonThreadCallback()
        {
            // LE Transmitter Test: channel 37, byte length 1, pattern 10101010
            byte[] HCIHCI_LE_Transmitter_Test = { 0x01, 0x1E, 0x20, 0x03, 0x25, 0x01, 0x02 };
            // HCI_LE_Receiver_Test: channel 37
            byte[] HCI_LE_Receiver_Test = { 0x01, 0x1D, 0x20, 0x01, 0x25 };
            // HCI_LE_Test_End
            byte[] HCI_LE_Test_End = { 0x01, 0x1F, 0x20, 0x00 };

            /*
            // setup 1 sec timer.
            System.Timers.Timer t = new System.Timers.Timer(1000);
            t.Elapsed += new System.Timers.ElapsedEventHandler(oneSecTimerExpired);
            // do not repeat automatically.
            t.AutoReset = false; 
            // enable event handler.
            t.Enabled = true;
            */

            ///////////////////////////////////////////////// DUT Tx & REF Rx /////////////////////////////////////////////////////
            sendHexArray(HCI_LE_Receiver_Test, HCI_LE_Receiver_Test.Length, "HCI_LE_Receiver_Test", refPort);
            sendHexArray(HCIHCI_LE_Transmitter_Test, HCIHCI_LE_Transmitter_Test.Length, "HCIHCI_LE_Transmitter_Test", dutPort);
            // sleep for 1 sec
            Thread.Sleep(1000);
            sendHexArray(HCI_LE_Test_End, HCI_LE_Test_End.Length, "HCI_LE_Test_End", dutPort);
            sendHexArray(HCI_LE_Test_End, HCI_LE_Test_End.Length, "HCI_LE_Test_End", refPort);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////






 




            /*
            // send a serious of BT commands
            byte[] GAP_DeviceInit = {0x01, 0x00, 0xFE, 0x26, 0x08, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00 };
            sendHexArray(GAP_DeviceInit, 42, "GAP_DeviceInit", dutPort);
            Thread.Sleep(100);

            byte[] GAP_GetParam = { 0x01, 0x31, 0xFE, 0x01, 0x15 };
            sendHexArray(GAP_GetParam, 5, "GAP_GetParam", dutPort);
            Thread.Sleep(100);

            GAP_GetParam[4] = 0x16;
            sendHexArray(GAP_GetParam, 5, "GAP_GetParam", dutPort);
            Thread.Sleep(100);

            GAP_GetParam[4] = 0x1A;
            sendHexArray(GAP_GetParam, 5, "GAP_GetParam", dutPort);
            Thread.Sleep(100);

            GAP_GetParam[4] = 0x19;
            sendHexArray(GAP_GetParam, 5, "GAP_GetParam", dutPort);
            Thread.Sleep(100);
            */

        }

        // Start Test Button
        private void startTestButton_Click(object sender, EventArgs e)
        {
            // make sure sport is already assigned a value by serialport_connect method.
            if (dutPort == null)
                return;

            System.Threading.Thread startButtonThread = new System.Threading.Thread(new System.Threading.ThreadStart(startButtonThreadCallback));
            startButtonThread.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtReceive_TextChanged(object sender, EventArgs e)
        {

        }

        public void StartProc(string exePath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = exePath;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            Process.Start(startInfo);
        }

        private void startBurnButton_Click(object sender, EventArgs e)
        {
            startBurnButton.Enabled = false;
            StartProc("C:\\Program Files (x86)\\Texas Instruments\\SmartRF Tools\\Flash Programmer\\bin\\SmartRFProg.exe");
            // StartProc("%ProgramFiles%\\Texas Instruments\\SmartRF Tools\\Flash Programmer\\bin\\SmartRFProg.exe");
        }
    }
}
