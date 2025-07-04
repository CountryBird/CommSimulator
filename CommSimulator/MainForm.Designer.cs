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
            panel4 = new Panel();
            panel3 = new Panel();
            TCPPanel = new Panel();
            TCPComboBox = new ComboBox();
            TCPCheckBox = new CheckBox();
            PortText = new TextBox();
            IPAddressText = new TextBox();
            TCPLabel = new Label();
            SerialPanel = new Panel();
            SerialCheckBox = new CheckBox();
            PortNameText = new TextBox();
            BaudRateText = new TextBox();
            SerialLabel = new Label();
            ConnectButton = new Button();
            DisconnectButton = new Button();
            CommLayout.SuspendLayout();
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
            TextBox.Size = new Size(192, 388);
            TextBox.TabIndex = 8;
            // 
            // CommLayout
            // 
            CommLayout.AutoSize = true;
            CommLayout.ColumnCount = 2;
            CommLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            CommLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            CommLayout.Controls.Add(panel4, 1, 1);
            CommLayout.Controls.Add(panel3, 0, 1);
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
            // panel4
            // 
            panel4.Location = new Point(307, 197);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 100);
            panel4.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Location = new Point(3, 197);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 100);
            panel3.TabIndex = 2;
            // 
            // TCPPanel
            // 
            TCPPanel.BorderStyle = BorderStyle.FixedSingle;
            TCPPanel.Controls.Add(TCPComboBox);
            TCPPanel.Controls.Add(TCPCheckBox);
            TCPPanel.Controls.Add(PortText);
            TCPPanel.Controls.Add(IPAddressText);
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
            TCPComboBox.Location = new Point(150, 62);
            TCPComboBox.Name = "TCPComboBox";
            TCPComboBox.Size = new Size(121, 23);
            TCPComboBox.TabIndex = 5;
            // 
            // TCPCheckBox
            // 
            TCPCheckBox.AutoSize = true;
            TCPCheckBox.Location = new Point(278, 8);
            TCPCheckBox.Name = "TCPCheckBox";
            TCPCheckBox.Size = new Size(15, 14);
            TCPCheckBox.TabIndex = 4;
            TCPCheckBox.UseVisualStyleBackColor = true;
            // 
            // PortText
            // 
            PortText.Location = new Point(12, 77);
            PortText.Name = "PortText";
            PortText.Size = new Size(100, 23);
            PortText.TabIndex = 2;
            PortText.Text = "Port";
            // 
            // IPAddressText
            // 
            IPAddressText.Location = new Point(12, 48);
            IPAddressText.Name = "IPAddressText";
            IPAddressText.Size = new Size(100, 23);
            IPAddressText.TabIndex = 1;
            IPAddressText.Text = "IPAddress";
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
        private Panel panel4;
        private Panel panel3;
        private Panel TCPPanel;
        private Panel SerialPanel;
        private TextBox PortNameText;
        private TextBox BaudRateText;
        private Label SerialLabel;
        private Button ConnectButton;
        private Button DisconnectButton;
        private Label TCPLabel;
        private TextBox PortText;
        private TextBox IPAddressText;
        private CheckBox TCPCheckBox;
        private CheckBox SerialCheckBox;
        private ComboBox TCPComboBox;
    }
}
