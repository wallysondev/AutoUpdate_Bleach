   M S B A M L   `   `   `  ����L  HAutoUpdate_Bleach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AutoUpdate_BleachAutoUpdate_Bleach  5   	   "    AutoUpdate_Bleach.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:AutoUpdate_Bleach     5   	   -   5          � Title$  
MainWindow��5   	   $	��500��6   $	��400��6)    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�6.   
������  � AllowsTransparency$
 True��5
   "    � 
ResizeMode$ NoResize=�5   	    � WindowState$ Normal=�6   .��5      �� -   5         �� CornerRadius$ 8��5         WindowBackgroundColor#���   6;   ._�5   
   �  � ColumnDefinitions 5      �� 5      $��0* �6#   �� 5       � RowDefinitions 5      �� 5      $	��237 �6    �� 5      $	��150 �6    �� 5      $	��115 �6    �� 5      .+�5      �� $ 8,8,0,0��6   $��2��6,   ._�5      F� ���#ff4040����� ��0<��`�4�+�@x���J�    ��J��  �I	P[���-@Q    �Q�8��@S    ,K���@��6   dMu�
z   �מY"�Q4�     ��S�ī	��<~o�?�/N    ���/N    ��Qhe    ��S u�    ��8!���&p�@h��rK� @-���y@��JY��$@-���y@�St$�8@z�&1zu@?��F@��/݌q@�p=
�T@Zd;�_o@0<�	6'   5      �� 5      $��2��6   $��	0,32,0,10q�6%   $��/Images/Ichigo_banner.png��69   $
��Fill=�6\   $��2��6k   �� 5       $��1��6   $��100,145,100,45q�6!   $��/Images/Logo_Game.png��69   $
��Fill=�6X   	 J� RenderTransformOrigin$	 0.5,0.5&�6g   $��2��6�   $��2��6�   z�5!      V� 5"      .~�5#      �� 
 �� ScaleY$
 1Q�6)   �� 5$      �� 5%      T� 5&      5'      5)      � 5*      $��0��6   $��2��6     5+      �� 5,      $��60 �6$   �� 5-      .+�51      �� $��0��6   $	��Top=�6*   $��Right=�6B   $��0,0,10,0q�6^   $��30��6p    �� Orientation$ 
Horizontal=�6|   $��RightToLeft=�6�   .+�52      �� -   5         ��Name$ btnClose��52        IconButtonsStyle#��[ 6/    	 close#���  6Y    � Cursor$
 Hand��6�   �� 53      -   5        $ btnMinimize��53        MinimizeButtonStyle#��[ 62     minimize#���  6_   $
 Hand��6�   54      55      � 56      $��2��6   $	��Top=�6    $��2��68   $��	0,100,0,0q�6L    57      �� 58      $	��18* �6'   �� 59      $	��10* �6'   �� 5:      $	��45* �6'   �� 5;      $	��10* �6'   �� 5<      $
��317* �6'   .+�5>      �� -   5        $��lblFilevalue��5>      $��10MB / 100MB 600kbps��5?      
�������$��	8,-20,8,0q�5A      $��10(�5B      $��25��5C      $	��Top=�5D      $
��Left=�5E      $7��1/Fonts/friz-quadrata-bold-bt.ttf #FrizQuadrata BT)�5F      $��5��6c   �� 5G      -   5        $��lblProgress��5G      $��
Instalando��5H      
�������$��
8,-32,80,0q�5J      $��10(�5K      $��25��5L      $	��Top=�5M      $
��Left=�5N      $7��1/Fonts/friz-quadrata-bold-bt.ttf #FrizQuadrata BT)�5O      $��5��6c   �� 5P      -   5        $��lblTimer��5P      $��00:00:00��5Q      
�������$��227,-28,0,0q�5S      $��18(�5T      $��30��5U      $	��Top=�5V      $��Right=�5W      $7��1/Fonts/friz-quadrata-bold-bt.ttf #FrizQuadrata BT)�5X      $��4��6c   �� 5_      -   5        $ btnstopdown��5`        playerdownload#��[ 5a       
 stoped#���  5b      $
 Hand��5c      $��207,-20,92,0q�5d      $	��Top=�5e      $��4��5f   /   � 5g      -	   5        $��ProgressBarDinamic��5h        ProgressBarStyle#��[ 5i       � Minimum$ 0Q�5j       � Maximum$	 100Q�6!   $��5��6/   $��8,0,8,0q�6C   5k      5l      5m      5n      