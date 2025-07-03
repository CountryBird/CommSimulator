using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Serial
{
    internal class SerialSender
    {
        SerialPort serialPort;

        public SerialSender(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
        }
        public void Send(string data)
        {
            serialPort.Write(data);
        }
    }
}
