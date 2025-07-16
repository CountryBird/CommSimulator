using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP
{
    internal class UDP_Transceiver
    {
        UdpClient udpClient;
        bool connected; // 통신 대기 상태를 의미함 (UDP는 연결 개념 X)

        public event Action<string,string>? DataReceived;
        public UDP_Transceiver() 
        {
            udpClient = new UdpClient();
        }
        public UDP_Transceiver(IPAddress iPAddress, int port)
        {
            udpClient = new UdpClient(new IPEndPoint(iPAddress, port));
        }

        public async Task Connect()
        {
            connected = true;

            try
            {
                while (true)
                {
                    UdpReceiveResult udpReceiveResult = await udpClient.ReceiveAsync();

                    IPEndPoint remoteEndPoint = udpReceiveResult.RemoteEndPoint;
                    byte[] dataBytes = udpReceiveResult.Buffer;
                    string data = Encoding.UTF8.GetString(dataBytes);

                    DataReceived?.Invoke(remoteEndPoint.Address.ToString(), data);
                }
            }
            catch (SocketException) { } // UDP 통신 대기 상태 정지
        }

        public void Disconnect()
        {
            udpClient.Close();
        }

        public bool isConnected()
        {
            return connected;
        }

        public async Task Send(IPAddress iPAddress, int port, string data)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, port);

            await udpClient.SendAsync(dataBytes, dataBytes.Length, iPEndPoint);
        }
    }
}
