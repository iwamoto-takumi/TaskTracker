   M S B A M L   `   `   `  ����F  BTaskTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskTrackerTaskTracker  5   	   R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel 5   	       TaskTracker.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TaskTracker     5   	   Hscm8clr-namespace:System.ComponentModel;assembly=WindowsBase     5   	     � Title$  Task Tracker��5	   	   $	��450��6   $	��800��6+   $	��300��5
   	   $	��600��6    � 	Resources 5      4   .TaskTracker.DateTimeToFormattedStringConverter   DateTimeConverter  SortedTasks �� Source �� Path �� SortDescriptions+  %System.ComponentModel.SortDescription   PropertyName   	Direction  WatermarkTextBox �� 
TargetType �� Property	 �� Value
 �� 
TargetType ��Name �� RelativeSource �� UpdateSourceTrigger J� IsHitTestVisible �� Triggers �� Binding �� Source%  System.Windows.Markup.Reference �� Value��%  &	        &	      &	 �       5   
   63   �� 5   
    63   �� $ Tasks� 5        5      $ 	CreatedAt��6&   $ 
Descending=�6?   5      �� 5   
   " ��6)   .�5      ��  � ��	 5      �� 5      "
 ��6&   .R�5      � .+�5      �� $ 
textSource��6&   
������ ��6:   �� *Text+ �� *TemplatedParent+$ PropertyChanged=�6�   �� 5      $)��#Enter a new task and press Add Task��6(   
�������$ False��6e   $��Center=�6~   ��5   "   �� 5   &   " ��6,   .�5   *   ��  � y�$	 	Collapsed=�6G    5   *   �� 5   .    6:   �� *Text+   *
textSource+  6t   .a�5   2   ��  � y�$	 Visible=�6O   5    /   5"   '   5$      5%      5&      5(      5)      5*      .��5+      �  � RowDefinitions 5,   
   �� 5-      $��* �6   �� 5.      $
��Auto �6   .+�51   
   �� -   5         ��Name$ TasksListView��51      $��0��6*   $��10q�67   ��6C   �� # [  �� View 52      �� 53      .P�54      ��  �� Width$ 50��6%    �� CellTemplate 55      �� 56      .R�57   "   �� -   5         d� 	IsChecked 57   +   �� *
IsComplete+ �� Mode$ TwoWay=�6Y   58      5:      �� 5;      $
��Task��6%    �� DisplayMemberBinding 63   �� *Description+ �� HeaderTemplate 5<      �� 5=      .R�5>   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5?   &   �� -   5        $
��Task��5?   0   
 � Tag 6c   �� $ SortDirection�$ TwoWay=�5@   #   5A      5C      �� 5D      $��
Created At��6%    5E      �� 5F      .R�5G   "   �� $ 
Horizontal=�6-   .+�5H   &   �� -   5        $��
Created At��5H   0    6n   �� $ SortDirection�$ TwoWay=�5I   #   5J       5L      �� 5M      .R�5N   "   �� ��6,   �� *	CreatedAt+ �� 	Converter# [  5O      5Q      5R      5T      �� 5V   
   $ 
Horizontal=�6   $��1��6.   $��Right=�6;   .+�5W      �� -   5        $ NewTaskTextBox��5W      #��[ 6.   $��10q�6X   $	��200��6d   �� 5X      -   5        $��Add Task��5X      $��10q�6(   $	��120��64   6@   �� 5Y      -   5        $��Show Completed Tasks��5Y      $��10q�64   $	��180��6@   6L   5Z      5[      5\      