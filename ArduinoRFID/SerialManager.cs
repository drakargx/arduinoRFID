using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace ArduinoRFID
{
    sealed class SerialManager
    {
        #region Singleton Instantiation
        static SerialManager() { }
        private SerialManager() { }
        public static SerialManager Instance { get; } = new SerialManager();
        private static SerialPort _serialPort = new SerialPort();
        #endregion
        private const int BUFFER_LIMIT = 500;
        private byte[] SerialReadBuffer = new byte[BUFFER_LIMIT];
        private byte[] SerialWriteBuffer = new byte[BUFFER_LIMIT];

        public string CurrentPortName
        {
            get { return _serialPort.PortName; }
        }

        public string[] PortNames
        {
            get { return SerialPort.GetPortNames();  }
        }

        public void OpenSerialPort(string PortName, int BaudRate, Parity Parity, int DataBits, StopBits StopBits, Handshake Handshake)
        {
            _serialPort.PortName = PortName;
            _serialPort.BaudRate = BaudRate;
            _serialPort.Parity = Parity;
            _serialPort.DataBits = DataBits;
            _serialPort.StopBits = StopBits;
            _serialPort.Handshake = Handshake;

            _serialPort.WriteTimeout = 500;
            _serialPort.ReadTimeout = 500;

            _serialPort.Open();
        }

        public async Task<string> ReadArduinoResponse()
        {
            await _serialPort.BaseStream.ReadAsync(SerialReadBuffer, 0, BUFFER_LIMIT);

            return System.Text.Encoding.UTF8.GetString(SerialReadBuffer, 0, SerialReadBuffer.Length);
        }

        public async Task WriteToArduino()
        {
            await _serialPort.BaseStream.WriteAsync(SerialWriteBuffer, 0, 0);
        }
        
    }
}
