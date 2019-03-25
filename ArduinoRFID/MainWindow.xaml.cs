using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArduinoRFID
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Event_OpenSerialPortSettings(object sender, RoutedEventArgs e)
        {
            SerialSetup SerialWindow = new SerialSetup();
            SerialWindow.Show();
        }

        private async void Event_WriteData(object sender, RoutedEventArgs e)
        {
            
        }

        private async void Event_ReadData(object sender, RoutedEventArgs e)
        {
            Task<string> readResponse = SerialManager.Instance.ReadArduinoResponse();
            await readResponse;
            SerialMonitor.Text = readResponse.Result;
        }
    }
}
