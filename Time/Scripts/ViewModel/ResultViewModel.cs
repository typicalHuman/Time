using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Time.Scripts.Model;

namespace Time.Scripts.ViewModel
{
    public class ResultViewModel : INotifyPropertyChanged
    {

        #region Constructor
        public ResultViewModel()
        {
            fontFamily = new FontFamily("Courier New");
            ResultData = new ResultData();
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
                return closeCommand ?? (closeCommand = new RelayCommand(obj =>
                {
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

        #region ResultData
        private ResultData resultData;
        public ResultData ResultData
        {
            get { return resultData; }
            set
            {
                resultData = value;
                OnPropertyChanged("ResultData");
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
