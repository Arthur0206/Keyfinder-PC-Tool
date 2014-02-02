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
            this.label5 = new System.Windows.Forms.Label();
            this.cmbbaudrate = new System.Windows.Forms.ComboBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.txtDatatoSend = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.ComboBox();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.startTestButton = new System.Windows.Forms.Button();
            this.startBurnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(198, 623);
            this.cmdConnect.Margin = new System.Windows.Forms.Padding(4);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(79, 28);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 605);
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
            this.cmbbaudrate.SelectedIndexChanged += new System.EventHandler(this.cmbbaudrate_SelectedIndexChanged);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(290, 665);
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
            this.txtDatatoSend.Location = new System.Drawing.Point(15, 668);
            this.txtDatatoSend.Margin = new System.Windows.Forms.Padding(4);
            this.txtDatatoSend.Name = "txtDatatoSend";
            this.txtDatatoSend.Size = new System.Drawing.Size(262, 22);
            this.txtDatatoSend.TabIndex = 17;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(285, 623);
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
            // startTestButton
            // 
            this.startTestButton.Location = new System.Drawing.Point(456, 623);
            this.startTestButton.Margin = new System.Windows.Forms.Padding(4);
            this.startTestButton.Name = "startTestButton";
            this.startTestButton.Size = new System.Drawing.Size(65, 70);
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
            this.startBurnButton.Size = new System.Drawing.Size(65, 70);
            this.startBurnButton.TabIndex = 22;
            this.startBurnButton.Text = "Burn";
            this.startBurnButton.UseVisualStyleBackColor = true;
            this.startBurnButton.Click += new System.EventHandler(this.startBurnButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 707);
            this.Controls.Add(this.startBurnButton);
            this.Controls.Add(this.startTestButton);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.txtDatatoSend);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.cmbbaudrate);
            this.Controls.Add(this.label5);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbbaudrate;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox txtDatatoSend;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ComboBox txtPort;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Button startTestButton;
        private System.Windows.Forms.Button startBurnButton;
    }
}

