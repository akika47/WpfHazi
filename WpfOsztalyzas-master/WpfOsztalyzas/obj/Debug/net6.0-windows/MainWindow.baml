   M S B A M L   `   `   `  ����H  DWpfOsztalyzas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfOsztalyzasWpfOsztalyzas  5   	       WpfOsztalyzas.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfOsztalyzas     5   	     � Title$  
WPF Napló��5   	   $	��600��6   $	��500��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $��5* �6   �� 5      �� 5      .+�5   
   �� $��Neve:��6   $��Center=�6    �� 5   
   -   5         ��Name$ txtNev��5      $��Center=�5      $��1��5      $��10q�5      
�������5      �� 5!   
   $��Dátum:��6   $��Center=�6!   $��1��5"      (  "System.Windows.Controls.DatePicker  5#   
   -   5          Name$ datDatum��5#      $��Center=�5$      $��10q�5%      $��1��5&      $��1��6"   �� 5)   
   $��
Tantárgy:��6   $��Center=�6$   $��2��5*      �� 5+   
   -   5         ��Name$ cboTantargy��5+       �� SelectedIndex$ 0��5,      $��Center=�5-      $��10q�6.   $��2��5.      $��1��6    .@�5/      �� $��
Matematika��6   �� 50      $��Angol nyelv��6   �� 51      $��Fizika��6   �� 52      $��Történelem��6   �� 53      $��Magyar irodalom��6   54      �� 57   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�58      �� $��Jegy:��6   $��Center=�6$   �� 59      -   5         ��Name$ lblJegy��59      $��16(�6%   $��DemiBold"�5;      
���  ����5:      �� 	 �� ElementName$	 sliJegy��
 �� Path$
 Value� �� Mode$ OneWay=�5;   *   5<      �� 5>   
   -   5         ��Name$ sliJegy��5>      $��10q�5?      $��3��5@      $��1��6   $��Center=�6.    � Minimum$ 1Q�5A       � Maximum$ 5Q�6    � Value$ 5Q�6)    �� TickFrequency$ 1Q�5B       �� IsSnapToTickEnabled$
 True��6#   �� 5E   
   -   5         ��Name$ btnNaploBetoltese��5E      $��20 10q�5F      $��4��5G      $��Napló betöltése��5H      6+   �� 5J   
   -   5        $ 	btnRogzit��5J      $��20 10q�5K      $��4��5L      $��1��6   $��Rögzít naplóba��5M      6*   &   System.Windows.Controls.DataGrid  5P   
   -   5          Name$ dgJegyek��5P      $��5��6%   $��2��62   $��4q�5Q      
������5R      �� 5V   
   $ 
Horizontal=�6   $��6��6.   $��2��5W      $��Center=�5X      $	��Top=�5Y      .+�5Z      �� -	   5         ��Name$ FilePath_txt��5Z      $�� ��5[      $
��Left=�5\      $	��Top=�5]      �� 5^      -
   5        $ 
Grades_txt��5^      $��Jegyek száma: Átlag: ��5_      $��Right=�5`      $	��Top=�5a      $��15 0 0 0q�5b      5c      �� 5d   
   $ 
Horizontal=�6   $��7��5e      $��2��6"   $	��Top=�5f      $��Center=�5g      .+�5h      	� -   5        $��Vezetéknév->Keresztnév��5h       d� 	IsChecked$
 TrueY�6;   6L   	� 5i      -   5        $��Keresztnév->Vezetéknév��5i      $��15 0 0 0q�5j      6,   5k      5l      5m      