   M S B A M L   `   `   `  ����>  :ATM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ATM.ViewModelsATM.ViewModels  5   	       ATM.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ATM.ViewModels     5   	     � Title$	  ATM��5   	   $	��450��6   $	��800��6"    � DataContext 5	      "   ATM.ViewModels.MainViewModel  5
   
   .��5      �� $��Center=�6   .+�5   
   �� -   5         ��Name$ RegisterSection��5       �� Orientation$ 
Horizontal=�6.   $y�	Collapsed=�6G   .+�5      �� .+�5      ��    SignInImage#��[  6   $	��300��6=   $	��450��6J   5      �� 5      $ Vertical=�6   $	��350��60   .+�5      �� $��Register��6   $��Center=�6+   $��	0,20,0,30q�6H   $��Ariel)�6[   $��30(�6n   ���#3c3c3c$��Oblique$�5   -   $��
ExtraBlack"�6A   6\   �� 5      $ 
Horizontal=�6   $��Stretch=�66   .+�5      �� $��Name:              ��6   $��Center=�6:   $��Arial)�6\   $��12(�6o   ���#3c3c3c5      �� 5      -   5         ��Name$ NameTextBox��5        CustomTextBoxStyle#��[ 6[   $	��150��6�   ��63   �� *	NameValue+ �� Mode$ TwoWay=�6�   5      �� 5      $ 
Horizontal=�6   $��Stretch=�66   .+�5      �� $��Surname:         ��6   $��Center=�68   $��Arial)�6Z   $��12(�6m   ���#3c3c3c5       �� 5!      -   5        $ SurnameTextBox��5!      #��[ 6a   $	��150��6�   ��66   �� *SurnameValue+$ TwoWay=�6�   5"      �� 5#      $ 
Horizontal=�6   $��Stretch=�66   .+�5$      �� $��Card number:   ��6   $��Center=�66   $��Arial)�6X   $��12(�6k   ���#3c3c3c5%      �� 5&      -   5        $ CardTextBox��5&      #��[ 6[   $	��150��6�   ��63   �� *	CardValue+$ TwoWay=�6�   5'      �� 5(      -   5         ��Name$ RegisterMessageTextBox��5(      $
��Auto��6i   $��15q�5)      $��Arial)�6&   $��16(�69   
���\\��$��Center=�6^   $
��Bold"�5*      $��SemiExpanded&�6,   
������ |�.  ��5(   8   �� *RegisterMessage+$ TwoWay=�5*   a   �� 5+      $��Register��6     CustomButtonStyle#��[ 6P   ��6,   �� *RegisterCommand+6P   �� 5,      $ 
Horizontal=�6   $��0,20,0,0q�66   $��Center=�6H   .+�5-      �� $��Already an user?��6   $��Arial)�67   $��12(�6J   ���#3c3c3c$��0,0,10,0q�5.      60   �� 5/      -   5         ��Name$ SwitchToSignIn��5/      $
��Auto��65   $��0q�6B   $��Sign In��6M   
������ 
������ $
��Bold"�50   P   $��Arial)�51      $��12(�60   ���#3c3c3c$��Italic$�6S   ��52      �� *SwitchToSignInCommand+53      54      55      �� 58   
   -   5        $ SignInSection��58      $ 
Horizontal=�6,   $y�Visible=�6E   .+�59      �� $ Vertical=�6   $	��350��60   .+�5:      �� $��Sign In��6   $��Center=�6*   $��	0,20,0,40q�6G   $��Ariel)�6Z   $��30(�6m   ���#3c3c3c$��Oblique$�5;   -   $��
ExtraBlack"�6A   6\   �� 5<      $ 
Horizontal=�6   $��Center=�66   .+�5=      �� $��Card: ��6   $��Center=�6-   $��Arial)�6O   $��12(�6b   ���#3c3c3c5>      �� 5?      -   5        $ LogInCardTextBox��5?      #��[ 6e   $	��150��6�   ��68   �� *LogInCardValue+$ TwoWay=�6�   5@      �� 5A      $ 
Horizontal=�6   $��Center=�66   .+�5B      �� $��PIN:   ��6   $��Center=�6.   $��Arial)�6P   $��12(�6c   ���#3c3c3c5C      �� 5D      -	   5        $ 
PinTextBox��5D      #��[ 6Y   $	��150��6�   ��62   �� *
PinValue+$ TwoWay=�6�   5E      �� 5F      -
   5        $ MessageTextBox��5F      $
��Auto��6Y   $��15q�5G      $��Arial)�6&   $��16(�69   
���\\��$��Center=�6^   $
��Bold"�5H      $��SemiExpanded&�6,   
������ |�.  ��5F   0   �� *	Message+$ TwoWay=�5H   a   �� 5I      $��Sign In��6   #��[ 6M   ��6+   �� *SignInCommand+6M   �� 5J      $ 
Horizontal=�6   $��0,20,0,0q�66   $��Center=�6H   .+�5K      �� $��Don't have an account?��6   $��Arial)�6=   $��12(�6P   ���#3c3c3c$��0,0,10,0q�5L      60   �� 5M      -   5        $ SwitchToRegister��5M      $
��Auto��67   $��0q�6D   $��Register��6O   
������ 
������ $
��Bold"�5N   P   $��Arial)�5O      $��12(�60   ���#3c3c3c$��Italic$�6S   ��5P      �� *SwitchToRegisterCommand+5Q      5R      �� 5S      .+�5T      �� #��[  6   $	��300��6=   $	��450��6J   5U      5V      5Y      5Z      