   M S B A M L   `   `   `  ����C  ?Lesson07, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Lesson07.Views.DialogsLesson07.Views.Dialogs  5      '    !Lesson07.Views.Dialogs.SaleDialog   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Lesson07.Views.Dialogs     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��700��5	      .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Right=�5      
���  �� "  MaterialDesignFlatAccentButton#��[  5       � ToolTip$
 Icon��5      ��5      �� *CloseCommand+��5      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Close=�{�5      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window5      � 5   
   $��1��6   $��50q�6     5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5       �� $��0��5!      $��Center=�5"      $��24(�5#      $
��Bold"�5$      $��Create Sale��5%      �� 5&      $��1��6   $��0,50,0,0q�6&   .+�5'      ��  �� Orientation$ 
Horizontal=�6   .+�5(      �� $	��200��5)      $��40��5*      $��7q�5+      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Select Customer��5,       �� DisplayMemberPath$ 	FirstName��5-       " MaterialDesignOutlinedComboBox#��[ 50      ��5.      �� *	Customers+ �� SelectedItem 5/      �� *SelectedCustomer+50      (  "System.Windows.Controls.DatePicker  51      $	��125��52      $��40��53      $��15,0,0,0q�54      $��7q�55      $ Select Date��56       $  MaterialDesignOutlinedDatePicker#��[ 58      	   SelectedDate	 57      �� *SelectedDate+58      �� 59      $	��200��5:      $��40��5;      $��15,0,0,0q�5<      $��7q�5=      $ Select Product��5>      $
 Name��5?      #��[ 5B      ��5@      �� *
Products+ 5A      �� *SelectedProduct+5B      �� 5C      $��1��5D      $	��125��5E      $��40��5F      $��15,0,0,0q�5G      $��Right=�5H      ���#6dc78b$��0q�5J      ��5K      �� *AddItemCommand+.��5L      �� $ 
Horizontal=�6%   .+�5M      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 PlusBold=�6*   �� 5N      $��5,0,0,0q�5O   !   $
��Bold"�5P   !   $��Product��5Q   !   5R      5S      5T      5U      �� 5V      $��2��6   $��0,25,0,0q�6&   .+�5W      &   System.Windows.Controls.DataGrid  -   5          Name$ SaleProductsDataGrid��5X         AutoGenerateColumns$ False��5Y         CanUserAddRows$ False��5Z         CanUserDeleteRows$ False��5[         CanUserResizeColumns$ False��5\      ��5]      �� *SaleProducts+   Columns 5^      0  *System.Windows.Controls.DataGridTextColumn  5_      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��5a         
IsReadOnly$
 True��5b      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5`      �� *	ProductId+5b        5c      $
 Name��5e      $
 True��5f       5d      �� *Product.Name+5f        5g      $ Price��6r    6-   �� *	UnitPrice+ �� StringFormat$ 	{0:C0}.00�� �� Mode$ TwoWay=�6r     5h      $ Discount��6q    6-   �� *
Discount+$ 	{0:C0}.00��$ TwoWay=�6q     5i      $ Quantity��6W    6-   �� *
Quantity+$ TwoWay=�6W   4	  .System.Windows.Controls.DataGridTemplateColumn	  5j         Width5
  /System.Windows.Controls.DataGridLengthConverter$	 100
 61    	  CellTemplate 5k      �� 5l   "   .R�5m   &   �� $��Right=�5n   )   
���  ����5p   )   �� *DataContext.DeleteItemCommand+ ��  DataGrid��5q   )   �� *SelectedItem+ �� ElementName$ SaleProductsDataGrid��.��5r   *     
�������$
 TrashCan=�6I   5s   '   5t   #   5v      5x      5y      � 5z      $��3��6   $��0,25,0,0q�6    .+�5{      �� $
��Left=�6   $ 
Horizontal=�68   .+�5|      �� $��Total Due: ��6   $��20(�62   �� 5}      $��20(�69   ��6   �� *
TotalDue+69   �� 5~      $	��175��5      $��40��5�      $��15,0,0,0q�5�      $��Bottom=�5�      $ Enter payment amount��5�      ��5�      �� *PaymentAmount+$ 	{0:C0}.00��5�      �� 5�      $	��150��5�      $��Right=�5�      $��Create��5�      ��5�      �� *CreateSaleCommand+{�5�      �� *	CanCreate+5�      5�      5�      5�      