using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    internal class TCP_Client
    {
        TcpClient tcpClient;
        NetworkStream? networkStream;
        public event Action<string>? ServerConnected;
        public event Action<string,string>? DataReceived;

        public TCP_Client()
        {
            tcpClient = new TcpClient();
        }
        public async Task Connect(IPAddress iPAddress,int port)
        {
            await tcpClient.ConnectAsync(iPAddress, port);
            networkStream = tcpClient.GetStream();
            ServerConnected?.Invoke(iPAddress.ToString());

            _ = TCPClient_DataReceivedAsync();
        }

        public bool IsConnected()
        {
            return tcpClient.Connected;
        }

        public string GetRemoteIPAddress()
        {
            IPEndPoint? iPEndPoint = tcpClient.Client.RemoteEndPoint as IPEndPoint;
            if(iPEndPoint != null)
            {
                return iPEndPoint.Address.MapToIPv4().ToString();
            }
            return "0.0.0.0";
        }
        public string GetLocalIPAddress()
        {
            IPEndPoint? iPEndPoint = tcpClient.Client.LocalEndPoint as IPEndPoint;
            if (iPEndPoint != null)
            {
                return iPEndPoint.Address.MapToIPv4().ToString();
            }
            return "0.0.0.0";
        }

        private async Task TCPClient_DataReceivedAsync()
        {
            if (networkStream == null) return;

            byte[] buffer = new byte[1024];
            int bytesRead;

            while(tcpClient.Connected && (bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string receivedMessage = Encoding.UTF8.GetString(buffer,0,bytesRead);
                string remoteEndPoint = GetRemoteIPAddress();
                DataReceived?.Invoke(remoteEndPoint, receivedMessage);
            }
        }

        public async Task Send(string data)
        {
            if(networkStream == null) return;

            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            await networkStream.WriteAsync(dataBytes,0, dataBytes.Length);
        }
    }
}
