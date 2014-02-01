using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace SerialPort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmdClose.Enabled = false;
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames()) 
            {
                txtPort.Items.Add(s);
            }

            // add selection items for buad rate
            cmbbaudrate.Items.Add("115200");
            cmbbaudrate.Items.Add("3000000");

            // set default Serial Port configuration
            cmbbaudrate.Text = "115200";
            cmbparity.Text = "None";
            cmbdatabits.Text = "8";
            cmbstopbits.Text = "One";
        }

        // sport will be null when declared
        public System.IO.Ports.SerialPort sport;

        public void serialport_connect(String port, int baudrate , Parity parity, int databits, StopBits stopbits) 
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            sport = new System.IO.Ports.SerialPort(
            port, baudrate, parity, databits, stopbits);

            try
            {
                sport.Open();
                cmdClose.Enabled = true;
                cmdConnect.Enabled = false;
                txtReceive.AppendText("[" + dtn + "] " + "Connected\n");
                txtReceive.AppendText("\n");
                sport.DataReceived += new SerialDataReceivedEventHandler(sport_DataReceived);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error"); }
        }

        // Connect Button
        private void cmdConnect_Click(object sender, EventArgs e)
        {
            String port = txtPort.Text;

            // if port is not selected
            if (port == "")
                return;

            int baudrate = Convert.ToInt32(cmbbaudrate.Text);
            Parity parity = (Parity)Enum.Parse(typeof(Parity), cmbparity.Text);
            int databits = Convert.ToInt32(cmbdatabits.Text);
            StopBits stopbits = (StopBits)Enum.Parse(typeof(StopBits), cmbstopbits.Text);

            serialport_connect(port, baudrate, parity, databits, stopbits);
        }

        private delegate void SetTextCallback(string text);

        private void showReceivedData(string text)
        {
            this.txtReceive.AppendText(text + Environment.NewLine + Environment.NewLine);
        }

        // Event handler that will be called when Serial Port receving data
        private void sport_DataReceived(object sender, SerialDataReceivedEventArgs e) 
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

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
            ReceivedHexStr = "[" + dtn + "] " + "Received" + Environment.NewLine + ReceivedHexStr;

            // invoke UI thread to show received data on txtReceive. Use delegate.
            txtReceive.BeginInvoke(new SetTextCallback(showReceivedData), ReceivedHexStr);
        }

        // Called by Send Button Event Handler
        private void sendHexArray(byte[] bytesToSend, int len, String hciCmdName)
        {
            if (sport != null && sport.IsOpen == true)
            {
                DateTime dt = DateTime.Now;
                String dtn = dt.ToShortTimeString();

                // send hex array. ex 0x01, 0x31, 0xf3, 0x01, 0x16
                sport.Write(bytesToSend, 0, len);

                // convert hex array to string. ex. convert hex bytes array {0x01, 0x31, 0xf3, 0x01, 0x16} to string 01-31-fe-01-16
                String bytesToSendHexString = BitConverter.ToString(bytesToSend);

                // show hex format string to log window.
                String ReceivedHexStr = "[" + dtn + "] " + "Sent Command   <<< " + hciCmdName + " >>>  " +
                    Environment.NewLine + bytesToSendHexString;
                txtReceive.BeginInvoke(new SetTextCallback(showReceivedData), ReceivedHexStr);
            }
        }

        // Send Button
        private void button1_Click(object sender, EventArgs e)
        {
            // make sure sport is already assigned a value by serialport_connect method.
            if (sport == null || txtDatatoSend.Text.Trim() == "")
                return;

            // get text on send box, and then split input text into byte array. Trim() will remove start and end space.
            String inputText = txtDatatoSend.Text.Trim();
            byte[] bytesToSend = inputText.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray();

            // call sendHexArray() to send out
            sendHexArray(bytesToSend, bytesToSend.Length, "Test Command");
        }

        // Disconnect Button
        private void cmdClose_Click_1(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            if (sport.IsOpen) 
            {
                sport.Close();
                cmdClose.Enabled = false;
                cmdConnect.Enabled = true;
                txtReceive.AppendText("[" + dtn + "] " + "Disconnected\n");
                txtReceive.AppendText("\n");
            }
        }

        private void cmbbaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void startButtonThreadCallback()
        {
            // send a serious of BT commands
            byte[] GAP_DeviceInit = {0x01, 0x00, 0xFE, 0x26, 0x08, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00 };
            sendHexArray(GAP_DeviceInit, 42, "GAP_DeviceInit");
            Thread.Sleep(100);

            byte[] GAP_GetParam = { 0x01, 0x31, 0xFE, 0x01, 0x15 };
            sendHexArray(GAP_GetParam, 5, "GAP_GetParam");
            Thread.Sleep(100);

            GAP_GetParam[4] = 0x16;
            sendHexArray(GAP_GetParam, 5, "GAP_GetParam");
            Thread.Sleep(100);

            GAP_GetParam[4] = 0x1A;
            sendHexArray(GAP_GetParam, 5, "GAP_GetParam");
            Thread.Sleep(100);

            GAP_GetParam[4] = 0x19;
            sendHexArray(GAP_GetParam, 5, "GAP_GetParam");
            Thread.Sleep(100);
        }

        // Start Button
        private void button2_Click(object sender, EventArgs e)
        {
            // make sure sport is already assigned a value by serialport_connect method.
            if (sport == null)
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
    }
}
