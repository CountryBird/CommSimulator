﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    internal class TCP_Server
    {
        TcpListener tcpListener;
        ConcurrentDictionary<string,TcpClient> connectedClients = new ConcurrentDictionary<string,TcpClient>();
        // 연결된 클라이언트

        public event Action<string>? ClientConnected; // 클라이언트 연결
        public event Action<string>? ClientDisconnected; // 클라이언트 연결 해제

        public event Action<string, string>? DataReceived; // 데이터 수신

        public TCP_Server(IPAddress iPAddress, int port)
        {
            tcpListener = new TcpListener(iPAddress, port);
        }

        public async Task Connect()
        {
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                IPEndPoint? ipEndPoint = tcpClient.Client.RemoteEndPoint as IPEndPoint;
                if (ipEndPoint != null)
                {
                    string remoteEndPoint = ipEndPoint.Address.ToString();
                    ClientConnected?.Invoke(remoteEndPoint);
                    connectedClients.TryAdd(remoteEndPoint, tcpClient);

                    _ = TCPServer_DataReceivedAsync(tcpClient);
                }
            }
        }

        public void DisConnect()
        {
            foreach (var client in connectedClients.ToList())
            {
                string clientIP = client.Key;
                TcpClient tcpClient = client.Value;

                if (tcpClient != null && tcpClient.Connected)
                {
                    tcpClient.Close();
                    tcpClient.Dispose();
                    connectedClients.TryRemove(clientIP, out _);
                }
            }
        }

        public async Task Send(string data)
        {
            foreach (var client in connectedClients.ToList())
            {
                string clientIP = client.Key;
                TcpClient tcpClient = client.Value;
                
                if (tcpClient != null && tcpClient.Connected)
                {
                    NetworkStream stream = tcpClient.GetStream();

                    byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                    await stream.WriteAsync(dataBytes, 0, dataBytes.Length);
                }
            }
        }

        public bool IsConnected()
        {
            if (connectedClients.IsEmpty) return false;

            foreach(var client in connectedClients.ToList())
            {
                if (!client.Value.Connected) return false;
            }
            return true;
        }

        private async Task TCPServer_DataReceivedAsync(TcpClient tcpClient)
        {
            NetworkStream stream = tcpClient.GetStream();
            byte[] buffer = new byte[1024];
            int byteRead;

            while ((byteRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string receivedMessage = Encoding.UTF8.GetString(buffer,0,byteRead);
                IPEndPoint? iPEndPoint = tcpClient.Client.RemoteEndPoint as IPEndPoint;
                if (iPEndPoint != null)
                {
                    string remoteEndPoint = iPEndPoint.Address.ToString();
                    DataReceived?.Invoke(remoteEndPoint, receivedMessage);
                }
            }
        }
    }
}
