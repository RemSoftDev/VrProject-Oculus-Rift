   M S B A M L   `   `   `  ����D  @VrManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:VrManager	VrManager  5   	   H DMahApps.Metro, Version=1.4.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5	   	       VrManager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:VrManager     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5	   	   -   5          � Title$  	VrManager��5   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	      ColorBackground#���   5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	    � Topmost .  .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6     ColorRegular#���  6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5       $��* �6#   �� 5!      $
��auto �6#   �� 5"      $
��auto �6#   .+�5%      �� -   5        $��
HomeButton��5&      $��0��5%      ��5)      �� 5*      .R�5+      �� $��
thisButton��6$   $��50��5,      $��50��5-      $��Segoe MDL2 Assets)�5.      $��30(�5/        ColorForeground#���  50       �� Padding$ 10q�51      $	����52      	 �� Triggers	 54      P� 55      
 P� Property
 �@J�IsMouseOver P� Value . . �57   "   ��  �� 
TargetName$ 
thisButton��6)     
ColorHover �� Value# �  59   )    �� Property � ��5:      P� 5<      
 � �� . . �5>   "   �� $ 
thisButton��6)     ColorPressed# �  5@   )    � ��5A      P� 5B      
 � {� .  . �5D   "   �� $ 
thisButton��6)     ColorBackgroundDisable# �  5F   )    � ���� 5G   "   $ 
thisButton��6)     ColorForegroundDisable# �  5I   )    � ��5J      P� 5K      
 � {� .  . �5M   "   �� $ 
thisButton��6)   # �  5O   )    � ���� 5P   "   $ 
thisButton��6)   # �  5R   )    � ��5S      5U      5W      �� 5Y      -   5        $��
BackButton��5Z      $��1��5Y      {�5\      ��  �� ElementName$ 	MainFrame�� �� Path$ 	CanGoBack���5^      �� 5_      .R�5`      �� $��
thisButton��6$   $��50��5a      $��50��5b      $��Segoe MDL2 Assets)�5c      $��30(�5d      #���  5e      $ 10q�5f      $	����5g      	 5j      P� 5k      
 �@J�IsMouseOver . . �5o   "   �� $ 
thisButton��6)   # �  5q   )    � ��5r      P� 5t      
 � �� . . �5x   "   �� $ 
thisButton��6)   # �  5z   )    � ��5|      P� 5}      
 � {� .  . �5�   "   �� $ 
thisButton��6)   # �  5�   )    � ��5�      5�      5�      �� 5�      -   5        $��
NextButton��5�      $��2��5�      {�5�      �� $ 	MainFrame��$ CanGoForward���5�      �� 5�      .R�5�      �� $��
thisButton��6$   $��50��5�      $��50��5�      $��Segoe MDL2 Assets)�5�      $��30(�5�      #���  5�      $ 10q�5�      $	����5�      	 5�      P� 5�      
 �@J�IsMouseOver . . �5�   "   �� $ 
thisButton��6)   # �  5�   )    � ��5�      P� 5�      
 � �� . . �5�   "   �� $ 
thisButton��6)   # �  5�   )    � ��5�      P� 5�      
 � {� .  . �5�   "   �� $ 
thisButton��6)   # �  5�   )    � ��5�      5�      5�      �� 5�      -   5        $��TitleContent��5�      $��3��5�      $��
Vr Manager��5�      $��30(�5�      $
��Left=�5�      #���  5�      $��Center=�5�      �� 5�      -   5        $��NameProgram��5�      $��4��5�      $��
Vr Manager��5�      $��30(�5�      $��Right=�5�      #���  5�      $��Center=�5�      �� 5�      -   5        $��
ExitButton��5�      $��8��5�      $��50��5�      $��50��5�      ��5�      �� 5�      .R�5�      �� $��
thisButton��6$   $��Segoe MDL2 Assets)�5�      $��30(�5�      #���  5�      $ 
0,10,10,10q�5�      $
�� ��5�      	 5�      P� 5�      
 �@J�IsMouseOver . . �5�   "   �� $ 
thisButton��6)    �@J�Opacity$	 0.8Q�5�   )   �� 5�   "   $ 
thisButton��6)    � �� �#e811235�   )   5�      P� 5�      
 � �� . . �5�   "   �� $ 
thisButton��6)    �@J�Opacity$	 0.4Q�5�   )   5�      5�      5�      5�       � 5�   
   -   5        $��	MainFrame��5�      $��1��6!     � NavigationUIVisibility$ Hidden=�6.   5�      5�      5�      