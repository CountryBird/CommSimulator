using Serial;
using System.Diagnostics;
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace CommSimulator
{
    public partial class MainForm : Form
    {
        SerialConnector? serialConnector;
        public MainForm()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            // TODO: �ӽ� ���� ������
            if (DataText.Text != "Data")
            {
                if(CheckSerialCondition(SPortNameText.Text,SBaudRateText.Text)) 
                {
                    try
                    {
                        if (serialConnector == null) serialConnector = new SerialConnector(SPortNameText.Text, int.Parse(SBaudRateText.Text), Parity.None, 8, StopBits.One);
                        if (!serialConnector.IsOpen()) serialConnector.Open();
                        serialConnector.Send(DataText.Text);
                        TextBox.AppendText("[S] " + DataText.Text + Environment.NewLine);
                    }
                    catch(IOException)
                    {
                        MessageBox.Show("�ش� COM ��Ʈ�� ����Ǿ� ���� �ʽ��ϴ�.");
                    }
                }
            }
        }
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (CheckSerialCondition(SPortNameText.Text, SBaudRateText.Text))
            {
                try
                {
                    if (serialConnector == null) serialConnector = new SerialConnector(SPortNameText.Text, int.Parse(SBaudRateText.Text), Parity.None, 8, StopBits.One);
                    if (!serialConnector.IsOpen())
                    {
                        serialConnector.DataReceived += SerialReceiver_DataReceived;
                        serialConnector.Open();
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("�ش� COM ��Ʈ�� ����Ǿ� ���� �ʽ��ϴ�.");
                }
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (serialConnector != null && serialConnector.IsOpen())
            {
                serialConnector.Close();
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
            TextBox.AppendText("[R] "+ receivedData + Environment.NewLine);
        }

        private bool CheckSerialCondition(string portName, string baudRate)
        {
            if (!Regex.IsMatch(portName,@"^COM\d+$")) // COM���� �����ϰ� ���ڷ� �P��
            {
                MessageBox.Show("PortName�� Serial Port ��Ŀ� ���� �ʽ��ϴ�.");
                return false;
            }
            else if (!int.TryParse(baudRate, out _))
            {
                MessageBox.Show("BaudRate�� ������ �����Ǿ�� �մϴ�.");
                return false;
            }
            return true;
        }
    }
}
