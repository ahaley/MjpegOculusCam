//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// This file is part of CL-EyeMulticam SDK
//
// WPF C# CLEyeMulticamWPFTest Sample Application
//
// It allows the use of multiple CL-Eye cameras in your own applications
//
// For updates and file downloads go to: http://codelaboratories.com
//
// Copyright 2008-2012 (c) Code Laboratories, Inc. All rights reserved.
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Interop;
using CLEyeMulticam;

namespace CLEyeMulticamWPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numCameras = 0;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);

            slider1.Value = 0;
            slider2.Value = 0;
            slider3.Value = 0; 
        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    camLeft.Margin = new Thickness(camLeft.Margin.Left, camLeft.Margin.Top-10,camLeft.Margin.Right,  camLeft.Margin.Bottom+10);
                    break;
                case Key.A:
                    camLeft.Margin = new Thickness(camLeft.Margin.Left-10, camLeft.Margin.Top , camLeft.Margin.Right+10, camLeft.Margin.Bottom);
                    break;
                case Key.S:
                    camLeft.Margin = new Thickness(camLeft.Margin.Left , camLeft.Margin.Top+10, camLeft.Margin.Right, camLeft.Margin.Bottom-10);
                    break;
                case Key.D:
                    camLeft.Margin = new Thickness(camLeft.Margin.Left +10, camLeft.Margin.Top, camLeft.Margin.Right-10, camLeft.Margin.Bottom);
                    break;

                case Key.E:
                    camLeft.Margin = new Thickness(camLeft.Margin.Left, camLeft.Margin.Top - 10, camLeft.Margin.Right, camLeft.Margin.Bottom - 10);
                    camLeft.Margin = new Thickness(camLeft.Margin.Left - 10, camLeft.Margin.Top, camLeft.Margin.Right - 10, camLeft.Margin.Bottom);
                    break;
                case Key.Q:
                    camLeft.Margin = new Thickness(camLeft.Margin.Left, camLeft.Margin.Top + 10, camLeft.Margin.Right, camLeft.Margin.Bottom + 10);
                    camLeft.Margin = new Thickness(camLeft.Margin.Left+10, camLeft.Margin.Top, camLeft.Margin.Right + 10, camLeft.Margin.Bottom);
                    break;


                case Key.T:
                    camRight.Margin = new Thickness(camRight.Margin.Left, camRight.Margin.Top - 10, camRight.Margin.Right, camRight.Margin.Bottom + 10);
                    break;
                case Key.F:
                    camRight.Margin = new Thickness(camRight.Margin.Left - 10, camRight.Margin.Top, camRight.Margin.Right + 10, camRight.Margin.Bottom);
                    break;
                case Key.G:
                    camRight.Margin = new Thickness(camRight.Margin.Left, camRight.Margin.Top + 10, camRight.Margin.Right, camRight.Margin.Bottom - 10);
                    break;
                case Key.H:
                    camRight.Margin = new Thickness(camRight.Margin.Left + 10, camRight.Margin.Top, camRight.Margin.Right - 10, camRight.Margin.Bottom);
                    break;

                case Key.Z:
                    camRight.Margin = new Thickness(camRight.Margin.Left, camRight.Margin.Top - 10, camRight.Margin.Right, camRight.Margin.Bottom - 10);
                    camRight.Margin = new Thickness(camRight.Margin.Left - 10, camRight.Margin.Top, camRight.Margin.Right - 10, camRight.Margin.Bottom);
                    break;
                case Key.R:
                    camRight.Margin = new Thickness(camRight.Margin.Left, camRight.Margin.Top + 10, camRight.Margin.Right, camRight.Margin.Bottom + 10);
                    camRight.Margin = new Thickness(camRight.Margin.Left + 10, camRight.Margin.Top, camRight.Margin.Right + 10, camRight.Margin.Bottom);
                    break;

            }
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (numCameras >= 1)
            {
                camLeft.Device.Stop();
                camLeft.Device.Destroy();
            }
            if (numCameras == 2)
            {
                camRight.Device.Stop();
                camRight.Device.Destroy();
            }
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Query for number of connected cameras
            numCameras = CLEyeCameraDevice.CameraCount;
            if(numCameras == 0)
            {
                MessageBox.Show("Could not find any PS3Eye cameras!");
                return;
            }
            output.Items.Add(string.Format("Found {0} CLEyeCamera devices", numCameras));
            // Show camera's UUIDs
            for (int i = 0; i < numCameras; i++)
            {
                output.Items.Add(string.Format("CLEyeCamera #{0} UUID: {1}", i + 1, CLEyeCameraDevice.CameraUUID(i)));
            }
            // Create cameras, set some parameters and start capture
            if (numCameras >= 1)
            {
                camLeft.Device.Create(CLEyeCameraDevice.CameraUUID(0));
                camLeft.Device.Start();
            }
            if (numCameras == 2)
            {
                camRight.Device.Create(CLEyeCameraDevice.CameraUUID(1));
                camRight.Device.Start();
            }
        }

        int curdist = 0; 

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            curdist += 20;
            camLeft.Device.LensCorrection1 = curdist;
            camRight.Device.LensCorrection2 = curdist;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            curdist -= 20;
            camLeft.Device.LensCorrection1 = curdist;
            camRight.Device.LensCorrection2 = curdist;
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            curdist = (int)slider1.Value;
            lbldist1.Content = ((int)slider1.Value).ToString(); 
            camLeft.Device.LensCorrection1 = curdist;
            camRight.Device.LensCorrection1 = curdist;
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            curdist = (int)slider2.Value;
            lbldist2.Content = ((int)slider2.Value).ToString();
            camLeft.Device.LensCorrection2= curdist;
            camRight.Device.LensCorrection2 = curdist;
        }

        private void slider3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            curdist = (int)slider3.Value;
            lbldist3.Content = ((int)slider3.Value).ToString();
            camLeft.Device.LensCorrection3 = curdist;
            camRight.Device.LensCorrection3 = curdist;
        }
    }
}
