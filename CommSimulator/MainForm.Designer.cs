namespace CommSimulator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ButtonLabel = new Label();
            SendButton = new Button();
            DataText = new TextBox();
            TextBox = new TextBox();
            CommLayout = new TableLayoutPanel();
            CommSettingPanel = new Panel();
            ColorTheme = new CheckBox();
            LoopCheckBox = new CheckBox();
            LoopDelayTime = new NumericUpDown();
            UDPPanel = new Panel();
            BroadcastCheck = new CheckBox();
            AnyAdressCheck = new CheckBox();
            UDPCheckBox = new CheckBox();
            UDPPortText = new TextBox();
            UDPIPAddressText = new TextBox();
            UDPLabel = new Label();
            TCPPanel = new Panel();
            TCPComboBox = new ComboBox();
            TCPCheckBox = new CheckBox();
            TCPPortText = new TextBox();
            TCPIPAddressText = new TextBox();
            TCPLabel = new Label();
            SerialPanel = new Panel();
            SerialCheckBox = new CheckBox();
            PortNameText = new TextBox();
            BaudRateText = new TextBox();
            SerialLabel = new Label();
            ConnectButton = new Button();
            DisconnectButton = new Button();
            CommLayout.SuspendLayout();
            CommSettingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LoopDelayTime).BeginInit();
            UDPPanel.SuspendLayout();
            TCPPanel.SuspendLayout();
            SerialPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonLabel
            // 
            ButtonLabel.BorderStyle = BorderStyle.FixedSingle;
            ButtonLabel.Dock = DockStyle.Bottom;
            ButtonLabel.Location = new Point(0, 388);
            ButtonLabel.Name = "ButtonLabel";
            ButtonLabel.Size = new Size(800, 62);
            ButtonLabel.TabIndex = 1;
            // 
            // SendButton
            // 
            SendButton.Location = new Point(345, 410);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(75, 23);
            SendButton.TabIndex = 4;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // DataText
            // 
            DataText.ForeColor = SystemColors.WindowFrame;
            DataText.Location = new Point(12, 410);
            DataText.Name = "DataText";
            DataText.Size = new Size(304, 23);
            DataText.TabIndex = 6;
            DataText.Text = "Data";
            // 
            // TextBox
            // 
            TextBox.Dock = DockStyle.Right;
            TextBox.Location = new Point(608, 0);
            TextBox.Multiline = true;
            TextBox.Name = "TextBox";
            TextBox.ReadOnly = true;
            TextBox.Size = new Size(192, 388);
            TextBox.TabIndex = 8;
            // 
            // CommLayout
            // 
            CommLayout.AutoSize = true;
            CommLayout.ColumnCount = 2;
            CommLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            CommLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            CommLayout.Controls.Add(CommSettingPanel, 1, 1);
            CommLayout.Controls.Add(UDPPanel, 0, 1);
            CommLayout.Controls.Add(TCPPanel, 1, 0);
            CommLayout.Controls.Add(SerialPanel, 0, 0);
            CommLayout.Dock = DockStyle.Fill;
            CommLayout.Location = new Point(0, 0);
            CommLayout.Name = "CommLayout";
            CommLayout.RowCount = 2;
            CommLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            CommLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            CommLayout.Size = new Size(608, 388);
            CommLayout.TabIndex = 9;
            // 
            // CommSettingPanel
            // 
            CommSettingPanel.Controls.Add(ColorTheme);
            CommSettingPanel.Controls.Add(LoopCheckBox);
            CommSettingPanel.Controls.Add(LoopDelayTime);
            CommSettingPanel.Dock = DockStyle.Fill;
            CommSettingPanel.Location = new Point(307, 197);
            CommSettingPanel.Name = "CommSettingPanel";
            CommSettingPanel.Size = new Size(298, 188);
            CommSettingPanel.TabIndex = 3;
            // 
            // ColorTheme
            // 
            ColorTheme.Appearance = Appearance.Button;
            ColorTheme.AutoSize = true;
            ColorTheme.Location = new Point(26, 65);
            ColorTheme.Name = "ColorTheme";
            ColorTheme.Size = new Size(75, 25);
            ColorTheme.TabIndex = 2;
            ColorTheme.Text = "LightMode";
            ColorTheme.UseVisualStyleBackColor = true;
            ColorTheme.CheckedChanged += ColorTheme_CheckedChanged;
            // 
            // LoopCheckBox
            // 
            LoopCheckBox.AutoSize = true;
            LoopCheckBox.Location = new Point(26, 27);
            LoopCheckBox.Name = "LoopCheckBox";
            LoopCheckBox.Size = new Size(53, 19);
            LoopCheckBox.TabIndex = 1;
            LoopCheckBox.Text = "Loop";
            LoopCheckBox.UseVisualStyleBackColor = true;
            LoopCheckBox.CheckedChanged += LoopCheckBox_CheckedChanged;
            // 
            // LoopDelayTime
            // 
            LoopDelayTime.Enabled = false;
            LoopDelayTime.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            LoopDelayTime.Location = new Point(85, 26);
            LoopDelayTime.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            LoopDelayTime.Name = "LoopDelayTime";
            LoopDelayTime.Size = new Size(60, 23);
            LoopDelayTime.TabIndex = 0;
            // 
            // UDPPanel
            // 
            UDPPanel.BorderStyle = BorderStyle.FixedSingle;
            UDPPanel.Controls.Add(BroadcastCheck);
            UDPPanel.Controls.Add(AnyAdressCheck);
            UDPPanel.Controls.Add(UDPCheckBox);
            UDPPanel.Controls.Add(UDPPortText);
            UDPPanel.Controls.Add(UDPIPAddressText);
            UDPPanel.Controls.Add(UDPLabel);
            UDPPanel.Dock = DockStyle.Fill;
            UDPPanel.Location = new Point(3, 197);
            UDPPanel.Name = "UDPPanel";
            UDPPanel.Size = new Size(298, 188);
            UDPPanel.TabIndex = 2;
            // 
            // BroadcastCheck
            // 
            BroadcastCheck.AutoSize = true;
            BroadcastCheck.Enabled = false;
            BroadcastCheck.Location = new Point(131, 75);
            BroadcastCheck.Name = "BroadcastCheck";
            BroadcastCheck.Size = new Size(78, 19);
            BroadcastCheck.TabIndex = 13;
            BroadcastCheck.Text = "Broadcast";
            BroadcastCheck.UseVisualStyleBackColor = true;
            BroadcastCheck.CheckedChanged += BroadcastCheck_CheckedChanged;
            // 
            // AnyAdressCheck
            // 
            AnyAdressCheck.AutoSize = true;
            AnyAdressCheck.Enabled = false;
            AnyAdressCheck.Location = new Point(131, 50);
            AnyAdressCheck.Name = "AnyAdressCheck";
            AnyAdressCheck.Size = new Size(93, 19);
            AnyAdressCheck.TabIndex = 12;
            AnyAdressCheck.Text = "Any Address";
            AnyAdressCheck.UseVisualStyleBackColor = true;
            AnyAdressCheck.CheckedChanged += AnyAdressCheck_CheckedChanged;
            // 
            // UDPCheckBox
            // 
            UDPCheckBox.AutoSize = true;
            UDPCheckBox.Location = new Point(278, 8);
            UDPCheckBox.Name = "UDPCheckBox";
            UDPCheckBox.Size = new Size(15, 14);
            UDPCheckBox.TabIndex = 5;
            UDPCheckBox.UseVisualStyleBackColor = true;
            UDPCheckBox.CheckedChanged += UDPCheckBox_CheckedChanged;
            // 
            // UDPPortText
            // 
            UDPPortText.Location = new Point(25, 77);
            UDPPortText.Name = "UDPPortText";
            UDPPortText.Size = new Size(100, 23);
            UDPPortText.TabIndex = 3;
            UDPPortText.Text = "Port";
            // 
            // UDPIPAddressText
            // 
            UDPIPAddressText.Location = new Point(25, 48);
            UDPIPAddressText.Name = "UDPIPAddressText";
            UDPIPAddressText.Size = new Size(100, 23);
            UDPIPAddressText.TabIndex = 2;
            UDPIPAddressText.Text = "IPAddress";
            // 
            // UDPLabel
            // 
            UDPLabel.BorderStyle = BorderStyle.FixedSingle;
            UDPLabel.Font = new Font("휴먼둥근헤드라인", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            UDPLabel.Location = new Point(0, 0);
            UDPLabel.Name = "UDPLabel";
            UDPLabel.Size = new Size(78, 21);
            UDPLabel.TabIndex = 1;
            UDPLabel.Text = "UDP";
            // 
            // TCPPanel
            // 
            TCPPanel.BorderStyle = BorderStyle.FixedSingle;
            TCPPanel.Controls.Add(TCPComboBox);
            TCPPanel.Controls.Add(TCPCheckBox);
            TCPPanel.Controls.Add(TCPPortText);
            TCPPanel.Controls.Add(TCPIPAddressText);
            TCPPanel.Controls.Add(TCPLabel);
            TCPPanel.Dock = DockStyle.Fill;
            TCPPanel.Location = new Point(307, 3);
            TCPPanel.Name = "TCPPanel";
            TCPPanel.Size = new Size(298, 188);
            TCPPanel.TabIndex = 1;
            // 
            // TCPComboBox
            // 
            TCPComboBox.FormattingEnabled = true;
            TCPComboBox.Items.AddRange(new object[] { "Server", "Client" });
            TCPComboBox.Location = new Point(159, 62);
            TCPComboBox.Name = "TCPComboBox";
            TCPComboBox.Size = new Size(121, 23);
            TCPComboBox.TabIndex = 5;
            TCPComboBox.Text = "Server";
            // 
            // TCPCheckBox
            // 
            TCPCheckBox.AutoSize = true;
            TCPCheckBox.Location = new Point(278, 8);
            TCPCheckBox.Name = "TCPCheckBox";
            TCPCheckBox.Size = new Size(15, 14);
            TCPCheckBox.TabIndex = 4;
            TCPCheckBox.UseVisualStyleBackColor = true;
            TCPCheckBox.CheckedChanged += TCPCheckBox_CheckedChanged;
            // 
            // TCPPortText
            // 
            TCPPortText.Location = new Point(25, 77);
            TCPPortText.Name = "TCPPortText";
            TCPPortText.Size = new Size(100, 23);
            TCPPortText.TabIndex = 2;
            TCPPortText.Text = "Port";
            // 
            // TCPIPAddressText
            // 
            TCPIPAddressText.Location = new Point(25, 48);
            TCPIPAddressText.Name = "TCPIPAddressText";
            TCPIPAddressText.Size = new Size(100, 23);
            TCPIPAddressText.TabIndex = 1;
            TCPIPAddressText.Text = "IPAddress";
            // 
            // TCPLabel
            // 
            TCPLabel.BorderStyle = BorderStyle.FixedSingle;
            TCPLabel.Font = new Font("휴먼둥근헤드라인", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            TCPLabel.Location = new Point(0, 0);
            TCPLabel.Name = "TCPLabel";
            TCPLabel.Size = new Size(78, 21);
            TCPLabel.TabIndex = 0;
            TCPLabel.Text = "TCP";
            // 
            // SerialPanel
            // 
            SerialPanel.BorderStyle = BorderStyle.FixedSingle;
            SerialPanel.Controls.Add(SerialCheckBox);
            SerialPanel.Controls.Add(PortNameText);
            SerialPanel.Controls.Add(BaudRateText);
            SerialPanel.Controls.Add(SerialLabel);
            SerialPanel.Dock = DockStyle.Fill;
            SerialPanel.Location = new Point(3, 3);
            SerialPanel.Name = "SerialPanel";
            SerialPanel.Size = new Size(298, 188);
            SerialPanel.TabIndex = 0;
            // 
            // SerialCheckBox
            // 
            SerialCheckBox.AutoSize = true;
            SerialCheckBox.Location = new Point(278, 8);
            SerialCheckBox.Name = "SerialCheckBox";
            SerialCheckBox.Size = new Size(15, 14);
            SerialCheckBox.TabIndex = 3;
            SerialCheckBox.UseVisualStyleBackColor = true;
            SerialCheckBox.CheckedChanged += SerialCheckBox_CheckedChanged;
            // 
            // PortNameText
            // 
            PortNameText.Location = new Point(25, 48);
            PortNameText.Name = "PortNameText";
            PortNameText.Size = new Size(100, 23);
            PortNameText.TabIndex = 2;
            PortNameText.Text = "PortName";
            // 
            // BaudRateText
            // 
            BaudRateText.Location = new Point(25, 77);
            BaudRateText.Name = "BaudRateText";
            BaudRateText.Size = new Size(100, 23);
            BaudRateText.TabIndex = 1;
            BaudRateText.Text = "BaudRate";
            // 
            // SerialLabel
            // 
            SerialLabel.AutoSize = true;
            SerialLabel.BorderStyle = BorderStyle.FixedSingle;
            SerialLabel.Font = new Font("휴먼둥근헤드라인", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            SerialLabel.Location = new Point(0, 0);
            SerialLabel.Name = "SerialLabel";
            SerialLabel.Size = new Size(78, 21);
            SerialLabel.TabIndex = 0;
            SerialLabel.Text = "Serial";
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(530, 410);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(75, 23);
            ConnectButton.TabIndex = 10;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // DisconnectButton
            // 
            DisconnectButton.Location = new Point(621, 410);
            DisconnectButton.Name = "DisconnectButton";
            DisconnectButton.Size = new Size(75, 23);
            DisconnectButton.TabIndex = 11;
            DisconnectButton.Text = "Disconnect";
            DisconnectButton.UseVisualStyleBackColor = true;
            DisconnectButton.Click += DisconnectButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DisconnectButton);
            Controls.Add(ConnectButton);
            Controls.Add(CommLayout);
            Controls.Add(TextBox);
            Controls.Add(DataText);
            Controls.Add(SendButton);
            Controls.Add(ButtonLabel);
            Name = "MainForm";
            Text = "CommSimulator";
            CommLayout.ResumeLayout(false);
            CommSettingPanel.ResumeLayout(false);
            CommSettingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LoopDelayTime).EndInit();
            UDPPanel.ResumeLayout(false);
            UDPPanel.PerformLayout();
            TCPPanel.ResumeLayout(false);
            TCPPanel.PerformLayout();
            SerialPanel.ResumeLayout(false);
            SerialPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label ButtonLabel;
        private Button SendButton;
        private TextBox DataText;
        private TextBox TextBox;
        private TableLayoutPanel CommLayout;
        private Panel CommSettingPanel;
        private Panel UDPPanel;
        private Panel TCPPanel;
        private Panel SerialPanel;
        private TextBox PortNameText;
        private TextBox BaudRateText;
        private Label SerialLabel;
        private Button ConnectButton;
        private Button DisconnectButton;
        private Label TCPLabel;
        private TextBox TCPPortText;
        private TextBox TCPIPAddressText;
        private CheckBox TCPCheckBox;
        private CheckBox SerialCheckBox;
        private ComboBox TCPComboBox;
        private Label UDPLabel;
        private TextBox UDPPortText;
        private TextBox UDPIPAddressText;
        private CheckBox UDPCheckBox;
        private CheckBox AnyAdressCheck;
        private NumericUpDown LoopDelayTime;
        private CheckBox LoopCheckBox;
        private CheckBox BroadcastCheck;
        private CheckBox ColorTheme;
    }
}
