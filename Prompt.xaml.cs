using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CLEyeMulticamWPFTest
{
    /// <summary>
    /// Interaction logic for Prompt.xaml
    /// </summary>
    public partial class Prompt : Window
    {
        public Prompt()
        {
            InitializeComponent();
        }

        private void mjpegConnectButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new MjpegMainWindow() {
                LeftAddress = leftAddressTextBox.Text,
                RightAddress = rightAddressTextBox.Text
            };

            window.Show();
            this.Close();
        }
    }
}
