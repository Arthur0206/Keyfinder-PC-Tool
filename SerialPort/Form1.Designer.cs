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
            this.cmdConnect = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbstopbits = new System.Windows.Forms.ComboBox();
            this.cmbparity = new System.Windows.Forms.ComboBox();
            this.cmbbaudrate = new System.Windows.Forms.ComboBox();
            this.cmbdatabits = new System.Windows.Forms.ComboBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.txtDatatoSend = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.ComboBox();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(15, 668);
            this.cmdConnect.Margin = new System.Windows.Forms.Padding(4);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(70, 28);
            this.cmdConnect.TabIndex = 0;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 605);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Com Port:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 605);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Databits:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 605);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Parity:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 605);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Stopbits:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 605);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Baud Rate:";
            // 
            // cmbstopbits
            // 
            this.cmbstopbits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbstopbits.FormattingEnabled = true;
            this.cmbstopbits.Items.AddRange(new object[] {
            "None",
            "One",
            "OnePointFive",
            "Two"});
            this.cmbstopbits.Location = new System.Drawing.Point(363, 625);
            this.cmbstopbits.Margin = new System.Windows.Forms.Padding(4);
            this.cmbstopbits.Name = "cmbstopbits";
            this.cmbstopbits.Size = new System.Drawing.Size(80, 24);
            this.cmbstopbits.TabIndex = 12;
            // 
            // cmbparity
            // 
            this.cmbparity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbparity.FormattingEnabled = true;
            this.cmbparity.Items.AddRange(new object[] {
            "Even",
            "Odd",
            "None",
            "Mark",
            "Space"});
            this.cmbparity.Location = new System.Drawing.Point(188, 625);
            this.cmbparity.Margin = new System.Windows.Forms.Padding(4);
            this.cmbparity.Name = "cmbparity";
            this.cmbparity.Size = new System.Drawing.Size(84, 24);
            this.cmbparity.TabIndex = 13;
            // 
            // cmbbaudrate
            // 
            this.cmbbaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbaudrate.FormattingEnabled = true;
            this.cmbbaudrate.Items.AddRange(new object[] {
            "9600"});
            this.cmbbaudrate.Location = new System.Drawing.Point(102, 625);
            this.cmbbaudrate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbbaudrate.Name = "cmbbaudrate";
            this.cmbbaudrate.Size = new System.Drawing.Size(77, 24);
            this.cmbbaudrate.TabIndex = 15;
            this.cmbbaudrate.SelectedIndexChanged += new System.EventHandler(this.cmbbaudrate_SelectedIndexChanged);
            // 
            // cmbdatabits
            // 
            this.cmbdatabits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdatabits.FormattingEnabled = true;
            this.cmbdatabits.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cmbdatabits.Location = new System.Drawing.Point(280, 625);
            this.cmbdatabits.Margin = new System.Windows.Forms.Padding(4);
            this.cmbdatabits.Name = "cmbdatabits";
            this.cmbdatabits.Size = new System.Drawing.Size(73, 24);
            this.cmbdatabits.TabIndex = 14;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(363, 668);
            this.sendButton.Margin = new System.Windows.Forms.Padding(4);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(81, 28);
            this.sendButton.TabIndex = 16;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDatatoSend
            // 
            this.txtDatatoSend.Location = new System.Drawing.Point(187, 671);
            this.txtDatatoSend.Margin = new System.Windows.Forms.Padding(4);
            this.txtDatatoSend.Name = "txtDatatoSend";
            this.txtDatatoSend.Size = new System.Drawing.Size(166, 22);
            this.txtDatatoSend.TabIndex = 17;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(93, 668);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(4);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(86, 28);
            this.cmdClose.TabIndex = 18;
            this.cmdClose.Text = "Disconnect";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click_1);
            // 
            // txtPort
            // 
            this.txtPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtPort.FormattingEnabled = true;
            this.txtPort.Location = new System.Drawing.Point(15, 625);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(77, 24);
            this.txtPort.TabIndex = 19;
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
            this.txtReceive.TextChanged += new System.EventHandler(this.txtReceive_TextChanged);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(451, 625);
            this.startButton.Margin = new System.Windows.Forms.Padding(4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 71);
            this.startButton.TabIndex = 21;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 707);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.txtDatatoSend);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.cmbbaudrate);
            this.Controls.Add(this.cmbdatabits);
            this.Controls.Add(this.cmbparity);
            this.Controls.Add(this.cmbstopbits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdConnect);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Sprintron Flash Programmer & Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdConnect;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbstopbits;
        private System.Windows.Forms.ComboBox cmbparity;
        private System.Windows.Forms.ComboBox cmbbaudrate;
        private System.Windows.Forms.ComboBox cmbdatabits;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox txtDatatoSend;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ComboBox txtPort;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Button startButton;
    }
}

