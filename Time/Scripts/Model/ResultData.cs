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
        public string MonthTime
        {
            get { return new TimerViewModel().GetTime(GetMonthSecondsSum()); }
            set
            {
                OnPropertyChanged("MothTime");
            }
        }
        #endregion

        #region AllTime
        public string AllTime
        {
            get { return new TimerViewModel().GetTime(GetAllSumSeconds()); }
            set
            {
                OnPropertyChanged("AllTime");
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

        #region MonthCalculate

        private int GetMonthLastDay()
        {
            DateTime now = DateTime.Now;
            int month = 1;
            if (now.Month != 12)
                month = now.Month + 1;
            return new DateTime(now.Year, month, 1).AddDays(-1).Day;
        }

        private int GetMonthSecondsSum()
        {
            int sum = 0;
            int currentMonth = DateTime.Now.Month;
            int lastMonthDay =  GetMonthLastDay();
            for (int i = 0; i < App.MainVM.WorkDatas.Count && i < lastMonthDay; i++)
            {
                string date = App.MainVM.WorkDatas[i].Date;
                if (GetDay(date) <= lastMonthDay && GetMonth(date) == currentMonth)
                    sum += App.MainVM.WorkDatas[i].Timer.seconds;
            }
            return sum;
        }

        #endregion

        #region AllTime

        private int GetAllSumSeconds()
        {
            int sum = 0;
            for(int i = 0; i < App.MainVM.WorkDatas.Count; i++)
            {
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
            return int.Parse(date);
        }

        private int GetMonth(string date)
        {
            date = date.Replace("Date: ", "");
            date = date.Remove(0, 3);
            date = date.Remove(2, date.Length - 2);
            return int.Parse(date);
        }
        #endregion

        #endregion

    }
}
