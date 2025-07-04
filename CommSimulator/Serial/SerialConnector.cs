using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Serial
{
    internal class SerialConnector
    {
        SerialPort serialPort;
        public delegate void DataReceivedHandler(object sender, string receivedData);
        public event DataReceivedHandler? DataReceived;
        public SerialConnector(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            serialPort.DataReceived += SerialPort_DataReceived;
        }
        public bool IsOpen()
        {
            return serialPort.IsOpen;
        }
        public void Open()
        {
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }
        }
        public void Close()
        {
            serialPort.Close();
            serialPort.Dispose();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadExisting();

            if (DataReceived != null) DataReceived(this, data);
        }
        public void Send(string data)
        {
            serialPort.Write(data);
        }
    }
}
