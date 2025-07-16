using Serial;
using System.Diagnostics;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using TCP;
using UDP;

namespace CommSimulator
{
    public partial class MainForm : Form
    {
        Serial_Connector? serialConnector;
        TCP_Server? tcp_Server;
        TCP_Client? tcp_Client;
        UDP_Transceiver? udp_Transceiver;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void SendButton_Click(object sender, EventArgs e)
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
                    if (tcp_Server == null) tcp_Server = new TCP_Server(IPAddress.Parse(TCPIPAddressText.Text), int.Parse(TCPPortText.Text));
                    if (!tcp_Server.IsConnected()) MessageBox.Show("Send �۾� ������ Connect�� �ʿ��մϴ�.");

                    else
                    {
                        await tcp_Server.Send(DataText.Text);
                        UpdateTextBox($"[S] [{TCPIPAddressText.Text}] " + DataText.Text);
                    }
                }
                else if (TCPComboBox.Text == "Client")
                {
                    if (tcp_Client == null) tcp_Client = new TCP_Client();
                    if (!tcp_Client.IsConnected()) MessageBox.Show("Send �۾� ������ Connect�� �ʿ��մϴ�.");

                    else
                    {
                        await tcp_Client.Send(DataText.Text);
                        UpdateTextBox($"[S] [{tcp_Client.GetLocalIPAddress()}] " + DataText.Text);
                    }
                }
            }
            else if (UDPCheckBox.Checked) // UDP
            {
                if (udp_Transceiver == null) udp_Transceiver = new UDP_Transceiver();
                await udp_Transceiver.Send(IPAddress.Parse(UDPIPAddressText.Text),int.Parse(UDPPortText.Text),DataText.Text);
                UpdateTextBox($"[S] [{UDPIPAddressText.Text}] "+DataText.Text);
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
            else if (TCPCheckBox.Checked) // TCP
            {
                if (TCPComboBox.Text == "Server")
                {
                    // TODO: IP �ּҳ� port �Է� �ȵǴ� ��� �߰�
                    if (tcp_Server == null) tcp_Server = new TCP_Server(IPAddress.Parse(TCPIPAddressText.Text), int.Parse(TCPPortText.Text));
                    tcp_Server.DataReceived += Tcp_DataReceived;
                    tcp_Server.ClientConnected += Tcp_Connected;
                    tcp_Server.ClientDisconnected += Tcp_Disconnected;
                    tcp_Server.ServerDisconnected += Tcp_Disconnected;
                    await tcp_Server.Connect();
                }
                else if (TCPComboBox.Text == "Client")
                {
                    try
                    {
                        if (tcp_Client == null) tcp_Client = new TCP_Client();
                        tcp_Client.DataReceived += Tcp_DataReceived;
                        tcp_Client.ServerConnected += Tcp_Connected;
                        tcp_Client.ServerDisconnected += Tcp_Client_ServerDisconnected;
                        tcp_Client.ClientDisconnected += Tcp_Disconnected;
                        await tcp_Client.Connect(IPAddress.Parse(TCPIPAddressText.Text), int.Parse(TCPPortText.Text));
                    }
                    catch (SocketException)
                    {
                        MessageBox.Show("�ش� �ּҷ� ������ �� �����ϴ�.");
                    }
                }
            }
            else if (UDPCheckBox.Checked) // UDP
            {
                // TODO: IP �ּҳ� port �Է� �ȵǴ� ��� �߰�
                if (udp_Transceiver == null) udp_Transceiver = new UDP_Transceiver(IPAddress.Parse(UDPIPAddressText.Text),int.Parse(UDPPortText.Text));
                udp_Transceiver.DataReceived += Udp_DataReceived;
                await udp_Transceiver.Connect();
            }
        }

        private void Tcp_Connected(string remoteEndPoint)
        {
            UpdateTextBox($"[{remoteEndPoint}]�� �����");
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
            else if (TCPCheckBox.Checked) // TCP
            {
                if(TCPComboBox.Text == "Server" && tcp_Server != null && tcp_Server.IsConnected())
                {
                    tcp_Server.DisConnect();
                    tcp_Server = null;
                }
                if(TCPComboBox.Text == "Client" && tcp_Client != null && tcp_Client.IsConnected())
                {
                    tcp_Client.Disconnect();
                    tcp_Client = null;
                }
            }
            else if (UDPCheckBox.Checked) // UDP
            {
                if(udp_Transceiver != null)
                {
                    udp_Transceiver.Disconnect();
                    udp_Transceiver = null;
                }
            }
        }

        private void Tcp_Disconnected(string remoteEndPoint)
        {
            UpdateTextBox($"[{remoteEndPoint}]���� ���� ����");
        }
        private void Tcp_Client_ServerDisconnected(string remoteEndPoint)  // ������ ������ ���� ���, Ŭ���̾�Ʈ�� ������ ���� ���� ��ü������ ���� ����
        {
            if(tcp_Client != null) tcp_Client.Disconnect();
            tcp_Client = null;
        }

        private void SerialConnector_DataReceived(string receivedData)
        {
            UpdateTextBox("[R] "+ receivedData);
        }
        private void Tcp_DataReceived(string remoteEndPoint, string receivedData)
        {
            UpdateTextBox($"[R] [{remoteEndPoint}] {receivedData}");
        }

        private void Udp_DataReceived(string remoteEndPoint, string receivedData)
        {
            UpdateTextBox($"[R] [{remoteEndPoint}] {receivedData}");
        }

        private void UpdateTextBox(string data)
        {
            if (TextBox.InvokeRequired)
            {
                TextBox.Invoke(new Action(() =>
                    TextBox.AppendText(data + Environment.NewLine)));
            }
            else
                TextBox.AppendText(data + Environment.NewLine);
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
