using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Time.Scripts.ViewModel
{
    public class SettingsViewModel: INotifyPropertyChanged
    {

        #region Constructor
        public SettingsViewModel()
        { 
            //initalize default value
            fontFamily = new FontFamily("Courier New");
            TimeLimit = Properties.Settings.Default.TimeLimit;
        }
        #endregion

        #region Commands
        #region CloseCommand
        public Action CloseAction { get; set; }
        private RelayCommand closeCommand;
        public RelayCommand CloseCommand
        {
            get
            {
                Properties.Settings.Default.TimeLimit = TimeLimit;
                Properties.Settings.Default.Save();
                return closeCommand ?? (closeCommand = new RelayCommand(obj =>
                {
                    Properties.Settings.Default.TimeLimit = TimeLimit;
                    Properties.Settings.Default.Save();
                    CloseAction();
                }));
            }
        }
        #endregion

        #endregion

        #region Properties
        #region FontFamily
        private FontFamily fontFamily;
        public FontFamily FontFamily
        {
            get { return fontFamily; }
            set
            {
                fontFamily = value;
                OnPropertyChanged("FontFamily");
            }
        }
        #endregion

        #region TimeLimit
        private string timeLimit;
        public string TimeLimit
        {
            get { return timeLimit; }
            set
            {
                timeLimit = value;
                try
                {
                    if (Convert.ToInt32(TimeLimit) > 1440)
                        timeLimit = "1440";
                }
                catch (FormatException) { }
                OnPropertyChanged("TimeLimit");
            }
        }
        #endregion

        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
        #endregion
    }
}
