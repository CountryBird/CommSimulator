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
            ReceiveButton = new Button();
            DataText = new TextBox();
            TextBox = new TextBox();
            CommLayout = new TableLayoutPanel();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            SerialPanel = new Panel();
            SPortNameText = new TextBox();
            SBaudRateText = new TextBox();
            SerialLabel = new Label();
            CommLayout.SuspendLayout();
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
            SendButton.Location = new Point(347, 410);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(75, 23);
            SendButton.TabIndex = 4;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // ReceiveButton
            // 
            ReceiveButton.Location = new Point(441, 410);
            ReceiveButton.Name = "ReceiveButton";
            ReceiveButton.Size = new Size(75, 23);
            ReceiveButton.TabIndex = 5;
            ReceiveButton.Text = "Receive";
            ReceiveButton.UseVisualStyleBackColor = true;
            ReceiveButton.Click += ReceiveButton_Click;
            // 
            // DataText
            // 
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
            CommLayout.Controls.Add(panel2, 1, 0);
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
            // panel2
            // 
            panel2.Location = new Point(307, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 100);
            panel2.TabIndex = 1;
            // 
            // SerialPanel
            // 
            SerialPanel.BorderStyle = BorderStyle.FixedSingle;
            SerialPanel.Controls.Add(SPortNameText);
            SerialPanel.Controls.Add(SBaudRateText);
            SerialPanel.Controls.Add(SerialLabel);
            SerialPanel.Dock = DockStyle.Fill;
            SerialPanel.Location = new Point(3, 3);
            SerialPanel.Name = "SerialPanel";
            SerialPanel.Size = new Size(298, 188);
            SerialPanel.TabIndex = 0;
            // 
            // SPortNameText
            // 
            SPortNameText.Location = new Point(25, 48);
            SPortNameText.Name = "SPortNameText";
            SPortNameText.Size = new Size(100, 23);
            SPortNameText.TabIndex = 2;
            SPortNameText.Text = "PortName";
            // 
            // SBaudRateText
            // 
            SBaudRateText.Location = new Point(25, 77);
            SBaudRateText.Name = "SBaudRateText";
            SBaudRateText.Size = new Size(100, 23);
            SBaudRateText.TabIndex = 1;
            SBaudRateText.Text = "BaudRate";
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CommLayout);
            Controls.Add(TextBox);
            Controls.Add(DataText);
            Controls.Add(ReceiveButton);
            Controls.Add(SendButton);
            Controls.Add(ButtonLabel);
            Name = "MainForm";
            Text = "CommSimulator";
            CommLayout.ResumeLayout(false);
            SerialPanel.ResumeLayout(false);
            SerialPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label ButtonLabel;
        private Button SendButton;
        private Button ReceiveButton;
        private TextBox DataText;
        private TextBox TextBox;
        private TableLayoutPanel CommLayout;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel SerialPanel;
        private TextBox SPortNameText;
        private TextBox SBaudRateText;
        private Label SerialLabel;
    }
}
