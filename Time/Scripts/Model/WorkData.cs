using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Time.Model
{
    public class WorkData : INotifyPropertyChanged
    {
        public WorkData()
        {
            if(Date == null)
            {
                Date = $"Date: {DateTime.Now.ToShortDateString()}";
            }
        }
        #region Date
        private string date;
        public string Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        #endregion

        #region CurrentTime
        private double currentTime;
        public double CurrentTime
        {
            get { return currentTime; }
            set
            {
                currentTime = value;
                OnPropertyChanged("CurrentTime");
            }
        }
        #endregion

        #region RequiredTime
        private int requiredTime;
        public int RequiredTime
        {
            get { return requiredTime; }
            set
            {
                requiredTime = value;
                OnPropertyChanged("RequiredTime");
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
    }
}
