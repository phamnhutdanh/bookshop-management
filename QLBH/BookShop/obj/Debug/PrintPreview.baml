   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BookShopBookShop  5   	       BookShop.PrintPreview   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:BookShop     5   	   -   5          � Title$  PrintPreview��5	   	   $	��600��6   $	��535��6+    � WindowStyle$
 None=�5
   
    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         	print_btn �� ImageSource j� Stretch  	cross_btn �� 
TargetType  	txb_Style �� Property	 �� Value  FocusVisual
 J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background 	 Button.Pressed.Border 
 Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground  	btn_style �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName  btn_cross_style��%.  &	        &	 E     &	 �     &	 �    &	 �    &	 �    &	 �    &	 �    &	     &		 :    &	
 ]    &	 �    &	 �    &	 �    7  7  7  7   7  7   7 	 7 
 7  7  &	 �    7  7  7  7  7  7  7 	 7 
 7  7  �� 5   
   $ Sources\print_hold.png��6'   $
 Fill=�6L   6]   �� 5   
   $ Sources\cross_hold.png��6'   $
 Fill=�6L   6]   �� 5   
   " ��6   .�5      ��  � ��$	 15(�6)   66   �� 5       � ��$	 Medium"�6+   6<   �� 5       � ��$	 0,5,0,0q�6'   69   �� 5       � ��$	 Center=�62   6C   �� 5       � ��$	 Center=�64   6E   �� 5       � ��
	 �����6@   �� 5       � ��$	 Consolas)�6+   6>   5      �� 5   
   .�5      ��  � ��	 5      �� 5      .R�5      �� $��2q�6$   
 . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5!      5"      �� 5#   
   $ 	#FFDDDDDD��6;   �� 5$   
   $ 	#FF707070��67   �� 5%   
   $ 	#FFBEE6FD��6>   �� 5&   
   $ 	#FF3C7FB1��6:   �� 5'   
   $ 	#FFC4E5F6��6<   �� 5(   
   $ 	#FF2C628B��68   �� 5)   
   $ 	#FFF4F4F4��6=   �� 5*   
   $ 	#FFADB2B5��69   �� 5+   
   $ 	#FF838383��6=   �� 5,   
   " ��6"   .�5-      ��  �@�FocusVisualStyle8	   61   �� 5.       � ��8	  6+   �� 5/       � ��8	  6,   �� 50       � ��#	 � ��6+   �� 51       � ��$	 1q�60   �� 52       � ��$	 Center=�6;   �� 53       � ��$	 Center=�69   �� 54       � ��$	 1q�6(   �� 55       � ��	 56      �� 57      " ��6&   .R�58      �� $ border��6!   #��z��61   #��z��6]   #��z��6�   
 . ._�59      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. #
 z
 6�   #��z��6  5:       5;      P� 5<       �@��IsDefaulted . . �5=   "   �� $ border��6@   #	 � ��6T    � ��5>      P� 5?       �@J�IsMouseOver . . �5@   "   �� $ border��6?   8	   � ��6S   �� 5A   "   $ border��6@   8	   � ��6T   5B      P� 5C       � �� . . �5D   "   �� $ border��6?   8	   � ��6S   �� 5E   "   $ border��6@   8	   � ��6T   5F      P� 5G       � {� .  . �5H   "   �� $ border��6?   8	   � ��6S   �� 5I   "   $ border��6@   8	   � ��6T   �� 5J   "   $ contentPresenter��6K   8	 	  � ��6i   5K      5M      5O      5P      �� 5R   
   " ��6(   .�5S      ��  �@�FocusVisualStyle8	   61   �� 5T       � ��8	  6+   �� 5U       � ��8	  6,   �� 5V       � ��#	 � ��6+   �� 5W       � ��$	 1q�60   �� 5X       � ��$	 Center=�6;   �� 5Y       � ��$	 Center=�69   �� 5Z       � ��$	 1q�6(   �� 5[       � ��	 5\      �� 5]      " ��6&   .R�5^      �� $ border��6!   #��z��61   #��z��6]   #��z��6�   
 . ._�5_      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. #
 z
 6�   #��z��6  5`       5a      P� 5b       �@��IsDefaulted . . �5c   "   �� $ border��6@   #	 � ��6T    � ��5d      P� 5e       �@J�IsMouseOver . . �5f   "   �� $ border��6?   8	   � ��6S   �� 5g   "   $ border��6@   8	   � ��6T   5h      P� 5i       � �� . . �5j   "   �� $ border��6?   8	   � ��6S   �� 5k   "   $ border��6@   8	   � ��6T   5l      P� 5m       � {� .  . �5n   "   �� $ border��6?   8	   � ��6S   �� 5o   "   $ border��6@   8	   � ��6T   �� 5p   "   $ contentPresenter��6K   8	 	  � ��6i   5q      5s      5u      5v      5x      .��5z      �  � RowDefinitions 5|   
   �� 5}      $��30 �6   6*   �� 5~      6   .+�5�   
   � -   5        ���	#FF72767A J� OpacityMask 5�      �� 5�      $ 	#FF080013��6"    �� Opacity$	 0.8Q�64   5�      � 5�   
   -   5         �Name$ grid_TieuDe��5�   ,   $��0��6   $��0��6    � ColumnDefinitions 5�      �� 5�      $��35 �6#   60   �� 5�      6%   �� 5�      $��35 �6#   60   �� 5�      $��35 �6#   60   �� 5�      $��35 �6#   60   .+�5�      �� -   5         ��Name$ btn_exit��5�      $��0q�6'   $��4��5�      $��30��6%   $	��Top=�61   #���  6`   ��5�      �� 5�      $
 Fill=�6!   $ Sources\cross.png��60   6R   5�      5�      � 5�   
   -   5        $ print��5�      $��1��6    5�      �� 5�      $��50 �6    6.   �� 5�      $��60 �6    6.   �� 5�      $��90 �6    6.   �� 5�      6"   �� 5�      $��50 �6    6.   .+�5�      �� $��0��6    �� Orientation$ 
Horizontal=�6*   
�������$��Right=�5�      $��0,0,0,0q�65   .+�5�      �� $��Sources\store.png��6   $��30��5�      $��30��5�      6%   �� 5�      $��Nhà sách BooBoo��6    $��
20,0,200,0q�67   #��[ 5�      ���	#FF2C0430$��20(�5�      �� 5�      -   5        $ 	print_btn��5�   =   $��50��5�      $��60��6%   $��0,0,50,0q�60    � Cursor$
 Hand��6B   #���  5�      $��0q�5�      $	��Top=�6-   ��5�      �� 5�      $ Sources/print.png��6)   6K   5�      5�      �� 5�      $��1��6   
�������.+�5�      �� #��[ 6    $��
Hoá đơn��5�      ���	#FF2C2912$��Font\#iciel Cadena)�5�      $��40(�5�      $
��Bold"�5�      $��Center=�5�      $��Center=�5�      5�      5�      � 5�      $��2��6   
������� 5�      �� 5�      $	��300 �6+   �� 5�      �� 5�      $	��200 �6+   .+�5�      �� $��0��6!   .+�5�      �� -   5         ��Name$ txt_cusname��5�   3   #��[ 5�   $   $��CustomeName��5�       
���   �$��25(�5�       �� 5�      $ 
Horizontal=�6%   .+�5�      �� #��[ 6(   $��Date: ��5�       $��	5,4.5,0,0q�6.   
���   �5�       �� 5�      -   5        $ txt_date��5�   ,   #��[ 5�   (   $
��date��5�       
���   �5�       5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� #��[ 6(   $��Số hoá đơn: ��5�       $��	5,4.5,0,0q�64   
���   �5�       �� 5�      -	   5        $ txt_sohd��5�   ,   #��[ 5�   (   $
��sohd��5�       
���   �5�       5�      5�      �� 5�      $��2��6!   $��Right=�61   .+�5�      �� -
   5        $ 	txt_tennv��5�       #��[ 5�   $   
���   �$��0,0,5,0q�5�   3   $��ten nhanvien��5�       $��Right=�64   5�       �� 5�      #��[ 6    
���   �$��0,0,5,0q�5�   3   $��TPHCM��5�       $��Right=�6-   5�      5�      �� 5�      $��3��6   .+�5�      � $��5��6   ���	#FF2B29025�   0   �� 5�      -   5         ��Name$ listview_hoadon��5�      $��Center=�5�      $��Center=�5�      ���	#FF000E02$��Consolas)�5     $
��Bold"�5     $��8(�6)   $	��535��5     $	��295��6#   $��Disabled=�5     ��5      Z�  �� View 5     �� 5     .P�5	     �� $��Tên sản phẩm��6-    �� Width$
 auto��6C     �� DisplayMemberBinding  5
  -   �� *name+6U   �� 5     $��Loại��6-   $
 auto��6;     5  -   �� *loai+6U   �� 5     $
��Giá��6-   $
 auto��6:     5  -   �� *price+6V   �� 5     $��Số lượng��6-   $
 auto��6?     5  -   �� *qty+6T   �� 5     $��Tổng��6-   $
 auto��6;     5  -   �� *sum+6T   5     5     5     �� 5     $��4��6   
�������.+�5     � $��5��6   ���	#FF2B29025  0   �� 5     $ 
Horizontal=�6   $��Right=�66   $��0,0,20,0q�5     .+�5      �� #��[ 6    
���   �$��0,0,5,0q�5!  3   $��Thành tiền: ��5"      $��Right=�5#      �� 5$     -   5        $ 
txt_sotien��5'      #��[ 5$      
���   �$��0,0,5,0q�5%  3   $��sotien��5&      $��Right=�5(      5)     5+     5,     5.     5/     