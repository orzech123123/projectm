   M S B A M L   `   `   `  ����A  =Macrix, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Macrix.ViewModelsMacrix.ViewModels  5          Macrix.Views.TableView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0thisclr-namespace:Macrix.ViewModels     5      
���   �  � DataContext  5	      &    Macrix.ViewModels.TableViewModel  5
   
   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid     CanUserAddRows .    AutoGenerateColumns .     CanUserDeleteRows .    CanUserReorderColumns .    CanUserSortColumns . $��0,20,0,0q�5   -   ��5   )   �� *PersonEntities+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Imię��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� 	 �� Path$	 	Firstname�
 �� UpdateSourceTrigger$
 PropertyChanged=�  5      $ Nazwisko��6%    67   �� $	 Lastname�$
 PropertyChanged=�  5      $ Ulica��6%    64   �� $	 Street�$
 PropertyChanged=�  5      $ Nr domu��6%    66   �� $	 HouseNumber�$
 PropertyChanged=�  5      $ 	Nr lokalu��6%    68   �� $	 
FlatNumber�$
 PropertyChanged=�  5      $ Kod pocztowy��6%    6;   �� $	 
PostalCode�$
 PropertyChanged=�  5      $ Telefon��6%    66   �� $	 PhoneNumber�$
 PropertyChanged=�4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Data ur.��6)      CellTemplate 5      �� 5      .R�5      �� ��6(   �� $	 	Birthdate�$
 PropertyChanged=�5         CellEditingTemplate 5       �� 5!      .R�5"      (  "System.Windows.Controls.DatePicker     SelectedDate 6)   �� $	 	Birthdate�$
 PropertyChanged=�5#      5%        5&      $
 Wiek��6%      
IsReadOnly .  6E   �� $		 Age�$
 PropertyChanged=�  5'       5(      �� 5)      .R�5*      � .+�5+   "   �� $��Usuń��6)   ��68   �� $	 DataContext.RemoveCommand� �� RelativeSource ��  �� AncestorType"  ��6�   �� 5,      5-      5/      51      �� 52   
   -   5         ��Name$ button��52      $��Zapisz��6A   $
��Left=�6R   $	��Top=�6m   $��75��6�   ��6!   �� *SaveCommand+6�   �� 53   
   -   5        $ button1��53      $��Anuluj��6D   $
��Left=�6U   $��75,0,0,0q�6p   $	��Top=�6�   $��75��6�   ��6"   �� *CancelCommand+6�   54      55      