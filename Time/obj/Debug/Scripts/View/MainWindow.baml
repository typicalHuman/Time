   M S B A M L   `   `   `  ����?  ;Time, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Time.Scripts.ViewModelTime.Scripts.ViewModel  5   	   clr-namespace:TimeTime  5   	   ?$clr-namespace:Time.Scripts.ViewModelTime.Scripts.ViewModel  5   	   5clr-namespace:Time.Scripts.ViewTime.Scripts.View  5   	       Time.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -vm$clr-namespace:Time.Scripts.ViewModel  5   	   localclr-namespace:Time  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   5
viewmodels$clr-namespace:Time.Scripts.ViewModel  5   	   +viewsclr-namespace:Time.Scripts.View  5   	   -   5        $	��450��5   	   $	��450��6   $	��450��6(   $	��450��64     � AllowsTransparency  .  � WindowStartupLocation$ CenterScreen=�5   #    � WindowStyle$
 None=�5   +   ���#007acb   Time.App   MainVM � DataContext# Z 5   	    � 
ResizeMode 5   	   �� *
ResizeMode+��5   	   �� *WindowBorderThickness+ � WindowState 5   	   �� *WindowState+��5   	   �� *
FontFamily+��5   	   �� *
ForeGround+'  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�5   	   	   ResizeBorderThickness$	 7q�5   	   .��5      � ���#1b1c1b
 � ColumnDefinitions
 5   
   �� 5       $��3* �6   �� 5!      $
��Auto �6   �� 5"      $
��Auto �6    �� 5#      $
��Auto �6     � RowDefinitions 5&   
   �� 5'      $��40 �6   �� 5(      $��40 �6   �� 5)      $	��18* �6   .+�50   
   �� $��3��6   $��51��6!   $��40��6,   $��5q�69   $��0q�51      
������  � ToolTip$ Close��52         CloseButtonStyle#��[  53      ��52   !   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Close=�   Size$ 25X�.  (System.Windows.Interactivity.Interaction   Triggers 54      /  )System.Windows.Interactivity.EventTrigger  55         	EventName$ Click��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 56      6  0System.Windows.Interactivity.InvokeCommandAction     Command 57      �� *CloseCommand+58      5:      �� 5?   
   $��2��6   $��40��6!   $��51��6-   $ Maximize��5@        MaximizeButtonStyle#��[ 6$   ��5A        $ WindowMaximize=�$ 25X� 5B        5C      $ Click��6!   . 5D         5E      �� *MaximizeCommand+5F      5H      �� 5L   
   $��1��6   $��40��6!   $��51��6-   $ Minimize��5M      #��[ 6$   ��5N        $ WindowMinimize=�$ 25X� 5O        5P      $ Click��6!   . 5Q         5R      �� *MinimizeCommand+5S      5U      �� 5[   
    �� Orientation$ 
Horizontal=�6   .+�5]      �� $��50��6   #��[ 6    $
��Left=�5_      $
 Menu��5`      $��40��6    0   *Time.Scripts.ViewModel.MenuButtonViewModel   IsLeftClickEnabled . ��5^        $ CameraTimer=�$ 30X� � ContextMenu 5b      �� 5c        ContextMenuStyle#��[ 6"   .@�5d      m� $��Settings��6#    m� Command 65   �� *OpenSettingsWindowCommand+m� 5e      $��Results��6#    64   �� *OpenResultWindowCommand+5f      5h      �� 5i      $
��Time��6   
�������$��25(�67   $��Center=�5j      $��2 0 0 0q�63   $
��Bold"�6D   5l      �� 5q   
   $��1��6   $��4��6"   $ 
Horizontal=�66   .+�5t      �� $��50��6   $��40��6    #��[ 6,   $	 Add��5v      ��5u        $ AddAlarm=�$ 30X� 5w        5x      $ Click��6%   . 5y         5z      �� *
AddCommand+5{      5}      d� 5�        StartButtonStyle#��[ 6   $��40��6E   $��50��5�       d� 	IsChecked 6    �� *SelectedData.Timer.IsStart+{�6Q   �� *	IsEnabled+ 5�        5�      $ Click��6%   . 5�         5�      �� *!SelectedData.Timer.StartCommand+5�      5�      �� 5�      $��50��6   $��40��6    #��[ 6,   $	��+1m��5�      $��20(�6#    5�        5�      $ Click��6%   . 5�           CommandParameter$ 59��5�   7    6   �� *AddMinutesCommand+67   5�      5�      �� 5�      $��50��6   $��40��6    #��[ 6,   $	��+2m��5�      $��20(�6#    5�        5�      $ Click��6%   . 5�        $	 119��5�   8    6   �� *AddMinutesCommand+68   5�      5�      �� 5�      $��53��6   $��40��6    #��[ 6,   $
��+10m��5�      $��20(�6$    5�        5�      $ Click��6%   . 5�        $	 599��5�   8    6   �� *AddMinutesCommand+68   5�      5�      5�      �� 5�   
   $��2��5�   8   ���#1b1c1b$��4��5�      ��5�      �� *	WorkDatas+ �� SelectedItem 5�      �� *SelectedData+��5�      �� 5�      .R�5�      �� $ Vertical=�6!   .+�5�      �� $��20(�6:   
���������6$   �� *Date+6H   � 5�      .+�5�      � $	��300��6*   $��30��66   $
��Left=�5�   &    � Maximum 5�   *   �� *RequiredTime+ � Value 5�   *   �� *CurrentTime+�� 5�      $��Center=�5�   &   $��Center=�6C   ��5�   (   �� *Timer.Percent+ �� StringFormat$ {0:0}%�� �� UpdateSourceTrigger$ PropertyChanged=�5�      5�      �� 5�      $��20(�6@   
���������6$   �� *
Timer.Time+6N   5�      5�      5�      5�      5�      