using Serial;
using System.Diagnostics;
using System.IO.Ports;

namespace CommSimulator
{
    public partial class MainForm : Form
    {

        SerialSender serialSender;
        SerialReceiver serialReceiver;
        public MainForm()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            // TODO: 임시 구분 조건임
            if (DataText.Text != "Data")
            {
                // TODO: 임시 구분 조건임
                if (SPortNameText.Text != "PortName" && SBaudRateText.Text != "BaudRate")
                {
                    if (serialSender == null) serialSender = new SerialSender(SPortNameText.Text, int.Parse(SBaudRateText.Text), Parity.None, 8, StopBits.One);
                    if(!serialSender.isOpen()) serialSender.Open();
                    serialSender.Send(DataText.Text);
                }
            }
        }

        private void ReceiveButton_Click(object sender, EventArgs e)
        {
            // TODO: 임시 구분 조건임
            if (SPortNameText.Text != "PortName" && SBaudRateText.Text != "BaudRate")
            {
                if (serialReceiver == null) serialReceiver = new SerialReceiver(SPortNameText.Text, int.Parse(SBaudRateText.Text), Parity.None, 8, StopBits.One);
                if (!serialReceiver.isOpen())
                {
                    serialReceiver.DataReceived += SerialReceiver_DataReceived;
                    serialReceiver.Open();
                }
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
            TextBox.AppendText(receivedData + Environment.NewLine);
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            // TODO: 임시 구분 조건임
            if (SPortNameText.Text != "PortName" && SBaudRateText.Text != "BaudRate")
            {
                if (serialSender == null) serialSender = new SerialSender(SPortNameText.Text, int.Parse(SBaudRateText.Text), Parity.None, 8, StopBits.One);
                if (!serialSender.isOpen())  serialSender.Open();
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (serialSender != null && serialSender.isOpen())
            {
                serialSender.Close();
            }
            if (serialReceiver != null && serialReceiver.isOpen())
            {
                serialReceiver.Close();
            } 
        }
    }
}
