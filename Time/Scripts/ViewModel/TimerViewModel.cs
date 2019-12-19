using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using Time;
using Time.Scripts.ViewModel;

public class TimerViewModel : INotifyPropertyChanged
{
    #region Constructor
    public TimerViewModel()
    {
        isStart = false;
        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMilliseconds(1000);
        timer.Tick += Tick;
    }
    #endregion

    #region Properties

    #region DispatcherTimer
    private DispatcherTimer timer { get; set; }
    #endregion

    #region IsStart
    private bool isStart;
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

    #region MinutesCount
    private int seconds { get; set; }
    public int Minutes
    {
        get { return seconds % 60; }
        set
        {
            seconds = value;
            OnPropertyChanged("Minutes");
        }
    }
    #endregion

    #region IsEnabled
    public bool IsEnabled
    {
        get { return App.MainVM.IsEnabled; }
        set
        {
            App.MainVM.IsEnabled = value;
            OnPropertyChanged("IsEnabled");
        }
    }
    #endregion

    #region Percent
    private int percent;
    public int Percent
    {
        get 
        {
            double percent1 = Convert.ToDouble(App.MainVM.SelectedData.RequiredTime * 60) / 100;
            return percent = Convert.ToInt32(seconds / percent1); 
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
        Percent = Percent;
        double procSec = 1.0 / 60.0;
        App.MainVM.SelectedData.CurrentTime = seconds * procSec;
    }
    #endregion

}



