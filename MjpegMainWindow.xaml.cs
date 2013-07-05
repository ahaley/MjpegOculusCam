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
using MjpegProcessor;

namespace CLEyeMulticamWPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MjpegMainWindow : Window
    {
        MjpegDecoder mjpegDecoder;

        public MjpegMainWindow()
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
            mjpegDecoder.StopStream();
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            mjpegDecoder = new MjpegDecoder();
            camLeft.SetDecoder(mjpegDecoder);
            camRight.SetDecoder(mjpegDecoder);
            mjpegDecoder.ParseStream(new Uri("http://192.168.1.12:8080/?action=stream"));
        }

        int curdist = 0; 

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            curdist += 20;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            curdist -= 20;
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            curdist = (int)slider1.Value;
            lbldist1.Content = ((int)slider1.Value).ToString(); 
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            curdist = (int)slider2.Value;
            lbldist2.Content = ((int)slider2.Value).ToString();
        }

        private void slider3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            curdist = (int)slider3.Value;
            lbldist3.Content = ((int)slider3.Value).ToString();
        }
    }
}
