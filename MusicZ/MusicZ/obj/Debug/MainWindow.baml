   M S B A M L   `   `   `  ����A  =MusicZ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MusicZMusicZ  5   	   5clr-namespace:MusicZ.ViewModelsMusicZ.ViewModels  5   	   5clr-namespace:MusicZ.ConvertersMusicZ.Converters  5   	       MusicZ.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:MusicZ     5   	   1modelclr-namespace:MusicZ.ViewModels     5   	   6
convertersclr-namespace:MusicZ.Converters     5   	   -   5          � Title$  MusicZ��5
   	   $	��450��6   $	��800��6%    � WindowStartupLocation$ CenterScreen=�61    � 	Resources 5      &   MusicZ.ViewModels.ViewModelStuff   	StuffView'  !MusicZ.ViewModels.ViewModelClient  
ClientView&   MusicZ.ViewModels.ViewModelCheck  	CheckView&   MusicZ.ViewModels.ViewModelAlbom  	AlbomView%   MusicZ.Converters.NameConverter  NameConverter)   #MusicZ.Converters.SurenameConverter  SurenameConverter&    MusicZ.Converters.PhoneConverter  PhoneConverter(   "MusicZ.Converters.ProcentConverter  ProcentConverter'	   !MusicZ.Converters.NumberConverter  NumberConverter0
   *MusicZ.Converters.IsRegularClientConverter 	 IsRegularClientConverter)   #MusicZ.Converters.BirthdayConverter 
 BirthdayConverter,   &MusicZ.Converters.DateOfCheckConverter  DateOfCheckConverter(   "MusicZ.Converters.IdStuffConverter  IdStuffConverter)   #MusicZ.Converters.IdClientConverter  IdClientConverter(   "MusicZ.Converters.IdAlbomConverter  IdAlbomConverter)   #MusicZ.Converters.BandNameConverter  BandNameConverter*   $MusicZ.Converters.PublisherConverter  PublisherConverter-   'MusicZ.Converters.AmountTracksConverter  AmountTracksConverter&    MusicZ.Converters.GenreConverter  GenreConverter.   (MusicZ.Converters.YearOfPublishConverter  YearOfPublishConverter-   'MusicZ.Converters.YearOfAddingConverter  YearOfAddingConverter*   $MusicZ.Converters.CostPriceConverter  CostPriceConverter-   'MusicZ.Converters.PriceForSaleConverter  PriceForSaleConverter)   #MusicZ.Converters.DiscountConverter  DiscountConverter)   #MusicZ.Converters.ReservedConverter  ReservedConverter/   )MusicZ.Converters.QuantityAlbomsConverter  QuantityAlbomsConverter �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker��%i  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 �     &	
 �     &	 �     &	 �     &	 �     &	 
    &	     &	 0    &	 C    &	 V    &	 i    &	 |    &	 �    &	 �    &	 �    &	 �    &	 �    '�� �    '�� b    '�� �    '�� �    '  i    '�� �      5   
   6     5   
   6      5   
   6     5   
   6     5   
   6#     5   
   6'     5   
   6$     5   
   6&   	  5   
   6%   
  5   
   6.     5   
   6'     5   
   6*     5   
   6&     5   
   6'     5   
   6&     5   
   6'     5   
   6(     5   
   6+     5   
   6$     5    
   6,     5!   
   6+     5"   
   6(     5#   
   6+     5$   
   6'     5%   
   6'     5&   
   6-   �� 5(   
   " ��6   .�5)      ��  � ��$ Center=�64   �� 5*       � ��$ Center=�62   5+      �� 5-   
   " ��6   .�5.      ��  � ��$ Center=�62   5/      �� 51   
   " ��6   .�52      ��  � ��$ 5q�6'   53      �� 55   
   " ��6   .�56      ��  � ��$ Center=�64   �� 57       � ��$ Center=�62   58      �� 5:   
   "  6   .�5;      ��  � ��$ Center=�64   �� 5<       � ��$ Center=�62   5=      �� 5?   
   " ��6   .�5@      ��  � ��$ Center=�62   5A      5B      .��5D      �� .@�5E   
   �� $��Stuffs��6   .��5F      �  � DataContext# �   6    � ColumnDefinitions 5G      �� 5H      �� 5I      �� 5J      .+�5M      � $��0��6   $��5q�6'    � RowDefinitions 5N      �� 5O      �� 5P      �� 5Q      �� 5R       5U      �� 5V      �� 5W      .+�5Z      �� $��0��6    $��0��60   $��Name:��6=   �� 5[      $��0��6    $��1��60   $��	Surename:��6=   �� 5\      $��0��6    $��2��60   $��Phone:��6=   �� 5]      $��0��6    $��3��60   $��Procent from sale:��6=   �� 5_      $��1��6   $��0��6.   ��5`      �� *
Stuff.Name+	 �� UpdateSourceTrigger$	 PropertyChanged=��� 5a      $��1��6   $��1��6.   ��5b      �� *Stuff.Surename+$	 PropertyChanged=��� 5c      $��1��6   $��2��6.   ��5d      �� *Stuff.Phone+$	 PropertyChanged=��� 5e      $��1��6   $��3��6.   ��5f      �� *Stuff.ProcentFromsale+$	 PropertyChanged=�
 �� 	Converter#
 [ 5h      A� 5j      $��1��6    A� Rows$ 5��6.   $��5q�67   .+�5k      �� $��Remove stuff��6   $��1��64   ��5l      �� *Remove+�� 5m      $��Update stuff��6   $��2��64   ��5n      �� *	Upadate+�� 5o      $��Find stuffs��6   $��3��63   ��5p      �� *Find+�� 5q      $��
All Staffs��6   $��3��62   ��5r      �� *	AllStuffs+�� 5s      $��Clear fiels��6   $��3��63   ��5t      �� *ClearFields+5u      �� 5w      $��2��6   $��5q�6*   ��65   �� *Stuffs+ �� SelectedItem 5x      �� *Stuff+��5y      �� 5z      .R�5{      �� .+�5|   "   �� ��6,   �� *Name+ �� StringFormat$ 	Name: {0}���� 5}   "   ��6,   �� *
Surename+$ Surename: {0}���� 5~   "   ��6,   �� *Phone+$ 
Phone: {0}���� 5   "   ��6,   �� *ProcentFromsale+$ Procent from sale: {0}%��5�      5�      5�      5�      5�      �� 5�   
   $��Clients��6   $��22��6#   $��Bottom=�6/   .��5�      � # [ 6    5�      �� 5�      �� 5�      �� 5�      .+�5�      � $��0��6   $��5q�6'    5�      �� 5�      �� 5�      �� 5�      �� 5�       5�      �� 5�      �� 5�      .+�5�      �� $��0��6    $��0��60   $��Name:��6=   �� 5�      $��0��6    $��1��60   $��	Surename:��6=   �� 5�      $��0��6    $��2��60   $��Phone:��6=   �� 5�      $��0��6    $��3��60   $��Is regular client:��6=   �� 5�      $��1��6   $��0��6.   ��5�      �� *Client.Name+$	 PropertyChanged=��� 5�      $��1��6   $��1��6.   ��5�      �� *Client.Surename+$	 PropertyChanged=��� 5�      $��1��6   $��2��6.   ��5�      �� *Client.Phone+$	 PropertyChanged=��� 5�      $��1��6   $��3��6/    d� 	IsChecked 5�      �� *Client.IsRegularClient+$	 PropertyChanged=�5�      A� 5�      $��1��6   $ 4��6.   $��5q�67   .+�5�      �� $��Update client��6   $��3��65   ��5�      �� *	Upadate+�� 5�      $��Find client��6   $��3��63   ��5�      �� *Find+�� 5�      $��
All client��6   $��3��62   ��5�      �� *
AllClients+�� 5�      $��Clear client��6   $��3��64   ��5�      �� *ClearFields+5�      �� 5�      $��2��6   $��5q�6*   ��65   �� *	Clients+ 5�      �� *Client+��5�      �� 5�      .R�5�      �� .+�5�   "   �� ��6,   �� *Name+$ 	Name: {0}���� 5�   "   ��6,   �� *
Surename+$ Surename: {0}���� 5�   "   ��6,   �� *Phone+$ 
Phone: {0}���� 5�   "   ��6,   �� *
Birthday+$ Birthday: {0}���� 5�   "   ��6,   �� *IsRegularClient+#
 [	 5�      5�      5�      5�      5�      �� 5�   
   $��Alboms��6   .��5�      � # [ 6    5�      �� 5�      �� 5�      �� 5�      .+�5�      � $��0��6   $��5q�6'    5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�       5�      �� 5�      �� 5�      .+�5�      �� $��0��6    $��0��60   $��Name:��6=   �� 5�      $��0��6    $��1��60   $��
Band name:��6=   �� 5�      $��0��6    $��2��60   $��	Publsher:��6=   �� 5�      $��0��6    $��3��60   $��Amount tracks:��6=   �� 5�      $��0��6    $��4��60   $��	Quantity:��6=   �� 5�      $��0��6    $��5��60   $��Genre:��6=   �� 5�      $��0��6    $��6��60   $��Year of publish:��6=   �� 5�      $��0��6    $��7��60   $��Cost price:��6=   �� 5�      $��0��6    $��8��60   $��Price for sale:��6=   �� 5�      $��0��6    $��9��60   $��	Discount:��6=   �� 5�      $��1��6   $��0��6.   ��5�      �� *
Albom.Name+$	 PropertyChanged=��� 5�      $��1��6   $��1��6.   ��5�      �� *Albom.BandName+$	 PropertyChanged=��� 5�      $��1��6   $��2��6.   ��5�      �� *Albom.Publisher+$	 PropertyChanged=��� 5�      $��1��6   $��3��6.   ��5�      �� *Albom.AmountTracks+$	 PropertyChanged=�#
 [ �� 5�      $��1��6   $��4��6.   ��5�      �� *Albom.Quantity+$	 PropertyChanged=�#
 [ �� 5�      $��1��6   $��5��6.   ��5�      �� *Albom.Genre+$	 PropertyChanged=��� 5�      $��1��6   $��6��6.   ��5�      �� *Albom.YearOfPublish+$	 PropertyChanged=�#
 [ �� 5�      $��1��6   $��7��6.   ��5�      �� *Albom.CostPrice+$	 PropertyChanged=�#
 [ �� 5     $��1��6   $��8��6.   ��5     �� *Albom.PriceForSale+$	 PropertyChanged=�#
 [ �� 5     $��1��6   $��9��6.   ��5     �� *Albom.Discount+$	 PropertyChanged=�#
 [ 5     A� 5	     $��1��6   $ 6��6.   $��5q�67   .+�5
     �� $��	Add albom��6   $��1��61   ��5     �� *Add+�� 5     $��Remove albom��6   $��3��64   ��5     �� *Remove+�� 5     $��Update albom��6   $��1��64   ��5     �� *	Upadate+�� 5     $��
Find albom��6   $��3��62   ��5     �� *Find+�� 5     $��	All albom��6   $��3��61   ��5     �� *	AllAlboms+�� 5     $��Clear albom��6   $��3��63   ��5     �� *ClearFields+5     �� 5     $��2��6   $��5q�6*   ��65   �� *Alboms+ 5     �� *Albom+��5     �� 5     .R�5     �� .+�5  "   �� ��6,   �� *Name+$ 	Name: {0}���� 5  "   ��6,   �� *
BandName+$ Band name: {0}���� 5  "   ��6,   �� *	Publisher+$ Publisher: {0}���� 5   "   ��6,   �� *AmountTracks+$ Amount tracks: {0}���� 5!  "   ��6,   �� *
Quantity+#
 [ �� 5"  "   ��6,   �� *Genre+#
 [ �� 5#  "   ��6,   �� *YearOfPublish+#
 [ �� 5$  "   ��6,   �� *YearOfAdding+#
 [ �� 5%  "   ��6,   �� *	CostPrice+#
 [ �� 5&  "   ��6,   �� *PriceForSale+#
 [ �� 5'  "   ��6,   �� *
Discount+#
 [ �� 5(  "   ��6,   �� *ReservedByClient+#
 [ 5)     5*     5,     5-     5.     �� 50  
   $��Checks��6   .��51     � # [ 6    52     �� 53     �� 54     .+�57     A� $��0��6   $ 4��6.   $��5q�67   .+�58     �� $��Remove check��6   $��3��64   ��59     �� *Remove+�� 5:     $��
Find check��6   $��3��62   ��5;     �� *Find+�� 5<     $��
All checks��6   $��3��62   ��5=     �� *	AllChecks+�� 5>     $��Clear client��6   $��3��64   ��5?     �� *ClearFields+5@     �� 5B     $��1��6   $��5q�6*   ��65   �� *Checks+ 5C     �� *Check+��5D     �� 5E     .R�5F     �� .+�5G  "   �� ��6,   �� *
Id_Stuff+#
 [ �� 5H  "   ��6,   �� *	Id_Client+#
 [ �� 5I  "   ��6,   �� *
Id_Albom+#
 [ �� 5J  "   ��6,   �� *Date+#
 [
 5K     5L     5N     5O     5P     5Q     5R     