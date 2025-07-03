using Serial;
using System.Diagnostics;
using System.IO.Ports;

namespace CommSimulator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (DataText.Text != "Data") 
            {
                // TODO: 임시 구분 조건임
                if (SPortNameText.Text != "PortName" && SBaudRateText.Text != "BaudRate")
                {
                    SerialSender serialSender = new SerialSender(SPortNameText.Text, int.Parse(SBaudRateText.Text), Parity.None,8,StopBits.One);
                    serialSender.Send(DataText.Text);
                }
            }
        }

        private void ReceiveButton_Click(object sender, EventArgs e)
        {
            // TODO: 임시 구분 조건임
            if (SPortNameText.Text != "PortName" && SBaudRateText.Text != "BaudRate")
            {
                SerialReceiver serialReceiver = new SerialReceiver(SPortNameText.Text,int.Parse(SBaudRateText.Text),Parity.None,8,StopBits.One);
                serialReceiver.DataReceived += SerialReceiver_DataReceived;
            }
        }

        private void SerialReceiver_DataReceived(object sender, string receivedData)
        {
            if (TextBox.InvokeRequired)
            {
                TextBox.Invoke(new Action(() =>
                UpdateTextBox(receivedData)));
            }
            else UpdateTextBox(receivedData);
        }

        private void UpdateTextBox(string receivedData)
        {
            TextBox.AppendText(receivedData+Environment.NewLine);
        }
    }
}
