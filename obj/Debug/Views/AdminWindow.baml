   M S B A M L   `   `   `  ����>  :ATM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ATM.ViewModelsATM.ViewModels  5   	       ATM.Views.AdminWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ATM.ViewModels     5   	     � Title$	  ATM��5   	   $	��450��6   $	��800��6"   .��5
      ��  �� Orientation$ 
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
User.Pin+6}   5      �� 5      $��3q�6   ���#3c3c3c$��1��6>   6K   �� 5      -   5         ��Name$ EditProfileButton��5      $
��Auto��60   $��	0,10,0,10q�6=   $��Edit profile��6P   
������ 
������ $
��Bold"�5    P   $��Arial)�5!      $��14(�60   ���#3c3c3c$��Normal$�6S   ��5"      �� *EditProfileCommand+�� 5#      $��3q�6   ���#3c3c3c$��1��6>   6K   �� 5$      $��3q�6   ���#3c3c3c$��	0,120,0,0q�6>   $��1��6Q   6^   �� 5%      -   5        $ LogOutButton��5%      $
��Auto��6+   $��	0,10,0,10q�68   $��Log out��6K   
������ 
������ $
��Bold"�5&   P   $��Arial)�5'      $��14(�60   ���#3c3c3c$��Normal$�6S   ��5(      �� *LogOutCommand+�� 5)      $��3q�6   ���#3c3c3c$��1��6>   6K   5*      �� 5-   
   -   5         ��Name$ BlockedUsersSection��5-      $	��580��62     PanelBackground#��[ 6>   $ Vertical=�6g   .+�5.      �� $ 
Horizontal=�6   $��Right=�62   $��0,5,5,0q�6N   .+�5/      �� $��Arial)�6?   $��15(�6R   $��SemiBold"�6`   $��0,0,10,0q�6v   ���#3c3c3c��6   �� *Datum+ �� Mode$ TwoWay=�6�   50      &   System.Windows.Controls.DataGrid  51      $��30q�6      SelectionMode$ Single=�52         AutoGenerateColumns .  $
��Auto��6J      GridLinesVisibility$ 
Horizontal=�53      $��Center=�68   ���#e5e5e5��51   #   �� *BlockedUsers+ �� SelectedItem 6H   �� *SelectedUser+	   Columns	 54      0  *System.Windows.Controls.DataGridTextColumn  55        HeaderStyle,  &System.Windows.Controls.DataGridColumn
   HeaderStyle#
 [ 6)     CellTextStyle2   	CellStyle# [ 6T      Header$ Id��56   )      CanUserSort .     
IsReadOnly .    CanUserResize .     CanUserReorder .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 57   V   �� *Id+  58      #
 [ 6)     CellTextStyle1# [ 6T   $
 Name��59   )    .   .  .   .   5:   V   �� *Name+  5;      #
 [ 6)   # [ 6T   $ 	Last Name��5<   )    .   .  .   .   5=   V   �� *
LastName+  5>      #
 [ 6)   # [ 6T   $ Credit card number��5?   )    .   .  .   .   5@   V   �� *CreditCardNumber+  5A      #
 [ 6)   # [ 6T   $ Attempts number��5B   )    .   .  .   .   5C   V   �� *AttemptsNumber+5E      �� 5F      $��Unblock��6     CustomButtonStyle#��[ 6'   ��5G      �� *UnblockUserCommand+��6<   �� *SelectedUser+5H      �� 5K   
   -   5        $ EditProfileSection��5K      $ Vertical=�61   $	��580��6H   #��[ 6T   $y�	Collapsed=�6}   .+�5L      �� $ Vertical=�6   $��Center=�60   $��0, 100, 0, 30q�6M   .+�5M      �� $ 
Horizontal=�6   $��Stretch=�66   .+�5N      �� $��Name:              ��6   $��Center=�6:   $��Arial)�6\   $��12(�6o   ���#3c3c3c5O       �� 5P      -   5         ��Name$ NameTextBox��5P        CustomTextBoxStyle#��[ 6[   $	��150��6�   ��63   �� *	NameValue+$ TwoWay=�6�   5Q      �� 5R      $ 
Horizontal=�6   $��Stretch=�66   .+�5S      �� $��Surname:         ��6   $��Center=�68   $��Arial)�6Z   $��12(�6m   ���#3c3c3c5T       �� 5U      -   5        $ SurnameTextBox��5U      #��[ 6a   $	��150��6�   ��66   �� *SurnameValue+$ TwoWay=�6�   5V      �� 5W      $ 
Horizontal=�6   $��Stretch=�66   .+�5X      �� $��Card number:   ��6   $��Center=�66   $��Arial)�6X   $��12(�6k   ���#3c3c3c5Y       �� 5Z      -   5        $ CardTextBox��5Z      #��[ 6[   $	��150��6�   ��63   �� *	CardValue+$ TwoWay=�6�   5[      5\      �� 5]      $ 
Horizontal=�6   $��Center=�62   .+�5^      �� $��Cancel��6   #��[ 6P   ��6*   �� *EditCancelCommand+6P   �� 5_      $
��Done��6   #��[ 6L   $��15q�6w   ��6(   �� *EditDoneCommand+6w   5`      �� 5a      $ 
Horizontal=�6   $��Right=�62   .+�5b      �� $
��Back��6   #��[ 6H   $��	0,10,30,0q�6s   ��6(   �� *BackCommand+6s   5c      5d      5f      5g      