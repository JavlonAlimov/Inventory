   M S B A M L   `   `   `  ����C  ?Lesson07, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Lesson07Lesson07  5      /clr-namespace:Lesson07.ViewsLesson07.Views  5	          Lesson07.MainWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Lesson07     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      (viewsclr-namespace:Lesson07.Views  5	      $
��1150��5
      $	��750��5       !  MaterialDesignLightBackground#���   5      $��14(�5      $��Medium"�5        MaterialDesignBody#���  5        � WindowStartupLocation$  CenterScreen=�5       � WindowState$ 	Maximized=�5       � WindowStyle$
 None=�5      ��5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � 	Resources 5       3 /CustomColorMaterialDesign3NavigationListBoxItem ' #MaterialDesignNavigationListBoxItem �� BasedOn �� 
TargetType �� Property �� Value��%�   &	       7  �� 5   
   8   " ��5      .�5      ��  � �� �#ccffdd6+   �� 5       � �� �#ccffdd6+   �� 5       � ��$ 25(�6)   5      5      .��5!      �  � RowDefinitions 5"   
   �� 5#      $
��auto �6   �� 5$      $��* �6   	 � ColumnDefinitions	 5&   
   �� 5'      $
��Auto �6   �� 5(      $��* �6   .+�5+   
   � $��2��5,      $��Stretch=�5-      ���#4f696e	 5/      �� 50      $��* �6#   �� 51      $
��Auto �6#   �� 52      $
��Auto �6#   .+�54      o� $��0��55      $��0��56      ���#f7f7f7
 o� 
IsMainMenu$

 True��58      .@�59      m� ���#4f696e$��_File��60   .@�5:      m� $
��Save��6    m� Icon 6-   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ ContentSave=�m� 5;      $��	Save As..��6   m� 5<      $
��Exit��5=       m� InputGestureText$ Ctrl+E��5?       5>        $ 	ExitToApp=�5?      �� 5@      m� 5A      $��	Excellent��5B       m� IsCheckable$
 True��5C       m� 	IsChecked$
 True��5D      m� 5E      $��Rubbish��6   $
 True��60   m� 5F      ���#4f696e$��
Dig Deeper��5H      $ Ctrl+D��5I      .@�5J      m� $��Enlightenment?��6#   $
 True��6;   m� 5K      $��Disappointment��6#   $
 True��6;   5L      m� 5M      ���#4f696e$��Look Deeper��5O      $ Ctrl+D��5P      .@�5Q      m� $��Plain��6#   m� 5R      $��	Ice Cream��6#   5S      5T      m� 5U      ���#4f696e$��_Edit��60   .@�5V      m�  m� Command$	 Cut��5W      $
��_Cut��5X       5Y        $ 
ContentCut=�m� 5Z      $
 Copy��5[      $��_Copy��5\       5]        $ ContentCopy=�m� 5^      $ Paste��5_      $��_Paste��5`       5a        $ ContentPaste=�5b      5c      �� 5d      -   5        $��1��5e      $��0,0,25,0q�5f      $��0q�5g      ���#4f696e  MaterialDesignIconButton#��[ 5j      .��5k      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5l      $��30��5m      $��16(�5n      
�������   Kind$ WindowMinimize=�5p      5q      �� 5r      -   5        $��2��5s      $��0,0,25,0q�5t      $��0q�5u      ���#4f696e#��[ 5x      .��5y        $��30��5z      $��30��5{      $��16(�5|      
�������$ Power=�5~      5      5�      � 5�   
   $��1��5�      $��0��5�      $	��175��5�      $��Stretch=�5�      ���#4f696e 5�      �� 5�      $
��Auto �6    �� 5�      $��* �6    .+�5�      �� $��0,0,0,40q�6   $��images/app-logo.png��6&   (� 5�      $��1��5�      $	��Top=�5�       (� Stretch$ Uniform=�5�      .��5�      �� -   5        $��2��5�      $	��Top=�5�       �� SelectedIndex$ 0��5�      ��5�      �� *
SampleList+��5�      �� 5�      # [ 6    " ��6k   .�5�      �� +  %MaterialDesignThemes.Wpf.BadgedAssist �@ Badge 6R   �� *Notification+�� 5�      3  -MaterialDesignThemes.Wpf.NavigationRailAssist �@ IsTextVisible$
 True��6b   �� 5�       �@ SelectedIcon 6a   �� *SelectedIcon+�� 5�       �@ UnselectedIcon 6c   �� *UnselectedIcon+5�       5�       �� DataType   Lesson07.SampleItem �� Orientation��%  (��       5�   '   *, +)�� 6   "  6'   .R�5�      �� $ 
Horizontal=�6)   .+�5�   "     $��25��5�   %   $��25��5�   %   $��Center=�5�   %    5�   %   �� *SelectedIcon+�� 5�   "   $��10,0,0,0q�6,   ��6>   �� *Title+5�      5�      5�      5�      5�      5�      )  #MaterialDesignThemes.Wpf.DialogHost  5�   
   $��1��5�      $��1��5�         CloseOnClickAway$ False��5�         
Identifier$ 
MainDialog��5�      .��5�      �� -   5         ��Name$ mainContent��5�      ���#f5f6f9.��5�      �� $��Stretch=�5�      $��Stretch=�5�      $
��Auto=�5�      .��5�      !   Lesson07.Views.ProductsView  5�      5�      5�      5�      5�      