   M S B A M L   `   `   `  ����C  ?Lesson07, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Lesson07.ViewsLesson07.Views  5          Lesson07.Views.SalesView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Lesson07.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��5      $��3��5      $��	25,25,0,0q�5       5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6)   .+�5       �� $��0��5!      $��0��5"      $	��250��5#      $��40��5$      $��10q�5%      $
��Left=�5&      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search sales...��5'       !  MaterialDesignOutlinedTextBox#��[  5(      ��5)      �� *SearchString+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5*      -   5        $��CustomersCombobox��5+      $��0��5,      $��1��5-      $	��200��5.      $��40��5/      $��15,0,0,0q�50      $��10q�51      $ Filter by customer��52       �� DisplayMemberPath$
 Name��53       " MaterialDesignOutlinedComboBox#��[ 56      ��54      �� *	Customers+ �� SelectedItem 55      �� *SelectedCustomer+56      (  "System.Windows.Controls.DatePicker  57      $	��125��58      $��40��59      $��15,0,0,0q�5:      $��5q�5;      $
��Left=�5<      $ 	Date From��5=       $  MaterialDesignOutlinedDatePicker#��[ 5A         DisplayDateEnd 5>      �� *	EndDate+	   DisplayDateStart	 5?      �� *	StartDate+
   SelectedDate
 5@      �� *SelectedDateFrom+5A        5B      $	��125��5C      $��40��5D      $��15,0,0,0q�5E      $��5q�5F      $
��Left=�5G      $ 
Date Until��5H      #��[ 5J      
 5I      �� *SelectedDateUntil+5J      5K      �� 5L      $��1��5M      $	��125��5N      $��40��5O      $��0,0,25,0q�5P      $��Right=�5Q      ���#6dc78b$��0q�5S      ��5T      �� *CreateCommand+.��5U      �� $ 
Horizontal=�6   .+�5V      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ PlusBold=�6.   �� 5W      $��5,0,0,0q�5X      $
��Bold"�5Y      $��Create��5Z      5[      5\      5]      � 5`   
   $��1��5a      $��3��5b      $��25,10,25,10q�5c      .+�5d      �� $��0,20,0,0q�5e       �� Padding$ 5q�5f      ���#f7f5f5$��1q�5h       �� CornerRadius$ 15��5i      ._�5j      &   System.Windows.Controls.DataGrid  -   5          Name$ SalesDataGrid��5k      $��Stretch=�5l      $��Stretch=�5m         AutoGenerateColumns$ False��5n      ���#f7f5f5   
IsReadOnly$
 True��5p      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5q         SelectionMode$ Single=�5t         SelectionUnit$ FullRow=�5u      "   VerticalScrollBarVisibility$
 Auto=�5v      ��5r      �� *Sales+ 5s      �� *SelectedSales+   Columns 5w      0  *System.Windows.Controls.DataGridTextColumn  5x      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *Id+6D     5y      $ 	Total Duo��6J    6-   �� *
TotalDue+6J     5z      $ 
Total Paid��6K    6-   �� *	TotalPaid+6K     5{      $ Total Discount��6O    6-   �� *TotalDiscount+6O     5|      $ 	Sale Date��6J    6-   �� *
SaleDate+6J     5}      $ 	 Customer��6T    6-   �� *Customer.FirstName+6T   5      5�      5�      � 5�   
   $��2��5�      $��3��5�      $��
25,25,0,25q�5�       5�      �� 5�      $
��Auto �6#   �� 5�      $��* �6#   .+�5�      �� $��0��6   $ 
Horizontal=�6)   .+�5�      �� $��40��5�      $	��8,0q�5�      $��0q�5�      ��5�      �� *PrimaryPageCommand+{�5�      �� *IsEnablePrimaryPage+.��5�        $ SkipBackward=�6.   5�      �� 5�      $��40��5�      $��0q�5�      ��5�      �� *PrevPageCommand+{�5�      �� *IsEnablePrevPage+.��5�        $ 	ArrowLeft=�6.   5�      �� 5�      $	��150��5�       �� Padding$ 	40,0,40,0q�5�      $��Center=�5�      $��16)�5�      ��5�      �� *
PageString+�� 5�      $��40��5�      $��20,0,0,0q�5�      $��0q�5�      ��5�      �� *NextPageCommand+{�5�      �� *IsEnableNextPage+.��5�        $ 
ArrowRight=�6.   5�      �� 5�      $��40��5�      $	��8,0q�5�      $��0q�5�      ��5�      �� *LastPageCommand+{�5�      �� *IsEnableLastPage+.��5�        $ SkipForward=�6.   5�      5�      �� 5�      $��1��5�      $��0,0,25,0q�5�      $��Right=�5�      $ 
Horizontal=�5�      .+�5�      �� $��40��5�      $��3,0,3,0q�5�      $��0,0,0,0q�5�      $��15��5�      ��5�      �� *FifteenPageCommand+5�      �� 5�      $��40��5�      $��3,0,3,0q�5�      $��0q�5�      $��30��5�      ��5�      �� *ThirtyPageCommand+5�      �� 5�      $��40��5�      $��3,0,10,0q�5�      $��0q�5�      $��50��5�      ��5�      �� *FiftyPageCommand+5�      �� 5�      $��0,0,0,0q�5�      $��Center=�5�      $��16(�5�      $��per page��5�      5�      5�      5�      5�      