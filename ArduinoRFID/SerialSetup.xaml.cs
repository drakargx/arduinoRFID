using System;
using System.Collections.Generic;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO.Ports;

namespace ArduinoRFID
{
    /// <summary>
    /// Interaction logic for SerialSetup.xaml
    /// </summary>
    public partial class SerialSetup : Window
    {
        private ObservableCollection<string> COMPorts = new ObservableCollection<string>(SerialManager.Instance.PortNames);
        private List<int> BaudRates, DataBits;
        private List<Parity> Parities;
        private List<StopBits> StopBit;
        private List<Handshake> Handshakes;
        private SerialManager Serial = SerialManager.Instance;

        public SerialSetup()
        {
            InitializeComponent();
            CmbSerialPorts.ItemsSource = COMPorts;

            //Create the lists of available serial options and assign the comboboxes to the sources.
            //Arduino uses 8 data bits, no parity, 1 stopbit by default.

            BaudRates = new List<int> { 9600, 115200};
            CmbBaudRate.ItemsSource = BaudRates;
            CmbBaudRate.SelectedIndex = 0;

            DataBits = new List<int> { 8 };
            CmbDataBits.ItemsSource = DataBits;
            CmbDataBits.SelectedIndex = 0;

            Parities = new List<Parity> { Parity.None, Parity.Odd, Parity.Even, Parity.Mark, Parity.Space };
            CmbParity.ItemsSource = Parities;
            CmbParity.SelectedIndex = 0;

            StopBit = new List<StopBits> { StopBits.None, StopBits.One, StopBits.OnePointFive, StopBits.Two };
            CmbStopBits.ItemsSource = StopBit;
            CmbStopBits.SelectedIndex = 1; //Select the index with one stopbit

            Handshakes = new List<Handshake> { Handshake.None, Handshake.RequestToSend, Handshake.RequestToSendXOnXOff, Handshake.XOnXOff };
            CmbHandshake.ItemsSource = Handshakes;
            CmbHandshake.SelectedIndex = 0;
        }

        //Open the SerialPort with the parameters the user specified in this window
        private void Event_ConnectSerial(object sender, RoutedEventArgs e)
        {
            Serial.OpenSerialPort((string)CmbSerialPorts.SelectedValue, (int)CmbBaudRate.SelectedValue, (Parity)CmbParity.SelectedValue,
                (int)CmbDataBits.SelectedValue, (StopBits)CmbStopBits.SelectedValue, (Handshake)CmbHandshake.SelectedValue);
            this.Close();
        }
    }
}
