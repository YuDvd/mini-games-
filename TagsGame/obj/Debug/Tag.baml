   M S B A M L   `   `   `  ����C  ?TagsGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MiniGames	MiniGames  5   	       MiniGames.Tag   5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:MiniGames     5   	   -   5          � Title$  Пятнашки��5	   	   $	��470��6   $	��400��5
   	    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�5   	   $��18(�6   $
��Bold"�5   	   
���   �
��� ��� � Icon$ Images/tag.png��5   	    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType	 �� Triggers
 P� Property P� Value��%h  '��       �� 5   
   " ��6   .�5      ��  � �� �#3D57546+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5!      	 5&      P� 5'      
 �@J�IsMouseOver . . �5(      ��  � ��
 �  ��63   5)      5+      5/      .��57      ]� ��. .+�5;   
   o� $	��Top=�6   
��� ���
���   �$��Right=�6I   $��15(�6e   .@�5<      �� -   5         ��Name$ tblTimer��5<      $
��Left=�6*   $	��Top=�6E   $��10q�6]   m� 5=      -   5        $��Перемешать��5=      6+   m� 5>      -   5        $��
Выход��5>      6&   m� 5?      -   5        $��Меню��5?      6%   5B      �� 5C   
   -   5         ��Name$	 brd��5C      ���#8000$y�	Collapsed=�5D      $	��400��6(    �� CornerRadius$ 20��64   ._�5E      � .+�5F      �� $��Вы победили!!!1��6   
��� ���$��15(�6G   $
��Bold"�6U   $
��Left=�5G      $	��Top=�63   $��	144,5,0,0q�6K   $	��104��6^   $��41��6j   �� 5I      ���#8000$��Center=�6,   $��0, 50, 0 ,0q�6I   $	��Top=�5J      $ 80��61   ._�5L      �� -   5         ��Name$ records��5L   #   $��20(�64   
���������5M      �� 5N      .R�5O   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5P   &   ��  �� TextAlignment$ Right=�6E   $��50��6[   ��60   �� *Pos+6[   �� 5Q   &   $��: ��60   �� 5R   &   $
 Left=�6F   $	��200��6[   ��60   �� *Date+6[   �� 5S   &   $ Center=�6F   $��80��6]   ��60   �� *Time+6]   �� 5T   &   ��6,   �� *LbStatistic+5V   #   5W      5Y      5Z      � 5\      $��Center=�6   $��Bottom=�64    � ColumnDefinitions 5]      �� 5^      $��* �6+   �� 5_      $��* �6+   .+�5a      �� -   5        $��Повторить��5a      $��10,10,10,10q�6H   $��90��6]   $��20��6h   $��15(�6t   $��Center=�6�   $��Center=�5b      
��� ���
���   � 5c      ��%^   '��       �� 5d      " ��6$   .�5e   "   ��  �@��CornerRadius$ 5��6A   5f      5g      5h      5i      5j      5k      � 5p   
   -	   5         �Name$
 grid��5p       � ShowGridLines .  $y�Visible=�63   ��5t      �� 5u       �� ImageSource$ Images/bachTags.jpg��6    5y      �� 5z      6%   �� 5{      6%   �� 5|      6%   �� 5}      6%    � RowDefinitions 5      �� 5�      6"   �� 5�      6"   �� 5�      6"   �� 5�      6"   .+�5�      �� -
   5         ��Name$ button0��5�      $��0��6&   $��0��66   $��8q�6C   
 � Tag$ 0��6N   
��� ���$��25(�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $ button1��5�      $��1��6&   $��0��66   $��8q�6C   $ 1��6N   
��� ���$��25(�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $ button2��5�      $��2��6&   $��0��66   $��8q�6C   $ 2��6N   
��� ���$��25(�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $ button3��5�      $��3��6&   $��0��66   $��8q�6C   $ 3��6N   
��� ���$��25(�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $ button4��5�      $��0��6&   $��1��66   $��8q�6C   $ 4��6N   
��� ���$��25(�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $ button5��5�      $��1��6&   $��1��66   $��8q�6C   $ 5��6N   
��� ���$��25(�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $ button6��5�      $��2��6&   $��1��66   $��8q�6C   $ 6��6N   
��� ���$��25(�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $ button7��5�      $��3��6&   $��1��66   $��8q�6C   $ 7��6N   
��� ���$��25(�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $ button8��5�      $��0��6&   $��2��66   $��8q�6C   $ 8��6N   
��� ���$��25(�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $ button9��5�      $��1��6&   $��2��66   $��8q�6C   $ 9��6N   
��� ���$��25(�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $ button10��5�      $��2��6'   $��2��67   $��8q�6D   $ 10��6O   
��� ���$��25(�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $ button11��5�      $��3��6'   $��2��67   $��8q�6D   $ 11��6O   
��� ���$��25(�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $ button12��5�      $��0��6'   $��3��67   $��8q�6D   $ 12��6O   
��� ���$��25(�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $ button13��5�      $��1��6'   $��3��67   $��8q�6D   $ 13��6O   
��� ���$��25(�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5      -   5        $ button14��5      $��2��6'   $��3��67   $��8q�6D   $ 14��6O   
��� ���$��25(�6�    5     ��%^   '��       �� 5     " ��6   .�5     ��  �@��CornerRadius$ 5��69   5     5     5     �� 5     -   5        $ button15��5     $��3��6'   $��3��67   $��8q�6D   $ 15��6O   
��� ���$��25(�6�    5     ��%^   '��       �� 5	     " ��6   .�5
     ��  �@��CornerRadius$ 5��69   5     5     5     5     5     5     