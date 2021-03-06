﻿using GalaSoft.MvvmLight.Messaging;
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
using Time.Model;
using Time.Scripts;
using Time.Scripts.View;
using Time.Scripts.ViewModel;

namespace Time
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            XML xml = new XML();
            xml.Deserialize();
            InitializeComponent();
            App.MainVM.CloseAction = new Action(this.Close);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "OpenSettingsWindow")
            {
                OptionsWindow optionsWindow = new OptionsWindow();
                optionsWindow.ShowDialog();
            }
            else if(msg.Notification == "OpenResultWindow")
            {
                ResultWindow resultWindow = new ResultWindow() { Topmost = true };
                resultWindow.Owner = this;
                resultWindow.ShowDialog();
            }
        }
    }
}
