   M S B A M L   `   `   `  ����C  ?Lesson07, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Lesson07.ViewsLesson07.Views  5      !    Lesson07.Views.SuppliesView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Lesson07.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��5      $��3��5      $��	25,25,0,0q�5       5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5!      (  "System.Windows.Controls.DatePicker  $��0��5"      $��0��5#      $	��250��5$      $��40��5%      $��5q�5&      $
��Left=�5'      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Sales until��5(       $   MaterialDesignOutlinedDatePicker#��[  5*         SelectedDate 5)      �� *SelectedDate+5*      5+      � 5.   
   $��1��5/      $��3��50      $��25,10,25,10q�51      .+�52      �� $��0,20,0,0q�53       �� Padding$ 5q�54      ���#f7f5f5$��1q�56       �� CornerRadius$ 15��57      ._�58      &   System.Windows.Controls.DataGrid  -   5          Name$ SuppliesDataGrid��59      $��Stretch=�5:      $��Stretch=�5;         AutoGenerateColumns$ False��5<      ���#f7f5f5   
IsReadOnly$
 True��5>      	   SelectionMode$	 Single=�5A      
   SelectionUnit$
 FullRow=�5B      "   VerticalScrollBarVisibility$
 Auto=�5C      ��5?      �� *
Supplies+ �� SelectedItem 5@      �� *SelectedSupply+   Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *Id+6D     5F      $
 Date��6F    6-   �� *Date+6F     5G      $ 	Total Duo��6J    6-   �� *
TotalDue+6J     5H      $ 
Total Paid��6K    6-   �� *	TotalPaid+6K     5I      $  Supplied Id��6L    6-   �� *
SupplierId+6L   5K      5L      5M      � 5Q   
   $��2��5R      $��3��5S      $��
25,25,0,25q�5T       5U      �� 5V      $
��Auto �6#   �� 5W      $��* �6#   .+�5Y      �� $��0��6    �� Orientation$ 
Horizontal=�6)   .+�5Z      �� $��40��5[      $	��8,0q�5\      $��0q�5]      ��5^      �� *PrimaryPageCommand+{�5_      �� *IsEnablePrimaryPage+.��5`      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ SkipBackward=�6.   5a      �� 5b      $��40��5c      $��0q�5d      ��5e      �� *PrevPageCommand+{�5f      �� *IsEnablePrevPage+.��5g        $ 	ArrowLeft=�6.   5h      �� 5i      $	��150��5j       �� Padding$ 
40,0,40,00q�5k      $��Center=�5l      $��16)�5m      ��5n      �� *
PageString+�� 5o      $��40��5p      $��20,0,0,0q�5q      $��0q�5r      ��5s      �� *NextPageCommand+{�5t      �� *IsEnableNextPage+.��5u        $ 
ArrowRight=�6.   5v      �� 5w      $��40��5x      $	��8,0q�5y      $��0q�5z      ��5{      �� *LastPageCommand+{�5|      �� *IsEnableLastPage+.��5}        $ SkipForward=�6.   5~      5�      �� 5�      $��1��5�      $��0,0,25,0q�5�      $��Right=�5�      $ 
Horizontal=�5�      .+�5�      �� $��40��5�      $��3,0,3,0q�5�      $��0,0,0,0q�5�      $��15��5�      ��5�      �� *FifteenPageCommand+5�      �� 5�      $��40��5�      $��3,0,3,0q�5�      $��0q�5�      $��30��5�      ��5�      �� *ThirtyPageCommand+5�      �� 5�      $��40��5�      $��3,0,10,0q�5�      $��0q�5�      $��50��5�      ��5�      �� *FiftyPageCommand+5�      �� 5�      $��0,0,0,0q�5�      $��Center=�5�      $��16(�5�      $��per page��5�      5�      5�      5�      5�      