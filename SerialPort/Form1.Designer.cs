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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(269, 40);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(102, 28);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "DUT Port:";
            // 
            // cmbbaudrate
            // 
            this.cmbbaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbaudrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbbaudrate.FormattingEnabled = true;
            this.cmbbaudrate.Items.AddRange(new object[] {
            "9600"});
            this.cmbbaudrate.Location = new System.Drawing.Point(139, 43);
            this.cmbbaudrate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbbaudrate.Name = "cmbbaudrate";
            this.cmbbaudrate.Size = new System.Drawing.Size(108, 24);
            this.cmbbaudrate.TabIndex = 15;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(391, 85);
            this.sendButton.Margin = new System.Windows.Forms.Padding(4);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(107, 28);
            this.sendButton.TabIndex = 16;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // txtDatatoSend
            // 
            this.txtDatatoSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatatoSend.Location = new System.Drawing.Point(139, 88);
            this.txtDatatoSend.Margin = new System.Windows.Forms.Padding(4);
            this.txtDatatoSend.Name = "txtDatatoSend";
            this.txtDatatoSend.Size = new System.Drawing.Size(232, 23);
            this.txtDatatoSend.TabIndex = 17;
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(391, 40);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(4);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(107, 28);
            this.disconnectButton.TabIndex = 18;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // DUTPort
            // 
            this.DUTPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DUTPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DUTPort.FormattingEnabled = true;
            this.DUTPort.Location = new System.Drawing.Point(13, 43);
            this.DUTPort.Margin = new System.Windows.Forms.Padding(4);
            this.DUTPort.Name = "DUTPort";
            this.DUTPort.Size = new System.Drawing.Size(104, 24);
            this.DUTPort.TabIndex = 19;
            // 
            // txtReceive
            // 
            this.txtReceive.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtReceive.Location = new System.Drawing.Point(12, 121);
            this.txtReceive.Margin = new System.Windows.Forms.Padding(4);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ReadOnly = true;
            this.txtReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceive.Size = new System.Drawing.Size(484, 235);
            this.txtReceive.TabIndex = 20;
            // 
            // startTestButton
            // 
            this.startTestButton.Location = new System.Drawing.Point(13, 111);
            this.startTestButton.Margin = new System.Windows.Forms.Padding(4);
            this.startTestButton.Name = "startTestButton";
            this.startTestButton.Size = new System.Drawing.Size(485, 76);
            this.startTestButton.TabIndex = 21;
            this.startTestButton.Text = "Test";
            this.startTestButton.UseVisualStyleBackColor = true;
            this.startTestButton.Click += new System.EventHandler(this.startTestButton_Click);
            // 
            // startBurnButton
            // 
            this.startBurnButton.Location = new System.Drawing.Point(12, 24);
            this.startBurnButton.Margin = new System.Windows.Forms.Padding(4);
            this.startBurnButton.Name = "startBurnButton";
            this.startBurnButton.Size = new System.Drawing.Size(485, 76);
            this.startBurnButton.TabIndex = 22;
            this.startBurnButton.Text = "Burn";
            this.startBurnButton.UseVisualStyleBackColor = true;
            this.startBurnButton.Click += new System.EventHandler(this.startBurnButton_Click);
            // 
            // REFPort
            // 
            this.REFPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.REFPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REFPort.FormattingEnabled = true;
            this.REFPort.Location = new System.Drawing.Point(13, 88);
            this.REFPort.Margin = new System.Windows.Forms.Padding(4);
            this.REFPort.Name = "REFPort";
            this.REFPort.Size = new System.Drawing.Size(104, 24);
            this.REFPort.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "REF Port:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(13, 199);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(485, 101);
            this.richTextBox1.TabIndex = 25;
            this.richTextBox1.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(10);
            this.checkBox1.Size = new System.Drawing.Size(512, 41);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.Text = "Advanced Panel";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.disconnectButton);
            this.groupBox1.Controls.Add(this.sendButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.REFPort);
            this.groupBox1.Controls.Add(this.txtReceive);
            this.groupBox1.Controls.Add(this.connectButton);
            this.groupBox1.Controls.Add(this.cmbbaudrate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DUTPort);
            this.groupBox1.Controls.Add(this.txtDatatoSend);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 376);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advanced Panel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Baud Rate:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.startBurnButton);
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Controls.Add(this.startTestButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 417);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 315);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General Panel";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(512, 731);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Sprintron Flash Programmer & Tester";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

