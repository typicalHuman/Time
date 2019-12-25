using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Time.Model
{
    [Serializable]
    public class WorkData : INotifyPropertyChanged
    {
        public WorkData()
        {
            if(Date == null)
            {
                Date = $"Date: {DateTime.Now.ToShortDateString()}";
                Timer = new global::TimerViewModel();
            }
        }

        #region Date
        private string date;
        [XmlElement]
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
        [XmlElement]
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
        [XmlElement]
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

        #region Time
        private string time;
        [XmlElement]
        public string Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }
        #endregion

        private TimerViewModel timer;
        [XmlElement]
        public TimerViewModel Timer
        {
            get { return timer; }
            set
            {
                timer = value;
                OnPropertyChanged("Timer");
            }
        }

        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
