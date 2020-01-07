using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using Time;
using Time.Scripts.ViewModel;
using System.Xml.Serialization;
using Time.Scripts;

public class TimerViewModel : INotifyPropertyChanged
{
    #region Constructor
    public TimerViewModel()
    {
        isStart = false;
        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMilliseconds(1);
        timer.Tick += Tick;
    }
    #endregion

    #region Properties

    #region DispatcherTimer
    private DispatcherTimer timer { get; set; }
    #endregion

    #region IsStart
    private bool isStart;
    [XmlElement]
    public bool IsStart
    {
        get { return isStart; }
        set
        {
            isStart = value;
            OnPropertyChanged("IsStart");
        }
    }
    #endregion

    #region TimeCount
    public int seconds { get; set; }

    private string time;
    [XmlElement]
    public string Time
    {
        get { return time; }
        set
        {
            time = value;
            if(App.MainVM.SelectedData != null)
                App.MainVM.SelectedData.Time = time;
            OnPropertyChanged("Time");
        }
    }
    #endregion

    #region Percent
    private int percent;
    [XmlElement]
    public int Percent
    {
        get 
        {
            return percent;
        }
        set
        {
            percent = value;
            OnPropertyChanged("Percent");
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

    #region Commands

    #region StartCommand
    private RelayCommand startCommand;
    public RelayCommand StartCommand
    {
        get
        {
            return startCommand ?? (startCommand = new RelayCommand(obj =>
            {
                if (IsStart)
                    timer?.Start();
                else
                    timer?.Stop();
            }));
        }
    }
    #endregion

    #endregion

    #region TimeCalculate
    private void Tick(object sender, EventArgs e)
    {
        seconds++;
        if (seconds % 600 == 0)
            new XML().Serialize(App.MainVM.WorkDatas);
        SetPercent();
        SetCurrentTime();
        SetTime();
    }

    private void SetTime()
    {
        Time = GetTime();
    }

    private void SetCurrentTime()
    {
        double procSec = 1.0 / 60.0;
        App.MainVM.SelectedData.CurrentTime = seconds * procSec;
    }

    private void SetPercent()
    {
        double percent1 = Convert.ToDouble(App.MainVM.SelectedData.RequiredTime * 60) / 100;
        Percent = Convert.ToInt32(seconds / percent1);
    }

    private int GetHours(int _seconds)
    {
        if(_seconds >= 3600)
           return _seconds / 3600;
        return 0;
    }

    private int GetMinutes(int _seconds)
    {
        if(_seconds >= 60)
           return _seconds / 60;
        return 0;
    }


    public string GetTime(int seconds)
    {
        int tempSeconds = seconds;
        int _hours = GetHours(tempSeconds);
        int _minutes = GetMinutes(tempSeconds - _hours * 3600);
        int _seconds = tempSeconds - _hours * 3600 - _minutes * 60;
        return $"{GetFullValue(_hours)}:{GetFullValue(_minutes)}:{GetFullValue(_seconds)}";
    }

    private string GetTime()
    {
        int tempSeconds = seconds;
        int _hours = GetHours(tempSeconds);
        int _minutes = GetMinutes(tempSeconds - _hours * 3600);
        int _seconds = tempSeconds - _hours * 3600 - _minutes * 60;
        return $"{GetFullValue(_hours)}:{GetFullValue(_minutes)}:{GetFullValue(_seconds)}";
    }

    private string GetFullValue(int val)
    {
        if (val < 10)
            return $"0{val}";
        return val.ToString();
    }
    #endregion
}