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
                                MessageBox.Show("Send 작업 이전에 Connect가 필요합니다.");
                            }
                            else
                            {
                                serialConnector.Send(DataText.Text);
                                TextBox.AppendText("[S] " + DataText.Text + Environment.NewLine);
                            }
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("해당 COM 포트가 연결되어 있지 않습니다.");
                        }
                    }
                }
            else if (TCPCheckBox.Checked) // TCP
            {
                if(TCPComboBox.Text == "Server")
                {
                    if (tcp_Server == null) tcp_Server = new TCP_Server(IPAddress.Parse(TCPIPAddressText.Text), int.Parse(TCPPortText.Text));
                    if (!tcp_Server.IsConnected()) MessageBox.Show("Send 작업 이전에 Connect가 필요합니다.");

                    else
                    {
                        await tcp_Server.Send(DataText.Text);
                        UpdateTextBox($"[S] [{TCPIPAddressText.Text}] " + DataText.Text);
                    }
                }
                else if (TCPComboBox.Text == "Client")
                {
                    if (tcp_Client == null) tcp_Client = new TCP_Client();
                    if (!tcp_Client.IsConnected()) MessageBox.Show("Send 작업 이전에 Connect가 필요합니다.");

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
                        MessageBox.Show("해당 COM 포트가 연결되어 있지 않습니다.");
                    }
                }
            }
            else if (TCPCheckBox.Checked) // TCP
            {
                if (TCPComboBox.Text == "Server")
                {
                    // TODO: IP 주소나 port 입력 안되는 경우 추가
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
                        MessageBox.Show("해당 주소로 연결할 수 없습니다.");
                    }
                }
            }
            else if (UDPCheckBox.Checked) // UDP
            {
                // TODO: IP 주소나 port 입력 안되는 경우 추가
                if (udp_Transceiver == null) udp_Transceiver = new UDP_Transceiver(IPAddress.Parse(UDPIPAddressText.Text),int.Parse(UDPPortText.Text));
                udp_Transceiver.DataReceived += Udp_DataReceived;
                await udp_Transceiver.Connect();
            }
        }

        private void Tcp_Connected(string remoteEndPoint)
        {
            UpdateTextBox($"[{remoteEndPoint}]에 연결됨");
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
            UpdateTextBox($"[{remoteEndPoint}]와의 연결 해제");
        }
        private void Tcp_Client_ServerDisconnected(string remoteEndPoint)  // 서버가 연결을 끊는 경우, 클라이언트는 연결할 곳이 없어 자체적으로 연결 해제
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
            if (!Regex.IsMatch(portName,@"^COM\d+$")) // COM으로 시작하고 숫자로 긑남
            {
                MessageBox.Show("PortName이 Serial Port 양식에 맞지 않습니다.");
                return false;
            }
            else if (!int.TryParse(baudRate, out _))
            {
                MessageBox.Show("BaudRate는 정수로 구성되어야 합니다.");
                return false;
            }
            return true;
        }
    }
}
