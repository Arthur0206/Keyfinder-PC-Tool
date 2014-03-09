namespace SerialPort
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.connectButton = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbbaudrate = new System.Windows.Forms.ComboBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.txtDatatoSend = new System.Windows.Forms.TextBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.DUTPort = new System.Windows.Forms.ComboBox();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.startTestButton = new System.Windows.Forms.Button();
            this.startBurnButton = new System.Windows.Forms.Button();
            this.REFPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(198, 623);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(79, 28);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 606);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "DUT Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 606);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Baud Rate:";
            // 
            // cmbbaudrate
            // 
            this.cmbbaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbaudrate.FormattingEnabled = true;
            this.cmbbaudrate.Items.AddRange(new object[] {
            "9600"});
            this.cmbbaudrate.Location = new System.Drawing.Point(106, 625);
            this.cmbbaudrate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbbaudrate.Name = "cmbbaudrate";
            this.cmbbaudrate.Size = new System.Drawing.Size(77, 24);
            this.cmbbaudrate.TabIndex = 15;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(290, 671);
            this.sendButton.Margin = new System.Windows.Forms.Padding(4);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(81, 28);
            this.sendButton.TabIndex = 16;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // txtDatatoSend
            // 
            this.txtDatatoSend.Location = new System.Drawing.Point(107, 674);
            this.txtDatatoSend.Margin = new System.Windows.Forms.Padding(4);
            this.txtDatatoSend.Name = "txtDatatoSend";
            this.txtDatatoSend.Size = new System.Drawing.Size(170, 22);
            this.txtDatatoSend.TabIndex = 17;
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(285, 623);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(4);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(86, 28);
            this.disconnectButton.TabIndex = 18;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // DUTPort
            // 
            this.DUTPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DUTPort.FormattingEnabled = true;
            this.DUTPort.Location = new System.Drawing.Point(15, 625);
            this.DUTPort.Margin = new System.Windows.Forms.Padding(4);
            this.DUTPort.Name = "DUTPort";
            this.DUTPort.Size = new System.Drawing.Size(77, 24);
            this.DUTPort.TabIndex = 19;
            // 
            // txtReceive
            // 
            this.txtReceive.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtReceive.Location = new System.Drawing.Point(18, 16);
            this.txtReceive.Margin = new System.Windows.Forms.Padding(4);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ReadOnly = true;
            this.txtReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceive.Size = new System.Drawing.Size(506, 573);
            this.txtReceive.TabIndex = 20;
            // 
            // startTestButton
            // 
            this.startTestButton.Location = new System.Drawing.Point(456, 623);
            this.startTestButton.Margin = new System.Windows.Forms.Padding(4);
            this.startTestButton.Name = "startTestButton";
            this.startTestButton.Size = new System.Drawing.Size(65, 77);
            this.startTestButton.TabIndex = 21;
            this.startTestButton.Text = "Test";
            this.startTestButton.UseVisualStyleBackColor = true;
            this.startTestButton.Click += new System.EventHandler(this.startTestButton_Click);
            // 
            // startBurnButton
            // 
            this.startBurnButton.Location = new System.Drawing.Point(381, 623);
            this.startBurnButton.Margin = new System.Windows.Forms.Padding(4);
            this.startBurnButton.Name = "startBurnButton";
            this.startBurnButton.Size = new System.Drawing.Size(65, 77);
            this.startBurnButton.TabIndex = 22;
            this.startBurnButton.Text = "Burn";
            this.startBurnButton.UseVisualStyleBackColor = true;
            this.startBurnButton.Click += new System.EventHandler(this.startBurnButton_Click);
            // 
            // REFPort
            // 
            this.REFPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.REFPort.FormattingEnabled = true;
            this.REFPort.Location = new System.Drawing.Point(15, 673);
            this.REFPort.Margin = new System.Windows.Forms.Padding(4);
            this.REFPort.Name = "REFPort";
            this.REFPort.Size = new System.Drawing.Size(77, 24);
            this.REFPort.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 654);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "REF Port:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(539, 713);
            this.Controls.Add(this.REFPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startBurnButton);
            this.Controls.Add(this.startTestButton);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.DUTPort);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.txtDatatoSend);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.cmbbaudrate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Sprintron Flash Programmer & Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbbaudrate;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox txtDatatoSend;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.ComboBox DUTPort;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Button startTestButton;
        private System.Windows.Forms.Button startBurnButton;
        private System.Windows.Forms.ComboBox REFPort;
        private System.Windows.Forms.Label label2;
        private System.IO.Ports.SerialPort serialPort2;
    }
}

