using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Serial
{
    internal class Serial_Connector
    {
        SerialPort serialPort;
        
        public event Action<string>? DataReceived; // 데이터 수신
        public Serial_Connector(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            serialPort.DataReceived += SerialPort_DataReceived;
        }
        public bool IsOpen()
        {
            return serialPort.IsOpen;
        }
        public void Connect()
        {
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }
        }
        public void DisConnect()
        {
            serialPort.Close();
            serialPort.Dispose();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadExisting();

            DataReceived?.Invoke(data);
        }
        public void Send(string data)
        {
            serialPort.Write(data);
        }
    }
}
