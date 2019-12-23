using GalaSoft.MvvmLight.Messaging;
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
using Time.Scripts.View;
using Time.Scripts.ViewModel;

namespace Time
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
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
                var view2 = new OptionsWindow();
                view2.ShowDialog();
            }
        }
    }
}
