using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Time.Model;

namespace Time.Scripts.ViewModel
{
    public class AppViewModel: ViewModelBase, INotifyPropertyChanged
    {
        #region Constructor
        public AppViewModel()
        {
            //initalize default value
            WindowBorderThickness = new Thickness(1);
            fontFamily = new FontFamily("Courier New");
            WorkDatas = new ObservableCollection<WorkData>();
            OpenSettingsWindowCommand = new RelayCommand(obj => OpenSettingsWindowCommandExecute());
            ResizeMode = ResizeMode.CanResizeWithGrip;
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
                return closeCommand ?? (closeCommand = new RelayCommand(obj => CloseAction()));
            }
        }
        #endregion

        #region MaximizeCommand
        private RelayCommand maximizeCommand;
        public RelayCommand MaximizeCommand
        {
            get
            {
                return maximizeCommand ?? (maximizeCommand = new RelayCommand(obj =>
                {
                    if (WindowState == WindowState.Normal)
                    {
                        //setting border no style
                        WindowBorderThickness = new Thickness(0);
                        ResizeMode = ResizeMode.NoResize;
                        WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        //setting border to resize with grip
                        WindowBorderThickness = new Thickness(1);
                        ResizeMode = ResizeMode.CanResizeWithGrip;
                        WindowState = WindowState.Normal;
                    }
                }));
            }
        }
        #endregion

        #region MinimizeCommand
        private RelayCommand minimizeCommand;
        public RelayCommand MinimizeCommand
        {
            get
            {
                return minimizeCommand ?? (minimizeCommand = new RelayCommand(obj =>
                {
                    WindowState = WindowState.Minimized;
                }));
            }
        }
        #endregion

        #region AddCommand
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                {
                    if (IsWorkToday())
                    {
                        WorkData data = new WorkData();
                        WorkDatas.Insert(0, data);
                        SelectedData = data;
                        SelectedData.RequiredTime = int.Parse(Properties.Settings.Default.TimeLimit);
                        App.TimerVM.IsEnabled = true;
                    }
                }));
            }
        }
        private bool IsWorkToday()
        {
            if(WorkDatas.Count > 0)
               return WorkDatas[WorkDatas.Count - 1].Date != new WorkData().Date;
            return true;
        }
        #endregion

        #region OpenSettingsWindow
        public RelayCommand OpenSettingsWindowCommand { private set; get; }
        public void OpenSettingsWindowCommandExecute()
        {
            Messenger.Default.Send(new NotificationMessage("OpenSettingsWindow"));
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

        #region WindowState
        private WindowState windowState;
        public WindowState WindowState
        {
            get { return windowState; }
            set
            {
                windowState = value;
                OnPropertyChanged("WindowState");
            }
        }
        #endregion

        #region ResizeMode
        private ResizeMode resizeMode;
        public ResizeMode ResizeMode
        {
            get { return resizeMode; }
            set
            {
                resizeMode = value;
                OnPropertyChanged("ResizeMode");
            }
        }
        #endregion

        #region WindowBorderThickness
        private Thickness windowBorderThickness;
        public Thickness WindowBorderThickness
        {
            get { return windowBorderThickness; }
            set
            {
                windowBorderThickness = value;
                OnPropertyChanged("WindowBorderThickness");
            }
        }
        #endregion

        #region IsEnabled
        public bool IsEnabled { get; set; }
        #endregion

        #region ModelInteraction
        public ObservableCollection<WorkData> WorkDatas { get; set; }
        private WorkData selectedData;
        public WorkData SelectedData
        {
            get { return selectedData; }
            set
            {
                selectedData = value;
                OnPropertyChanged("SelectedData");
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
