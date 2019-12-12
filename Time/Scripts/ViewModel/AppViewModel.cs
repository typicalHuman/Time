using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Time.Scripts.ViewModel
{
    public class AppViewModel: INotifyPropertyChanged
    {
        #region Constructor
        public AppViewModel()
        {
            //initalize default value
            WindowBorderThickness = new Thickness(1);
            fontFamily = new FontFamily("Courier New");
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
