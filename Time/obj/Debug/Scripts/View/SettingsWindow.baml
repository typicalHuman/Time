   M S B A M L   `   `   `  ����?  ;Time, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TimeTime  5   	   %    Time.Scripts.View.OptionsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Time     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5        $	��100��5
   	   $	��250��6   $	��250��6(   $	��100��64     � AllowsTransparency  .  � WindowStartupLocation$ CenterScreen=�5   #    � 
ResizeMode$ CanResizeWithGrip=�5   	    � WindowStyle$
 None=�6(   ���#007acb$��1q�5   	    � WindowState$ Normal=�5   	      Time.App   
SettingsVM � DataContext# Z 5   	   ��5   	   �� *
FontFamily+'  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�5   	   	   ResizeBorderThickness$	 7q�5   	   .��5      � ���#1b1c1b
 � ColumnDefinitions
 5   
   �� 5      $��3* �6   �� 5      $
��Auto �6    � RowDefinitions 5    
   �� 5!      $��40 �6   �� 5"      $	��18* �6   .+�5)   
   �� $��3��6   $��51��6!   $��40��6,   $��5q�69   $��0q�5*      
������  � ToolTip$ Close��5+         CloseButtonStyle#��[  6X   ��6!   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Close=�   Size$ 25X�.  (System.Windows.Interactivity.Interaction   Triggers 5,      /  )System.Windows.Interactivity.EventTrigger  5-         	EventName$ Click��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5.      6  0System.Windows.Interactivity.InvokeCommandAction     Command 5/      �� *CloseCommand+50      52      �� 59   
    �� Orientation$ 
Horizontal=�6   .+�5:      �� $��50��6     MaximizeButtonStyle#��[ 6    $
��Left=�5<      $��40��5=      {�.  ��5;        $ Settings=�$ 30X�5=      �� 5>      $��Settings��6   $��25(�6(   $��2 0 0 0q�66   
�������$��Center=�5?   *   $
��Bold"�6E   5@      �� 5D   
   $��1��6   $��2��6"   .+�5H      �� $ 
Horizontal=�6   .+�5I      �� $��
Time Limit��6   
�������$��20(�6A   $��3 0 0 0q�6O   $��Center=�5J      �� 5K      -   5        $��55��5K      $��20(�6%    �� 	MaxLength$ 4��63   $��3 0 0 0q�6A   
���������5L   -   �� *	TimeLimit+ �� UpdateSourceTrigger$ PropertyChanged=�.��5M   F    � ContextMenu 5N      �� 5O      $y�	Collapsed=�6&   .��5P   +   5Q      �� 5R      $	��min��6   
�������$��20(�6:   $��3 0 0 0q�6H   $��Center=�5S      5T      5V      5Y      5Z      