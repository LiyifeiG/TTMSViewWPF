   M S B A M L   `   `   `  ����F  BTTMSViewWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TTMSViewWPF.View.PagesTTMSViewWPF.View.Pages  5      4    .TTMSViewWPF.View.Pages.SalesInfoManagementPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:TTMSViewWPF.View.Pages     5        N� Title$  SalesInfoManagementPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��5q�6!   $��3q�6,    �� CornerRadius$ 5��6@   
���**��
�������._�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5      �� $��电影销量排行榜��6   $��Center=�6.   $��Center=�6K   $��25(�5      $
��Bold"�6*   
������6T   5      &   System.Windows.Controls.DataGrid  5      -   5        $��MovieSalesDataGrid��5      
�������$��2q�6H   
���P��   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6p   $��15(�6�   $��Center=�5         
IsReadOnly . 5      5      5      �� 5   
   $��1��6   $��5q�6!   $��3q�6,   $ 5��6@   
���**��
�������._�5      �� .+�5      �� $ 
Horizontal=�6   $��Center=�66   .+�5      �� $��影厅收入排行榜��6   $��Center=�6.   $��Center=�6K   $��25(�5       $
��Bold"�6*   
������6T   5!        5"      -   5        $��AuditoriumInComeDataGrid��5"      
�������$��2q�6N   
���P��$ * 6v   $��15(�6�   $��Center=�5#       . 6S   5$      5%      �� 5&   
   $��2��6   $��5q�6!   $��3q�6,   $ 5��6@   
���**��
�������._�5'      �� .+�5(      �� $ 
Horizontal=�6   $��Center=�66   .+�5)      �� $��售票员销售排行榜��6   $��Center=�6/   $��Center=�6L   $��25(�5*      $
��Bold"�6*   
������6T   5+        5,      -   5        $��SalespersonSalesDataGrid��5,      
�������$��2q�6N   
���P��$ * 6v   $��15(�6�   $��Center=�5-       . 6S   5.      5/      51      52      