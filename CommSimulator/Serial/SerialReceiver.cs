using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;

namespace Serial
{
    internal class SerialReceiver
    {
        SerialPort serialPort;
        public delegate void DataReceivedHandler(object sender, string receivedData);
        public event DataReceivedHandler DataReceived;
        public SerialReceiver(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        { 
            serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Open();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadExisting();

            DataReceived(this,data);
        }

        public void Open()
        {
            try
            {
                serialPort.Open();
                Console.WriteLine($"COM 포트 {serialPort.PortName} 열림");
                Console.WriteLine($"BaudRate: {serialPort.BaudRate}");
            }
            catch(Exception ex )
            {
                Console.WriteLine($"오류: {ex.Message}");
            }
            finally
            {

            }
        }


    }
}
