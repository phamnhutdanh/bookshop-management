   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookShop.PagesBookShop.Pages  5          BookShop.Pages.BillPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:BookShop.Pages     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      -   5          N� Title$  BillPage��5	         MaterialDesignBody#���   5       N� 
Background 5      Z� .��5      #  MaterialDesignThemes.Wpf.Card  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6     MaterialDesignPaper#���  5      .��5   
   �  � RowDefinitions 5      �� 5      $��50 �6    �� 5      .+�5      �� $��0��6   .+�5      �� $��50��6    �� Orientation$ 
Horizontal=�6)    ) %MaterialDesignDarkSeparatorBackground#��[ 5      .+�5      �� $��20��6"   $
��auto��6.   $ 
Horizontal=�5   "   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�62   $��25,0,0,0q�5    2   $��20��5!   2   $��20��6>   �� 5#      -   5         ��Name$ txbx_textfilter_HoaDon��5%   "   $��5,0,0,0q�5#   #   $	��400��64   $��30��6A   $��15(�5$   "   $��Consolas)�60   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm kiếm��5&   #   5'   #   5(      �� 5+      $ 
Horizontal=�6!   .+�5,      �� -   5         ��Name$ 	btn_print��5,   !   	 � Cursor$
	 Hand��64   $��In hoá đơn��5-   %   $��10(�6:   $	��100��6H   $��25��5.   &   $��10,0,0,0q�62    " MaterialDesignFlatDarkBgButton#��[ 5/   %   +  %MaterialDesignThemes.Wpf.ButtonAssist
   CornerRadius$
 10��50   %   $��Center=�52   $   $��Center=�6A    � ToolTip$2 ,Xem và in thông tin hoá đơn đã chọn��53   %   �� 56      -   5        $ btn_dathanhtoan��56   !   $��Đã thanh toán��57   %   $��10(�6=   $	��100��6K   $��25��58   &   $��10,0,0,0q�62   $
	 Hand��6D   #��[ 59   %   $
 10��5:   %   $��Center=�5;   $   $��Center=�6A   $9 3Cập nhật hoá đơn chọn là đã thanh toán��5<   %   5=   %   �� 5?      -   5        $ btn_dagiaohang��5?   !   $��Đã giao hàng��5@   %   $��10(�6<   $	��100��6J   $��25��5A   &   $��10,0,0,0q�62   $
	 Hand��6E   #��[ 5B   %   $
 10��5C   %   $��Center=�5D   $   $��Center=�6A   $4 .Cập nhật hoá đơn chọn đã giao hàng��5E   %   5F   %   �� 5I      -   5         ��Name$ hidden_sohd��5I   $   $y�Hidden=�5K   $   ��5J   #   ��  �� ElementName$ list_Bill_HOADON�� �� Path$ SelectedItem.SOHD�5K   :   5L      5N      5O      �� 5Q      $��1��6   .+�5U      �� $��Lịch sử giao dịch��6   $��0 5 0 0q�5V       $��18(�5W      $��Center=�6&   $��Font\#iCiel Koni Black)�5X      �� 5[      $ 
Horizontal=�6   $��Right=�66   $��0 10 0 0q�5\      .+�5]      �� -   5        $ txt_tratruoc��5^   !   $��12(�5_   !   $��Consolas)�6/   $	��150��5`   !   $��30��6-   $' !Nhập số tiền trả trước��5a   !   ��5b   !   �� $ list_KhachHang��$ SelectedItem.HOTEN� �� Mode$ TwoWay=��� 5e      -   5        $ btn_capnhattratruoc��5e      $
	 Hand��6:   $��Cập nhật��5f   %   $��10(�68   $��90��6F   $��25��5g   &   $��
20 0 100 0q�62   #��[ 5h   %   $
 10��5i   %   $��Center=�5j   $   $��Center=�6A   $C =Cập nhật số tiền trả trước cho hoá đơn chọn��5k   %   5l      5n      �� 5s      -	   5         ��Name$ list_Bill_HOADON��5s      $��Center=�5t      $	��430��62   $
��1000��6?   $
��Left=�5u      $��0,10,0,0q�5v      ���	#FFF7F4D2
����������	#FF000E02$��Consolas)�6k   $
��Bold"�6�    �� View 5y      �� 5z      -
   5        grid_HoaDon��.P�5{      ��  �� Width$
 auto��6S    �� DisplayMemberBinding 6-   �� *SOHD+.��5|   "   �� -   5        .��5|   _   ID6c   5}      �� 5      $
 auto��6T    6-   �� *HOTEN+.��5�   "   �� -   5        .��5�   `   	Tên NV6h   5�      �� 5�      $
 auto��6T    6-   �� *TENKH+.��5�   "   �� -   5        .��5�   `   	Tên KH6h   5�      �� 5�      $
 auto��5�   -    5�   -   �� *NGHD+ �� StringFormat$  {0:dd/MM/yyyy hh:mm:ss tt}��.��5�   "   �� -   5        .��5�   _   Ngày6e   5�      �� 5�      $
 auto��6U    6-   �� *TRIGIA+.��5�   "   �� -   5        .��5�   a   
Trị giá6j   5�      �� 5�      $
 auto��6W    6-   �� *
TRATRUOC+.��5�   "   �� -   5        .��5�   c   
Đã trả6k   5�      �� 5�      $
 auto��6X    6-   �� *	THANHTOAN+.��5�   "   �� -   5        .��5�   d   Thanh toán6p   5�      �� 5�      $
 auto��6W    6-   �� *
GIAOHANG+.��5�   "   �� -   5        .��5�   c   
Giao hàng6n   5�      5�      5�      5�      5�      5�      5�      