   M S B A M L   `   `   `  ����G  CMusicZClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MusicZClientMusicZClient  5   	   A%clr-namespace:MusicZClient.ViewModelsMusicZClient.ViewModels  5   	   A%clr-namespace:MusicZClient.ConvertersMusicZClient.Converters  5   	       MusicZClient.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MusicZClient     5   	   6view%clr-namespace:MusicZClient.ViewModels     5   	   <
converters%clr-namespace:MusicZClient.Converters     5   	   -   5          � Title$  
MainWindow��5
   	   $	��450��6   $	��600��6)    � WindowStartupLocation$ CenterScreen=�65    � 	Resources 5      -  'MusicZClient.ViewModels.ViewModelClient   
ClientView+  %MusicZClient.ViewModels.ViewModelShop  ShopView2   ,MusicZClient.Converters.DateOfCheckConverter  DateOfCheckConverter.   (MusicZClient.Converters.IdStuffConverter  IdStuffConverter/   )MusicZClient.Converters.IdClientConverter  IdClientConverter.   (MusicZClient.Converters.IdAlbomConverter  IdAlbomConverter/   )MusicZClient.Converters.BirthdayConverter  BirthdayConverter+   %MusicZClient.Converters.NameConverter  NameConverter/	   )MusicZClient.Converters.BandNameConverter  BandNameConverter0
   *MusicZClient.Converters.PublisherConverter 	 PublisherConverter3   -MusicZClient.Converters.AmountTracksConverter 
 AmountTracksConverter,   &MusicZClient.Converters.GenreConverter  GenreConverter4   .MusicZClient.Converters.YearOfPublishConverter  YearOfPublishConverter3   -MusicZClient.Converters.YearOfAddingConverter  YearOfAddingConverter0   *MusicZClient.Converters.CostPriceConverter  CostPriceConverter3   -MusicZClient.Converters.PriceForSaleConverter  PriceForSaleConverter/   )MusicZClient.Converters.DiscountConverter  DiscountConverter-   'MusicZClient.Converters.NumberConverter  NumberConverter5   /MusicZClient.Converters.QuantityAlbomsConverter  QuantityAlbomsConverter �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker��%  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 �     &	
 �     &	 �     &	 �     &	 �     &	 
    &	     &	 0    &	 C    &	 V    '�� i    '	� �    '�� Q    '�� �    '�� �    '  X    '�� �      5   
   6     5   
   6     5   
   6*     5   
   6&     5   
   6'     5   
   6&     5   
   6'     5   
   6#   	  5   
   6'   
  5   
   6(     5   
   6+     5   
   6$     5   
   6,     5   
   6+     5   
   6(     5   
   6+     5   
   6'     5   
   6%     5   
   6-   �� 5!   
   " ��6   .�5"      ��  � ��$ Center=�64   �� 5#       � ��$ Center=�62   5$      �� 5&   
   " 	�6   .�5'      ��  � ��$ Center=�64   �� 5(       � ��$ Center=�62   5)      �� 5+   
   " ��6   .�5,      ��  � ��$ Center=�62   5-      �� 5/   
   " ��6   .�50      ��  � ��$ 5q�6'   51      �� 53   
   " ��6   .�54      ��  � ��$ Center=�64   �� 55       � ��$ Center=�62   56      �� 58   
   "  6   .�59      ��  � ��$ Center=�64   �� 5:       � ��$ Center=�62   5;      �� 5=   
   " ��6   .�5>      ��  � ��$ Center=�62   5?      5@      .��5B      �� .@�5C   
   �� $��Personal Info��6   .��5D      �  � DataContext# [  6    � ColumnDefinitions 5E      �� 5F      �� 5G      .+�5J      � $��0��6   $��5q�6'    � RowDefinitions 5K      �� 5L      �� 5M      �� 5N      �� 5O      �� 5P      �� 5Q      �� 5R       5U      �� 5V      $
��112* �6+   �� 5W      $
��153* �6+   .+�5Z      �� $��Name:��6    $��0��6-   $��0��6:   $��16��6J   $��34��6V   �� 5[      $��	Surename:��6    $��1��61   $��0��6>   $��16��6N   $��56��6Z   �� 5\      $��Phone:��6    $��2��6.   $��0��6;   $��16��6K   $��36��6W   �� 5]      $��	Password:��6    $��3��61   $��0��6>   $��16��6N   $��52��6Z   �� 5^      $��	Birthday:��6    $��4��61   $��0��6>   $��16��6N   $��46��6Z   �� 5`      $��0��6   $��1��6+   ��5a      �� *Client.Name+	 �� UpdateSourceTrigger$	 PropertyChanged=��� 5b      $��1��6   $��1��6+   ��5c      �� *Client.Surename+$	 PropertyChanged=��� 5d      $��2��6   $��1��6+   ��5e      �� *Client.Phone+$	 PropertyChanged=��� 5f      $��3��6   $��1��6+   ��5g      �� *Client.Password+$	 PropertyChanged=�  5h      $��4��6!   $��1��6.   
   Text
 5i   !   �� *
Birthday+$	 PropertyChanged=��� 5j      $��Remove account��6   $��5��66   $��2��6C   ��5k      �� *Remove+�� 5l      $��Update info��6   $��6��63   $��2��6@   ��5m      �� *	Upadate+5n      �� 5p      $��5q�6   $��1��6%   ��65   �� *Checks+ �� SelectedItem 5q      �� *Check+��5r      �� 5s      .R�5t      �� .+�5u   "   �� ��6,   �� *
Id_Stuff+ �� 	Converter# [ �� 5v   "   ��6,   �� *	Id_Client+# [ �� 5w   "   ��6,   �� *
Id_Albom+# [ �� 5x   "   ��6,   �� *AmountAlboms+ �� StringFormat$ Amount: {0}��# [ �� 5y   "   ��6,   �� *Date+# [ 5z      5{      5}      5~      5      �� 5�   
   $��Goods��6   .��5�      � # �  6    5�      �� 5�      �� 5�      .+�5�      �� $��0��6   $��5q�6*   ��65   �� *Alboms+ 5�      �� *Albom+��5�      �� 5�      .R�5�      �� .+�5�   "   �� ��6,   �� *Name+# [ �� 5�   "   ��6,   �� *
BandName+# [ �� 5�   "   ��6,   �� *	Publisher+# [	 �� 5�   "   ��6,   �� *AmountTracks+# [
 �� 5�   "   ��6,   �� *
Quantity+# [ �� 5�   "   ��6,   �� *Genre+# [ �� 5�   "   ��6,   �� *YearOfPublish+# [ �� 5�   "   ��6,   �� *YearOfAdding+# [ �� 5�   "   ��6,   �� *	CostPrice+# [ �� 5�   "   ��6,   �� *PriceForSale+# [ �� 5�   "   ��6,   �� *
Discount+# [ 5�      5�      5�      � 5�      $��1��6    5�      �� 5�      $
��129* �6(   �� 5�      $
��227* �6(   .+�5�      �� $��0��6   $��5,5,5,5q�6,   $��Buyings��6=   .��5�      �  5�      �� 5�   "   �� 5�   "    5�      �� 5�   "   $	��25* �63   �� 5�   "   $	��16* �63   �� 5�   "   $	��14* �63   .+�5�      �� $��Amount for buing:��6(   $��16��6A   $��98��6M   �� 5�      $��1��6(   $��
Reserving:��65   �� 5�      $��1��6&   $��18��66   ��5�   &   �� *Amount+$	 PropertyChanged=�# [ �� 5�      $	��Buy��6%   $��0��63   $��3��6@   ��5�   %   �� *Buy+�� 5�      $��Reserve��6%   $��1��67   $��2��6D   $��1��6X   ��5�   %   �� *	Reserve+5�      5�      �� 5�      $��1��6   $��5q�6,   $��Findings��67   .��5�      �  5�      �� 5�   "   �� 5�   "   �� 5�   "   �� 5�   "   �� 5�   "    5�      �� 5�   "   �� 5�   "   �� 5�   "   .+�5�      �� $��Name:��6(   $��0��65   $��0��6B   �� 5�      $��
Band name:��6(   $��1��6:   $��0��6G   �� 5�      $��Genre:��6(   $��2��66   $��0��6C   �� 5�      $��0��6&   $��1��63   ��5�   &   �� *
Albom.Name+$	 PropertyChanged=��� 5�      $��1��6&   $��1��63   ��5�   &   �� *Albom.BandName+$	 PropertyChanged=��� 5�      $��2��6&   $��1��63   ��5�   &   �� *Albom.Genre+$	 PropertyChanged=��� 5�      $��0��6%   $��2��62   $
��Find��6B   ��5�   %   �� *Find+�� 5�      $��1��6%   $��2��62   $��
All alboms��6B   ��5�   %   �� *	AllAlboms+�� 5�      $��2��6%   $��2��62   $
��News��6B   ��5�   %   �� *News+�� 5�      $��3��6%   $��0��62   $��3��6B   $��Popular��6V   ��5�   %   �� *	Popular+	� 5�      $��4��6*   $��0��67   $��By year��6G    d� 	IsChecked 5�   *   �� *PopularByYear+$	 PropertyChanged=�	� 5�      $��5��6*   $��1��67   $��By month��6G    5�   +   �� *PopularByMonth+$	 PropertyChanged=�	� 5�      $��6��6*   $��2��67   $��By week��6G    5�   +   �� *PopularByWeek+$	 PropertyChanged=�5�      5�      5�      5�      5�      5�      5�      