using Serial;
using System.Diagnostics;
using System.IO.Ports;
using System.Net;
using System.Text.RegularExpressions;
using TCP;

namespace CommSimulator
{
    public partial class MainForm : Form
    {
        Serial_Connector? serialConnector;
        TCP_Server? tcp_Server;
        TCP_Client? tcp_Client;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            // TODO: �ӽ� ���� ������
            if (DataText.Text != "Data")
            {
                if (SerialCheckBox.Checked) // Serial
                {
                    if (CheckSerialCondition(PortNameText.Text, BaudRateText.Text))
                    {
                        try
                        {
                            if (serialConnector == null) serialConnector = new Serial_Connector(PortNameText.Text, int.Parse(BaudRateText.Text), Parity.None, 8, StopBits.One);
                            if (!serialConnector.IsOpen())
                            {
                                MessageBox.Show("Send �۾� ������ Connect�� �ʿ��մϴ�.");
                            }
                            else
                            {
                                serialConnector.Send(DataText.Text);
                                TextBox.AppendText("[S] " + DataText.Text + Environment.NewLine);
                            }
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("�ش� COM ��Ʈ�� ����Ǿ� ���� �ʽ��ϴ�.");
                        }
                    }
                }
                else if (TCPCheckBox.Checked) // TCP
                {
                    if(TCPComboBox.Text == "Server")
                    {
                        if (tcp_Server == null) tcp_Server = new TCP_Server(IPAddress.Parse(IPAddressText.Text), int.Parse(PortText.Text));
                        if (!tcp_Server.IsConnected()) MessageBox.Show("Send �۾� ������ Connect�� �ʿ��մϴ�.");

                        else
                        {
                            await tcp_Server.Send(DataText.Text);
                            TextBox.AppendText($"[S] [{IPAddressText.Text}] " + DataText.Text + Environment.NewLine);
                        }
                    }
                    else if (TCPComboBox.Text == "Client")
                    {
                        if (tcp_Client == null) tcp_Client = new TCP_Client();
                        if (!tcp_Client.IsConnected()) MessageBox.Show("Send �۾� ������ Connect�� �ʿ��մϴ�.");

                        else
                        {
                            await tcp_Client.Send(DataText.Text);
                            TextBox.AppendText($"[S] [{tcp_Client.GetLocalIPAddress()}]" + DataText.Text + Environment.NewLine);
                        }
                    }
                }
            }
        }
        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            if (SerialCheckBox.Checked) // Serial
            {
                if (CheckSerialCondition(PortNameText.Text, BaudRateText.Text))
                {
                    try
                    {
                        if (serialConnector == null) serialConnector = new Serial_Connector(PortNameText.Text, int.Parse(BaudRateText.Text), Parity.None, 8, StopBits.One);
                        if (!serialConnector.IsOpen())
                        {
                            serialConnector.DataReceived += SerialConnector_DataReceived;
                            serialConnector.Connect();
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("�ش� COM ��Ʈ�� ����Ǿ� ���� �ʽ��ϴ�.");
                    }
                }
            }
            else if (TCPCheckBox.Checked)
            {
                if(TCPComboBox.Text == "Server")
                {
                    if(tcp_Server == null) tcp_Server = new TCP_Server(IPAddress.Parse(IPAddressText.Text),int.Parse(PortText.Text));
                    tcp_Server.DataReceived += Tcp_DataReceived;
                    await tcp_Server.Connect();
                }
                else if(TCPComboBox.Text == "Client")
                {
                    if (tcp_Client == null) tcp_Client = new TCP_Client();
                    tcp_Client.DataReceived += Tcp_DataReceived;
                    await tcp_Client.Connect(IPAddress.Parse(IPAddressText.Text), int.Parse(PortText.Text));
                }
            }
        }

        private void Tcp_DataReceived(string remoteEndPoint, string receivedData)
        {
            if (TextBox.InvokeRequired)
            {
                TextBox.Invoke(new Action(() =>
                UpdateTextBox($"[{remoteEndPoint}] {receivedData}")));
            }
            UpdateTextBox($"[{remoteEndPoint}] {receivedData}");
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (SerialCheckBox.Checked) // Serial
            {
                if (serialConnector != null && serialConnector.IsOpen())
                {
                    serialConnector.DisConnect();
                }
            }
            else if (TCPCheckBox.Checked)
            {
                if(TCPComboBox.Text == "Server" && tcp_Server != null && tcp_Server.IsConnected())
                {
                    tcp_Server.DisConnect();
                }
            }
        }

        private void SerialConnector_DataReceived(string receivedData)
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
