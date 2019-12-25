using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Time.Scripts.Model
{
    public class ResultData : INotifyPropertyChanged
    {
        #region Properties

        #region WeekTime
        public string WeekTime
        {
            get { return new TimerViewModel().GetTime(GetWeekSecondsSum()); }
            set
            {
                OnPropertyChanged("WeekTime");
            }
        }
        #endregion

        #region MonthTime
        private string monthTime;
        public string MonthTime
        {
            get { return monthTime; }
            set
            {
                monthTime = value;
                OnPropertyChanged("MothTime");
            }
        }
        #endregion

        #region YearTime
        private string yearTime;
        public string YearTime
        {
            get { return yearTime; }
            set
            {
                yearTime = value;
                OnPropertyChanged("YearTime");
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

        #region DaysCalculate

        #region WeekCalculate

        private int dayOfWeek { get; set; } = (int)DateTime.Now.DayOfWeek;
        private int today { get; set; } = DateTime.Now.Day;

        private int[] GetWeekScope()
        {
            return new int[] { today - dayOfWeek, today + 7 - dayOfWeek };
        }

        private int GetWeekSecondsSum()
        {
            int sum = 0;
            for (int i = 0; i < App.MainVM.WorkDatas.Count && i < 7; i++)
            {
                string date = App.MainVM.WorkDatas[i].Date;
                if (GetDay(date) >= GetWeekScope()[0] && GetDay(date) <= GetWeekScope()[1])
                    sum += App.MainVM.WorkDatas[i].Timer.seconds;
            }
            return sum;
        }
        #endregion

        #region DateParse
        private int GetDay(string date)
        {
            date = date.Replace("Date: ", "");
            date = date.Remove(2, date.Length - 2);
            return Convert.ToInt32(date);
        }
        #endregion
        #endregion

    }
}
