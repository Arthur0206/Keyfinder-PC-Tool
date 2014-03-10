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
            this.advancedGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.generalGroupBox = new System.Windows.Forms.GroupBox();
            this.advancedPanel = new System.Windows.Forms.Panel();
            this.generalPanel = new System.Windows.Forms.Panel();
            this.advancedGroupBox.SuspendLayout();
            this.generalGroupBox.SuspendLayout();
            this.advancedPanel.SuspendLayout();
            this.generalPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(267, 40);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(104, 28);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "DUT Port:";
            // 
            // cmbbaudrate
            // 
            this.cmbbaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbaudrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbbaudrate.FormattingEnabled = true;
            this.cmbbaudrate.Items.AddRange(new object[] {
            "9600"});
            this.cmbbaudrate.Location = new System.Drawing.Point(139, 41);
            this.cmbbaudrate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbbaudrate.Name = "cmbbaudrate";
            this.cmbbaudrate.Size = new System.Drawing.Size(108, 26);
            this.cmbbaudrate.TabIndex = 15;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(390, 86);
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
            this.txtDatatoSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatatoSend.Location = new System.Drawing.Point(139, 89);
            this.txtDatatoSend.Margin = new System.Windows.Forms.Padding(4);
            this.txtDatatoSend.Name = "txtDatatoSend";
            this.txtDatatoSend.Size = new System.Drawing.Size(232, 24);
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
            this.DUTPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DUTPort.FormattingEnabled = true;
            this.DUTPort.Location = new System.Drawing.Point(13, 41);
            this.DUTPort.Margin = new System.Windows.Forms.Padding(4);
            this.DUTPort.Name = "DUTPort";
            this.DUTPort.Size = new System.Drawing.Size(104, 26);
            this.DUTPort.TabIndex = 19;
            // 
            // txtReceive
            // 
            this.txtReceive.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtReceive.Location = new System.Drawing.Point(13, 121);
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
            this.REFPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REFPort.FormattingEnabled = true;
            this.REFPort.Location = new System.Drawing.Point(13, 87);
            this.REFPort.Margin = new System.Windows.Forms.Padding(4);
            this.REFPort.Name = "REFPort";
            this.REFPort.Size = new System.Drawing.Size(104, 26);
            this.REFPort.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "REF Port:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(13, 199);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.richTextBox1.Size = new System.Drawing.Size(485, 97);
            this.richTextBox1.TabIndex = 25;
            this.richTextBox1.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox1.Location = new System.Drawing.Point(0, 325);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(380, 0, 0, 10);
            this.checkBox1.Size = new System.Drawing.Size(540, 31);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.Text = "Advanced Panel";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // advancedGroupBox
            // 
            this.advancedGroupBox.Controls.Add(this.disconnectButton);
            this.advancedGroupBox.Controls.Add(this.sendButton);
            this.advancedGroupBox.Controls.Add(this.label2);
            this.advancedGroupBox.Controls.Add(this.REFPort);
            this.advancedGroupBox.Controls.Add(this.txtReceive);
            this.advancedGroupBox.Controls.Add(this.connectButton);
            this.advancedGroupBox.Controls.Add(this.cmbbaudrate);
            this.advancedGroupBox.Controls.Add(this.label5);
            this.advancedGroupBox.Controls.Add(this.label1);
            this.advancedGroupBox.Controls.Add(this.DUTPort);
            this.advancedGroupBox.Controls.Add(this.txtDatatoSend);
            this.advancedGroupBox.Location = new System.Drawing.Point(14, 10);
            this.advancedGroupBox.Margin = new System.Windows.Forms.Padding(10);
            this.advancedGroupBox.Name = "advancedGroupBox";
            this.advancedGroupBox.Size = new System.Drawing.Size(512, 370);
            this.advancedGroupBox.TabIndex = 27;
            this.advancedGroupBox.TabStop = false;
            this.advancedGroupBox.Text = "Advanced Panel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Baud Rate:";
            // 
            // generalGroupBox
            // 
            this.generalGroupBox.Controls.Add(this.startBurnButton);
            this.generalGroupBox.Controls.Add(this.richTextBox1);
            this.generalGroupBox.Controls.Add(this.startTestButton);
            this.generalGroupBox.Location = new System.Drawing.Point(14, 7);
            this.generalGroupBox.Margin = new System.Windows.Forms.Padding(10);
            this.generalGroupBox.Name = "generalGroupBox";
            this.generalGroupBox.Size = new System.Drawing.Size(512, 308);
            this.generalGroupBox.TabIndex = 28;
            this.generalGroupBox.TabStop = false;
            this.generalGroupBox.Text = "General Panel";
            // 
            // advancedPanel
            // 
            this.advancedPanel.Controls.Add(this.advancedGroupBox);
            this.advancedPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.advancedPanel.Location = new System.Drawing.Point(0, 356);
            this.advancedPanel.Name = "advancedPanel";
            this.advancedPanel.Size = new System.Drawing.Size(540, 394);
            this.advancedPanel.TabIndex = 29;
            // 
            // generalPanel
            // 
            this.generalPanel.AutoSize = true;
            this.generalPanel.Controls.Add(this.generalGroupBox);
            this.generalPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.generalPanel.Location = new System.Drawing.Point(0, 0);
            this.generalPanel.Name = "generalPanel";
            this.generalPanel.Size = new System.Drawing.Size(540, 325);
            this.generalPanel.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(540, 765);
            this.Controls.Add(this.advancedPanel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.generalPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(558, 0);
            this.Name = "Form1";
            this.Text = "Sprintron Flash Programmer & Tester";
            this.advancedGroupBox.ResumeLayout(false);
            this.advancedGroupBox.PerformLayout();
            this.generalGroupBox.ResumeLayout(false);
            this.advancedPanel.ResumeLayout(false);
            this.generalPanel.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox advancedGroupBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox generalGroupBox;
        private System.Windows.Forms.Panel advancedPanel;
        private System.Windows.Forms.Panel generalPanel;
    }
}

