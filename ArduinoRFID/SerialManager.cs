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

        public string CurrentPortName
        {
            get { return _serialPort.PortName; }
        }
        
    }
}
