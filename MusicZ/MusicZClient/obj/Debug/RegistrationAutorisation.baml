   M S B A M L   `   `   `  ����G  CMusicZClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MusicZClientMusicZClient  5   	   A%clr-namespace:MusicZClient.ViewModelsMusicZClient.ViewModels  5   	   A%clr-namespace:MusicZClient.ConvertersMusicZClient.Converters  5   	   +    %MusicZClient.RegistrationAutorisation   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MusicZClient     5   	   7model%clr-namespace:MusicZClient.ViewModels     5   	   <
converters%clr-namespace:MusicZClient.Converters     5   	   -   5          � Title$  RegistrationAutorisation��5
   	   $	��200��6*   $	��300��67    � WindowStartupLocation$ CenterScreen=�6C    � WindowStyle$
 None=�6    � 	Resources 5      )  #MusicZClient.ViewModels.ViewModelAR 
  ARView+   %MusicZClient.Converters.NameConverter  NameConverter �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker��%�  &	        &	      '�� &     '  �     '�� �     '�� 2      5   
   6     5   
   6#   �� 5   
   " ��6   .�5      ��  � ��$ Center=�64   �� 5       � ��$ Center=�62   5      �� 5   
   "  6   .�5      ��  � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   5      5       .��5"      �  � DataContext# �   6    � RowDefinitions 5#   
   �� 5$      $
��145* �6   �� 5%      $	��39* �6   .+�5(   
   � $��0��6   $��5q�6    5)      �� 5*      �� 5+      �� 5,      �� 5-      �� 5.      	 � ColumnDefinitions	 51      �� 52      �� 53      .+�56      �� $��0��6   $��0��6%   $��Name:��65   �� 57      $��1��6   $��0��6%   $��	Surename:��65   �� 58      $��2��6   $��0��6%   $��Phone:��65   �� 59      $��3��6   $��0��6%   $��	Password:��65   �� 5:      $��4��6   $��0��6%   $��	Birthday:��65   �� 5<      $��0��6   $��1��6#   ��5=      �� *Client.Name+
 �� UpdateSourceTrigger$
 PropertyChanged=��� 5>      $��1��6   $��1��6#   ��5?      �� *Client.Surename+$
 PropertyChanged=��� 5@      $��2��6   $��1��6#   ��5A      �� *Client.Phone+$
 PropertyChanged=��� 5B      $��3��6   $��1��6#   ��5C      �� *Client.Password+$
 PropertyChanged=�  5D      $��4��6   $��1��6&      Text 5E      �� *
Birthday+$
 PropertyChanged=�5F      A� 5H   
   $��1��6    A� Columns$ 3��6#   .+�5I      �� $��Log in��6   ��6&   �� *LogIn+�� 5J      $��Sing up��6   ��6'   �� *SingUp+�� 5K      -   5        $��Cancel��5K      6&   5L      5M      5N      