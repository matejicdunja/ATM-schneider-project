   M S B A M L   `   `   `  ����>  :ATM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ATM.ViewModelsATM.ViewModels  5   	       ATM.Views.UserWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ATM.ViewModels     5   	     � Title$	  ATM��5   	   $	��450��6   $	��800��6"   .��5	      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�6*   .+�5   
   �� $ Vertical=�6      MenuBackground#��[  6,   $	��220��6T   $	��435��6`   .+�5      �� $��Profile��6   $��Center=�6&   $��	0,30,0,30q�6C   $��Ariel)�6V   $��20(�6i   ���#3c3c3c$��Oblique$�5   -   $��
ExtraBlack"�6A   6\   �� 5      $��3q�6   ���#3c3c3c$��1��6>   6K   �� 5      $ 
Horizontal=�6   $��	10,10,0,5q�62   .+�5      �� $��Arial)�66   $��13(�6I   $��0q�6W   $
��Bold"�5      ���#3c3c3c��5      �� *	User.Name+5   *   �� 5      $��Arial)�6:   $��13(�6M   $��5,0,0,0q�6[   $
��Bold"�5      ���#3c3c3c��5      �� *User.LastName+5   *   5      �� 5      $ 
Horizontal=�6   $��10,5,0,0q�62   .+�5      �� $��Card number:��6   $��Arial)�6/   $��10(�6B   $��0q�6P   ���#3c3c3c6[   �� 5      $��Arial)�6B   $��12(�6U   $��SemiBold"�6c   $��5,0,0,0q�6y   ���#3c3c3c��6   �� *User.CreditCardNumber+6�   5      �� 5      $ 
Horizontal=�6   $��	10,5,0,10q�62   .+�5      �� $
��PIN:��6   $��Arial)�6'   $��10(�6:   $��0q�6H   ���#3c3c3c6S   �� 5      $��Arial)�65   $��12(�6H   $��SemiBold"�6V   $��5,0,0,0q�6l   ���#3c3c3c��6   �� *
User.Pin+6}   5      �� 5      $��3q�6   ���#3c3c3c$��1��6>   6K   �� 5      -   5         ��Name$ BallanceButton��5      $
��Auto��6-   $��	0,10,0,10q�6:   $��Ballance��6M   
������ 
������ $
��Bold"�5    P   $��Arial)�5!      $��14(�60   ���#3c3c3c$��Normal$�6S   ��5"      �� *BallanceCommand+�� 5#      $��3q�6   ���#3c3c3c$��1��6>   6K   �� 5$      -   5        $ WithdrawButton��5$      $
��Auto��6-   $��	0,10,0,10q�6:   $��Withdraw��6M   
������ 
������ $
��Bold"�5%   P   $��Arial)�5&      $��14(�60   ���#3c3c3c$��Normal$�6S   ��5'      �� *WithdrawCommand+�� 5(      $��3q�6   ���#3c3c3c$��1��6>   6K   �� 5)      -   5        $ TopUpButton��5)      $
��Auto��6*   $��	0,10,0,10q�67   $��Top Up��6J   
������ 
������ $
��Bold"�5*   P   $��Arial)�5+      $��14(�60   ���#3c3c3c$��Normal$�6S   ��5,      �� *TopUpCommand+�� 5-      $��3q�6   ���#3c3c3c$��1��6>   6K   �� 5.      -   5        $ EditProfileButton��5.      $
��Auto��60   $��	0,10,0,10q�6=   $��Edit profile��6P   
������ 
������ $
��Bold"�5/   P   $��Arial)�50      $��14(�60   ���#3c3c3c$��Normal$�6S   ��51      �� *EditProfileCommand+�� 52      $��3q�6   ���#3c3c3c$��1��6>   6K   �� 53      -   5        $ LogOutButton��53      $
��Auto��6+   $��	0,10,0,10q�68   $��Log out��6K   
������ 
������ $
��Bold"�54   P   $��Arial)�55      $��14(�60   ���#3c3c3c$��Normal$�6S   ��56      �� *LogOutCommand+�� 57      $��3q�6   ���#3c3c3c$��1��6>   6K   58      �� 5;   
   -   5         ��Name$ BallanceSection��5;      $ Vertical=�6.   $	��580��6E     PanelBackground#��[ 6Q   $y�Visible=�6z   .+�5<      �� $ 
Horizontal=�6   $��Right=�62   $��0,5,5,0q�6N   .+�5=      �� $��Arial)�6?   $��15(�6R   $��SemiBold"�6`   $��0,0,10,0q�6v   ���#3c3c3c��6   �� *Datum+ �� Mode$ TwoWay=�6�   5>      �� 5?      $��Account ballance��6   $��Center=�6/   $��	0,70,0,30q�6L   $��Ariel)�5@      $��20(�6'   ���#3c3c3c$��Oblique$�6J   $��
ExtraBlack"�5A      $
��Auto��6,   6;   �� 5B       �� CornerRadius$ 5��6   $	��305��6&   $	��105��62   $��1q�6?   ���#3c3c3c$��	0,10,0,40q�6i   
�������._�5C      �� $��Arial)�6B   $��24(�6U   $
��Bold"�6c   $	��300��5D      $	��100��6$   ���#3c3c3c$��Center=�6F   $��Center=�5E      ��5C      �� *
Ballance+$ TwoWay=�5E      5F      �� 5G      $��Generate Report��6     CustomButtonStyle#��[ 6Y   ��6/   �� *GenerateReportCommand+6Y   5H      �� 5L   
   -   5        $ WithdrawSection��5L      $ Vertical=�6.   $	��580��6E   #��[ 6Q   $y�	Collapsed=�6z   .+�5M      �� $ 
Horizontal=�6   $��Right=�62   $��0,5,5,0q�6N   .+�5N      �� $��Arial)�6?   $��15(�6R   $��SemiBold"�6`   $��0,0,10,0q�6v   ���#3c3c3c��6   �� *Datum+$ TwoWay=�6�   5O      �� 5P      $��Withdraw money��6   $��Center=�6-   $��	0,70,0,30q�6J   $��Ariel)�5Q      $��20(�6'   ���#3c3c3c$��Oblique$�6J   $��
ExtraBlack"�5R      $
��Auto��6,   6;   �� 5S      $ 5��6   $	��305��6&   $	��105��62   $��1q�6?   ���#3c3c3c$��	0,10,0,40q�6i   
�������._�5T      �� .+�5U      �� $��Amount:��6   $
��Left=�6.   ���#3c3c3c$��Arial)�6^   $��Oblique$�5V      $��Light"�60   $��5q�6C   6P   �� 5W      $��Arial)�6K   $��24(�6^   $
��Bold"�6l   $	��300��5X      $��70��6(   ���#3c3c3c$��Center=�6I   $��Center=�5Y      $��0q�6>   ��5W      �� *WithdrawAmount+$ TwoWay=�5Y   >   5Z      5[      �� 5\      $ 
Horizontal=�6   $��Center=�62   .+�5]      �� $��Cancel��6   #��[ 6T   ��6*   �� *WithdrawCancelCommand+6T   �� 5^      $
��Done��6   #��[ 6P   $��15q�6{   ��6(   �� *WithdrawDoneCommand+6{   5_      5`      �� 5c   
   -   5        $ TopUpSection��5c      $ Vertical=�6+   $	��580��6B   #��[ 6N   $y�	Collapsed=�6w   .+�5d      �� $ 
Horizontal=�6   $��Right=�62   $��0,5,5,0q�6N   .+�5e      �� $��Arial)�6?   $��15(�6R   $��SemiBold"�6`   $��0,0,10,0q�6v   ���#3c3c3c��6   �� *Datum+$ TwoWay=�6�   5f      �� 5g      $��Top up money��6   $��Center=�6+   $��	0,70,0,30q�6H   $��Ariel)�5h      $��20(�6'   ���#3c3c3c$��Oblique$�6J   $��
ExtraBlack"�5i      $
��Auto��6,   6;   �� 5j      $ 5��6   $	��305��6&   $	��105��62   $��1q�6?   ���#3c3c3c$��	0,10,0,40q�6i   
�������._�5k      �� .+�5l      �� $��Amount:��6   $
��Left=�6.   ���#3c3c3c$��Arial)�6^   $��Oblique$�5m      $��Light"�60   $��5q�6C   6P   �� 5n      $��Arial)�6H   $��24(�6[   $
��Bold"�6i   $	��300��5o      $��70��6(   ���#3c3c3c$��Center=�6I   $��Center=�5p      $��0q�6>   ��5n      �� *TopUpAmount+$ TwoWay=�5p   >   5q      5r      �� 5s      $ 
Horizontal=�6   $��Center=�62   .+�5t      �� $��Cancel��6   #��[ 6Q   ��6*   �� *TopUpCancelCommand+6Q   �� 5u      $
��Done��6   #��[ 6M   $��15q�6x   ��6(   �� *TopUpDoneCommand+6x   5v      5w      �� 5z   
   -	   5        $ EditProfileSection��5z      $ Vertical=�61   $	��580��6H   #��[ 6T   $y�	Collapsed=�6}   .+�5{      �� $ Vertical=�6   $��Center=�60   $��0, 100, 0, 50q�6M   .+�5|      �� $ 
Horizontal=�6   $��Stretch=�66   .+�5}      �� $��Name:              ��6   $��Center=�6:   $��Arial)�6\   $��12(�6o   ���#3c3c3c5~       �� 5      -
   5         ��Name$ NameTextBox��5        CustomTextBoxStyle#��[ 6[   $	��150��6�   ��63   �� *	NameValue+$ TwoWay=�6�   5�      �� 5�      $ 
Horizontal=�6   $��Stretch=�66   .+�5�      �� $��Surname:         ��6   $��Center=�68   $��Arial)�6Z   $��12(�6m   ���#3c3c3c5�       �� 5�      -   5        $ SurnameTextBox��5�      #��[ 6a   $	��150��6�   ��66   �� *SurnameValue+$ TwoWay=�6�   5�      �� 5�      $ 
Horizontal=�6   $��Stretch=�66   .+�5�      �� $��Card number:   ��6   $��Center=�66   $��Arial)�6X   $��12(�6k   ���#3c3c3c5�       �� 5�      -   5        $ CardTextBox��5�      #��[ 6[   $	��150��6�   ��63   �� *	CardValue+$ TwoWay=�6�   5�      5�      �� 5�      $ 
Horizontal=�6   $��Center=�62   .+�5�      �� $��Cancel��6   #��[ 6P   ��6*   �� *EditCancelCommand+6P   �� 5�      $
��Done��6   #��[ 6L   $��15q�6w   ��6(   �� *EditDoneCommand+6w   5�      5�      5�      5�      