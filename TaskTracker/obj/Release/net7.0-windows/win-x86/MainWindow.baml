   M S B A M L   `   `   `  ���� F  BTaskTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskTrackerTaskTracker  R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel     TaskTracker.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:TaskTracker     Hscm8clr-namespace:System.ComponentModel;assembly=WindowsBase       � Title$  Task Tracker��$	��450��$	��800��$	��300��$	��600�� � 	Resources 4   .TaskTracker.DateTimeToFormattedStringConverter   DateTimeConverter  SortedTasks �� Source �� Path �� SortDescriptions+  %System.ComponentModel.SortDescription   PropertyName   	Direction  WatermarkTextBox �� 
TargetType �� Property	 �� Value
 �� 
TargetType ��Name �� RelativeSource �� UpdateSourceTrigger J� IsHitTestVisible �� Triggers �� Binding �� Source%  System.Windows.Markup.Reference �� Value��%�  &	        &	      &	 I       ��  �� $ Tasks�   $ 	CreatedAt��$ 
Descending=��� " ��.���  � ��	 �� "
 ��.R�� .+��� $ 
textSource��
������ ���� *Text+ �� *TemplatedParent+$ PropertyChanged=��� $)��#Enter a new task and press Add Task��
�������$ False��$��Center=����� " ��.���  � y�$	 	Collapsed=� ��  �� *Text+   *
textSource+  .a���  � y�$	 Visible=�.���  � RowDefinitions �� $��* ��� $
��Auto �.+��� -    ��Name$ TasksListView��$��0��$��10q����� # [  �� View �� .P���  �� Width$ 50�� �� CellTemplate �� .R��� -    d� 	IsChecked �� *
IsComplete+ �� Mode$ TwoWay=��� $
��Task�� �� DisplayMemberBinding �� *Description+ �� HeaderTemplate �� .R���  �� Orientation$ 
Horizontal=�.+��� -   $
��Task��
 � Tag �� $ SortDirection�$ TwoWay=��� $��
Created At�� �� .R��� $ 
Horizontal=�.+��� -   $��
Created At�� �� $ SortDirection�$ TwoWay=� �� .R��� ���� *	CreatedAt+ �� 	Converter# [  �� $ 
Horizontal=�$��1��$��Right=�.+��� -   $ NewTaskTextBox��#��[ $��10q�$	��200���� -   $��Add Task��$��10q�$	��120���� -   $��Show Completed Tasks��$��10q�$	��180��