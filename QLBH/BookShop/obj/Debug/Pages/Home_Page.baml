   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookShop.PagesBookShop.Pages  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5          BookShop.Pages.Home_Page   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:BookShop.Pages     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      >Wpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5      -   5          N� Title$  	Home_Page��5
         MaterialDesignBody#���   5       N� 
Background 5      Z� .��5      #  MaterialDesignThemes.Wpf.Card  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6     MaterialDesignPaper#���  5      .��5   
   �  � ColumnDefinitions 5      �� 5      �� 5       � RowDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6   $��0��6&   .+�5      �� $��Center=�6   $��Center=�5      $	��230��5       $	��450��6&   $��25q�5!      ���	#FFDDFDAE$��5q�5#       �� CornerRadius$ 90 0 0 0��5$      ._�5%      �� .+�5&      �� $#��Quản lý cửa hàng BooBoo��5'       $
��Bold"�5(       ���	#FF680F33$��0,20,0,0q�5*       $��Font\#iCiel Koni Black)�62   $��25(�5+       $��Center=�5,       �� 5.      $
��Wrap=�6$   $����Phần mềm quản lý các thông tin của nhân viên, khách hàng, sản phẩm giúp việc bán hàng được tiện lợi rõ ràng hơn.��5/      $
��Left=�50   $   $��15(�51   $   $��
20 5 20 20q�52   $    " MaterialDesignCaptionTextBlock#��[ 53      �� 54      -   5         ��Name$	 img��54       $��icon/icon_bag.png��6-   $��80��55      $��80��56      5;      5<      5>      �� 5A      $��0��6   $��1��6&    �� Orientation$ 
Horizontal=�66   .+�5B      �� ���	#FFE2C8BB$	��220��5D      $	��200��5E      $
��Left=�5F      $��10 0 0 0q�5G      .+�5H      �� $��Số lượng��5I       $
��Bold"�5J       ���	#FF04353A$��Font\#iciel Cadena)�5L       $��	15,25,0,0q�5M       $
��Left=�63   $��40(�5N       �� 5P      $ 
Horizontal=�6!   $
��Left=�5Q      $��	15 25 0 0q�5R      .+�5S      �� $��Nhân viên��5T       $
��Bold"�5U       $��Consolas)�5V       $��24(�5W       �� 5X      -   5         ��Name$ txt_soluongnhanvien��5Y   )   $��10 0 0 0q�5X   $   $��0��5Y       $��Consolas)�5Z       $
��Bold"�66   $��24(�5[       5\      �� 5^      $ 
Horizontal=�6!   $
��Left=�5_      $��	15 25 0 0q�5`      .+�5a      �� $��Khách hàng��5b       $
��Bold"�5c       $��Consolas)�5d       $��24(�5e       �� 5f      -   5        $ txt_soluongkhach��5g   )   $��10 0 0 0q�5f   $   $��0��5g       $��Consolas)�5h       $
��Bold"�66   $��24(�5i       5j      5l      �� 5n      $	��220��5o      $	��260��5p      $
��Left=�5q      $��20 0 0 0q�5r      .+�5s      �� $��	Doanh thu��5t       $
��Bold"�5u       ���	#FFC53066$��Font\#iciel Cadena)�5w       $��	35,25,0,0q�5x       $
��Left=�63   $��40(�5y       �� 5{      -   5        $ txt_doanhthu��5|   )   $��0 30 0 0q�5{       $��0��5|       ���	#FFC53066$��Consolas)�5~       $
��Bold"�66   $��Right=�5       $��24(�5�       5�      5�      �� 5�      $��1��6   $��0��6&   .+�5�      �� $��	30 10 0 0q�6   $
��Left=�60   .+�5�        LiveCharts.Wpf.PieChart  -   5        	  Name$	 	wpf_chart��5�   0   $	��250��6#   $	��250��5�   #   &   LiveCharts.Wpf.Charts.Base.Chart
   LegendLocation$

 Left=�5�   #      Series 5�   #   �� *SeriesCollection+   ChartLegend 5�      "  LiveCharts.Wpf.DefaultLegend  5�         
BulletSize$ 15Q�60   $��12(�5�   0   6J      DataTooltip 5�      #  LiveCharts.Wpf.DefaultTooltip  5�         
BulletSize$ 20Q�61   6C   5�      5�      5�      �� 5�      $��1��6   $��1��6&   .+�5�      #  LiveCharts.Wpf.CartesianChart  -   5          Name$ cartesian_Chart��5�   $   $	��250��5�   %   $	��450��62   $

 Left=�5�   %    5�   $   �� *SeriesCollection2+5�      5�      5�      5�      5�      