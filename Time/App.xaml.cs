using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Time.Scripts.ViewModel;

namespace Time
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AppViewModel MainVM { get; set; }
        public static SettingsViewModel SettingsVM { get; set; }

        static App()
        {
            MainVM = new AppViewModel();
            SettingsVM = new SettingsViewModel();
        }
    }
}
