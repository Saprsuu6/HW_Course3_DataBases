   M S B A M L   `   `   `  ����A  =MusicZ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MusicZMusicZ  5   	   5clr-namespace:MusicZ.ViewModelsMusicZ.ViewModels  5   	   %    MusicZ.RegistrationAutorisation   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:MusicZ     5   	   1modelclr-namespace:MusicZ.ViewModels     5   	   -   5          � Title$  RegistrationAutorisation��5	   	   $	��200��6*   $	��300��67    � WindowStartupLocation$ CenterScreen=�6C    � WindowStyle$
 None=�6    � 	Resources 5
      #  MusicZ.ViewModels.ViewModelAR 
  ARView �� 
TargetType �� Property �� Value��%B  &	        '��      '�� �     '�� �       5   
   6   �� 5   
   " ��6   .�5      ��  � ��$ Center=�64   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   5      5      .��5      �  � DataContext# �   6    � RowDefinitions 5   
   �� 5      $
��145* �6   �� 5      $	��39* �6   .+�5!   
   � $��0��6   $��5q�6    5"      �� 5#      �� 5$      �� 5%      �� 5&      	 � ColumnDefinitions	 5)      �� 5*      �� 5+      .+�5.      �� $��0��6   $��0��6%   $��Name:��65   �� 5/      $��1��6   $��0��6%   $��	Surename:��65   �� 50      $��2��6   $��0��6%   $��Phone:��65   �� 51      $��3��6   $��0��6%   $��	Password:��65   �� 53      $��0��6   $��1��6#   ��54      �� *
Stuff.Name+
 �� UpdateSourceTrigger$
 PropertyChanged=��� 55      $��1��6   $��1��6#   ��56      �� *Stuff.Surename+$
 PropertyChanged=��� 57      $��2��6   $��1��6#   ��58      �� *Stuff.Phone+$
 PropertyChanged=��� 59      $��3��6   $��1��6#   ��5:      �� *Stuff.Password+$
 PropertyChanged=�5;      A� 5=   
   $��1��6    A� Columns$ 3��6#   .+�5>      �� $��Log in��6   ��6&   �� *LogIn+�� 5?      $��Sing up��6   ��6'   �� *SingUp+�� 5@      -   5        $��Cancel��5@      6&   5A      5B      5C      