   M S B A M L   `   `   `  ����I  EBooksInLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BooksInLibraryBooksInLibrary  5   	   ?$clr-namespace:BooksInLibrary.AuthorsBooksInLibrary.Authors  5   	   ?$clr-namespace:BooksInLibrary.PressesBooksInLibrary.Presses  5   	   E'clr-namespace:BooksInLibrary.CategoriesBooksInLibrary.Categories  5	   	   ;"clr-namespace:BooksInLibrary.BooksBooksInLibrary.Books  5
   	   =#clr-namespace:BooksInLibrary.ThemesBooksInLibrary.Themes  5   	   E'clr-namespace:BooksInLibrary.ConvertersBooksInLibrary.Converters  5   	       BooksInLibrary.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BooksInLibrary     5   	   8authors$clr-namespace:BooksInLibrary.Authors     5   	   8presses$clr-namespace:BooksInLibrary.Presses     5   	   >
categories'clr-namespace:BooksInLibrary.Categories     5	   	   4books"clr-namespace:BooksInLibrary.Books     5
   	   6themes#clr-namespace:BooksInLibrary.Themes     5   	   >
converters'clr-namespace:BooksInLibrary.Converters     5   	     � Title$  Library��5   	   $	��500��6   $	��800��6&    � WindowStartupLocation$ CenterScreen=�62    � 	Resources 5      &   BooksInLibrary.Authors.ViewModel   ViewAuthors&   BooksInLibrary.Presses.ViewModel  ViewPresses)  #BooksInLibrary.Categories.ViewModel  ViewCategories%  BooksInLibrary.Themes.ViewModel  
ViewThemes$  BooksInLibrary.Books.ViewModel  	ViewBooks1  +BooksInLibrary.Converters.AuthorIdConverter  AuthorIdConverter3  -BooksInLibrary.Converters.AuthorNameConverter  AuthorNameConverter7  1BooksInLibrary.Converters.AuthorSurenameConverter  AuthorSurenameConverter0	  *BooksInLibrary.Converters.PressIdConverter  PressIdConverter2
  ,BooksInLibrary.Converters.PressNameConverter 	 PressNameConverter3  -BooksInLibrary.Converters.CategoryIdConverter 
 CategoryIdConverter5  /BooksInLibrary.Converters.CategoryNameConverter  CategoryNameConverter0  *BooksInLibrary.Converters.ThemeIdConverter  ThemeIdConverter2  ,BooksInLibrary.Converters.ThemeNameConverter  ThemeNameConverter/  )BooksInLibrary.Converters.BookIdConverter  BookIdConverter1  +BooksInLibrary.Converters.BookNameConverter  BookNameConverter2  ,BooksInLibrary.Converters.BookPagesConverter  BookPagesConverter6  0BooksInLibrary.Converters.BookYearPressConverter  BookYearPressConverter5  /BooksInLibrary.Converters.BookCategoryConverter  BookCategoryConverter2  ,BooksInLibrary.Converters.BookThemeConverter  BookThemeConverter3  -BooksInLibrary.Converters.BookAuthorConverter  BookAuthorConverter2  ,BooksInLibrary.Converters.BookPressConverter  BookPressConverter4  .BooksInLibrary.Converters.BookCommentConverter  BookCommentConverter5  /BooksInLibrary.Converters.BookQuantityConverter  BookQuantityConverter0  *BooksInLibrary.Converters.NumericConverter  NumericConverter �� 
TargetType �� Property �� Value��%K  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 �     &	
 �     &	 �     &	 �     &	 �     &	 
    &	     &	 0    &	 C    &	 V    &	 i    &	 |    &	 �    &	 �    &	 �    &	 �    '�� �    '�� O    '�� �    '�� �      5   
   6     5   
   6     5   
   6     5   
   6     5   
   6     5   
   6'     5   
   6)     5   
   6-   	  5   
   6&   
  5   
   6(     5   
   6)     5   
   6+     5    
   6&     5!   
   6(     5#   
   6%     5$   
   6'     5%   
   6(     5&   
   6,     5'   
   6+     5(   
   6(     5)   
   6)     5*   
   6(     5+   
   6*     5,   
   6+     5.   
   6&   �� 50   
   " ��6   .�51      ��  � ��$ Center=�64   �� 52       � ��$ Center=�62   53      �� 55   
   " ��6   .�56      ��  � ��$ Center=�62   57      �� 59   
   " ��6   .�5:      ��  � ��$ 5q�6'   5;      �� 5=   
   " ��6   .�5>      ��  � ��$ 1q�6'   5?      5@      .��5B      � .+�5C   
   �� .@�5D      �� $��Authors��6   .��5E      A�  A� Columns$ 2��6    � DataContext# [  6*   .+�5F      �  � RowDefinitions 5G      �� 5H      �� 5I      .+�5L      �� $��Author��6#   $��5q�64   .��5M      � $��0��6#   	 � ColumnDefinitions	 5N   "   �� 5O   &   $��80 �67   �� 5P   &    5S   "   �� 5T   &   �� 5U   &   .+�5X   "   �� $��0��6,   $��0��69   $��Name:��6I   �� 5Y   "   $��1��6,   $��0��69   $��	Surename:��6I   �� 5[   "   $��0��6*   $��1��67   ��5\   *   �� *Author.Name+
 �� UpdateSourceTrigger$
 PropertyChanged=��� 5^   "   $��1��6*   $��1��67   ��5_   *   �� *Author.Surename+$
 PropertyChanged=�5a      5b      A� 5d       A� Rows$ 6��6&   $��1��6/   .+�5e      �� $��
Add author��6%   ��6:   �� *	AddAuthor+�� 5f      $��Remove author��6%   ��6=   �� *RemoveAuthor+�� 5g      $��Update author��6%   ��6=   �� *UpdateAuthor+�� 5h      $��Find authors��6%   ��6<   �� *FindAuthors+�� 5i      $��Clear fiels��6%   ��6;   �� *ClearFields+�� 5j      $��Refresh base��6%   ��6<   �� *RefreshBase+5k      5l      � 5n      .+�5o      �� $��5q�6"   ��6-   �� *	Authors+ �� SelectedItem 5p   "   �� *Author+��5q      �� 5r   "   .R�5s   &   �� .+�5t   *   �� ��64   �� *Id+ �� 	Converter# [ �� 5v   *   ��64   �� *Name+# [ �� 5x   *   ��64   �� *
Surename+# [ 5z   '   5{   #   5}      5~      5      5�      �� 5�      $��Press��6   .��5�      A� $ 2��6   # [ 6*   .+�5�      �  5�      �� 5�      $	��100 �6,   �� 5�      .+�5�      �� $��Author��6#   $��5q�64   .��5�      � $��0��6#   	 5�   "   �� 5�   &   $��80 �67   �� 5�   &   .+�5�   "   �� $��0��6,   $��Name:��6<   �� 5�   "   $��1��6*   ��5�   *   �� *
Press.Name+$
 PropertyChanged=�5�      5�      A� 5�      $ 6��6&   $��1��6/   .+�5�      �� $��	Add press��6%   ��69   �� *
AddPress+�� 5�      $��Remove press��6%   ��6<   �� *RemovePress+�� 5�      $��Update press��6%   ��6<   �� *UpdatePress+�� 5�      $��Find presses��6%   ��6<   �� *FindPresses+�� 5�      $��Clear fiels��6%   ��6;   �� *ClearFields+�� 5�      $��Refresh base��6%   ��6<   �� *RefreshBase+5�      5�      � 5�      .+�5�      �� $��5q�6"   ��6-   �� *	Presses+ 5�   "   �� *Press+��5�      �� 5�   "   .R�5�   &   �� .+�5�   *   �� ��64   �� *Id+# [ �� 5�   *   ��64   �� *Name+# [	 5�   '   5�   #   5�      5�      5�      5�      �� 5�      $��
Categories��6   .��5�      A� $ 2��6   # [ 6*   .+�5�      �  5�      �� 5�      $	��100 �6,   �� 5�      .+�5�      �� $��Author��6#   $��5q�64   .��5�      � $��0��6#   	 5�   "   �� 5�   &   $��80 �67   �� 5�   &   .+�5�   "   �� $��0��6,   $��Name:��6<   �� 5�   "   $��1��6*   ��5�   *   �� *Category.Name+$
 PropertyChanged=�5�      5�      A� 5�      $ 6��6&   $��1��6/   .+�5�      �� $��Add category��6%   ��6<   �� *AddCategory+�� 5�      $��Remove category��6%   ��6?   �� *RemoveCategory+�� 5�      $��Update category��6%   ��6?   �� *UpdateCategory+�� 5�      $��Find categories��6%   ��6?   �� *FindCategories+�� 5�      $��Clear fiels��6%   ��6;   �� *ClearFields+�� 5�      $��Refresh base��6%   ��6<   �� *RefreshBase+5�      5�      � 5�      .+�5�      �� $��5q�6"   ��6-   �� *
Categories+ 5�   "   �� *
Category+��5�      �� 5�   "   .R�5�   &   �� .+�5�   *   �� ��64   �� *Id+# [
 �� 5�   *   ��64   �� *Name+# [ 5�   '   5�   #   5�      5�      5�      5�      �� 5�      $��Themes��6   .��5�      A� $ 2��6   # [ 6*   .+�5�      �  5�      �� 5�      $	��100 �6,   �� 5�      .+�5�      �� $��Author��6#   $��5q�63   .��5�      � $��0��6#   	 5�   "   �� 5�   &   $��80 �67   �� 5�   &   .+�5�   "   �� $��0��6,   $��Name:��6<   �� 5�   "   $��1��6*   ��5�   *   �� *
Theme.Name+$
 PropertyChanged=�5�      5�      A� 5�      $ 6��6&   $��1��6/   .+�5�      �� $��	Add theme��6%   ��69   �� *
AddTheme+�� 5      $��Remove theme��6%   ��6<   �� *RemoveTheme+�� 5     $��Update theme��6%   ��6<   �� *UpdateTheme+�� 5     $��Find themes��6%   ��6;   �� *
FindThemes+�� 5     $��Clear fiels��6%   ��6;   �� *ClearFields+�� 5     $��Refresh base��6%   ��6<   �� *RefreshBase+5     5     � 5     .+�5	     �� $��5q�6"   ��6-   �� *Themes+ 5
  "   �� *Theme+��5     �� 5  "   .R�5  &   �� .+�5  *   �� ��64   �� *Id+# [ �� 5  *   ��64   �� *Name+# [ 5  '   5  #   5     5     5     5     �� 5     $��Books��6   .��5     A� $ 2��6   # [ 6*   .+�5     �  5     �� 5     $	��250 �6,   �� 5     .+�5"     �� $��Author��6#   $��5q�64   .��5#     � $��0��6#   	 5$  "   �� 5%  &   $��80 �67   �� 5&  &    5)  "   �� 5*  &   �� 5+  &   �� 5,  &   �� 5-  &   �� 5.  &   �� 5/  &   �� 50  &   �� 51  &   �� 52  &   .+�55  "   �� $��0��6,   $��0��69   $��Name:��6I   �� 56  "   $��1��6,   $��0��69   $��Pages:��6I   �� 57  "   $��2��6,   $��0��69   $��Year press:��6I   �� 58  "   $��3��6,   $��0��69   $��Theme:��6I   �� 59  "   $��4��6,   $��0��69   $��	Category:��6I   �� 5:  "   $��5��6,   $��0��69   $��Author:��6I   �� 5;  "   $��6��6,   $��0��69   $��Press:��6I   �� 5<  "   $��7��6,   $��0��69   $��Comment:��6I   �� 5=  "   $��8��6,   $��0��69   $��	Quantity:��6I   �� 5?  "   $��0��6*   $��1��67   ��5@  *   �� *	Book.Name+$
 PropertyChanged=��� 5B  "   $��1��6*   $��1��67   ��5C  *   �� *
Book.Pages+$
 PropertyChanged=�# [ �� 5F  "   $��2��6*   $��1��67   ��5G  *   �� *Book.YearPress+$
 PropertyChanged=�# [ �� 5K  "   $��3��6+   $��1��68    �� DisplayMemberPath$
 Name��5N  +   ��5L  +   �� *Themes+ 5M  +   �� *Theme+5N  +   �� 5O  "   $��4��6+   $��1��68   $
 Name��5R  +   ��5P  +   �� *
Categories+ 5Q  +   �� *
Category+5R  +   �� 5S  "   $��5��6+   $��1��68   $
 Name��5V  +   ��5T  +   �� *	Authors+ �� SelectedValue 5U  +   �� *Author+5V  +   �� 5W  "   $��6��6+   $��1��68   $
 Name��5Z  +   ��5X  +   �� *	Presses+ 5Y  +   �� *Press+5Z  +   �� 5\  "   $��7��6*   $��1��67   ��5]  *   �� *Book.Comment+$
 PropertyChanged=��� 5_  "   $��8��6*   $��1��67   ��5`  *   �� *Book.Quantity+$
 PropertyChanged=�# [ 5c     5d     A� 5f     $ 6��6&   $��1��6/   .+�5g     �� $��Add book��6%   ��68   �� *	AddBook+�� 5h     $��Remove book��6%   ��6;   �� *
RemoveBook+�� 5i     $��Update book��6%   ��6;   �� *
UpdateBook+�� 5j     $��
Find books��6%   ��6:   �� *	FindBooks+�� 5k     $��Clear fiels��6%   ��6;   �� *ClearFields+�� 5l     $��Refresh base��6%   ��6<   �� *RefreshBase+5m     5n     � 5p     .+�5q     �� $��5q�6"   ��6-   �� *Books+ 5r  "   �� *Book+��5s     �� 5t  "   .R�5u  &   �� .+�5v  *   �� ��64   �� *Id+# [ �� 5x  *   ��64   �� *Name+# [ �� 5z  *   ��64   �� *Pages+# [ �� 5|  *   ��64   �� *	YearPress+# [ �� 5~  *   ��64   �� *	IdTheme+# [ �� 5�  *   ��64   �� *
IdCategory+# [ �� 5�  *   ��64   �� *
IdAuthor+# [ �� 5�  *   ��64   �� *	IdPress+# [ �� 5�  *   ��64   �� *	Comment+# [ �� 5�  *   ��64   �� *
Quantity+# [ 5�  '   5�  #   5�     5�     5�     5�     5�     5�     5�     