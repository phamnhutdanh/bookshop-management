﻿#pragma checksum "..\..\..\Pages\BillPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "81DB74E7C2C1DE510D7DCBE6743A20D0E9CD5F66DEC251045072C942415A9CA0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BookShop.Pages;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using RootLibrary.WPF.Localization;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace BookShop.Pages {
    
    
    /// <summary>
    /// BillPage
    /// </summary>
    public partial class BillPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\Pages\BillPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_textfilter_HoaDon;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Pages\BillPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_print;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Pages\BillPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_dathanhtoan;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Pages\BillPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_dagiaohang;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Pages\BillPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock hidden_sohd;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Pages\BillPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_tratruoc;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Pages\BillPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_capnhattratruoc;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Pages\BillPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView list_Bill_HOADON;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\Pages\BillPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridView grid_HoaDon;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BookShop;component/pages/billpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\BillPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\Pages\BillPage.xaml"
            ((BookShop.Pages.BillPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbx_textfilter_HoaDon = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\Pages\BillPage.xaml"
            this.txbx_textfilter_HoaDon.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txbx_textfilter_HoaDon_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_print = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\Pages\BillPage.xaml"
            this.btn_print.Click += new System.Windows.RoutedEventHandler(this.btn_print_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_dathanhtoan = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\Pages\BillPage.xaml"
            this.btn_dathanhtoan.Click += new System.Windows.RoutedEventHandler(this.btn_dathanhtoan_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_dagiaohang = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\Pages\BillPage.xaml"
            this.btn_dagiaohang.Click += new System.Windows.RoutedEventHandler(this.btn_dagiaohang_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.hidden_sohd = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.txt_tratruoc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btn_capnhattratruoc = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\..\Pages\BillPage.xaml"
            this.btn_capnhattratruoc.Click += new System.Windows.RoutedEventHandler(this.btn_capnhattratruoc_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.list_Bill_HOADON = ((System.Windows.Controls.ListView)(target));
            return;
            case 10:
            this.grid_HoaDon = ((System.Windows.Controls.GridView)(target));
            return;
            case 11:
            
            #line 124 "..\..\..\Pages\BillPage.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.GridViewColumnHeader_SOHD_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 128 "..\..\..\Pages\BillPage.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.GridViewColumnHeader_HOTEN_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 132 "..\..\..\Pages\BillPage.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.GridViewColumnHeader_TENKH_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 137 "..\..\..\Pages\BillPage.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.GridViewColumnHeader_NGHD_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 141 "..\..\..\Pages\BillPage.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.GridViewColumnHeader_TRIGIA_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 145 "..\..\..\Pages\BillPage.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.GridViewColumnHeader_TRATRUOC_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 149 "..\..\..\Pages\BillPage.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.GridViewColumnHeader_THANHTOAN_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 153 "..\..\..\Pages\BillPage.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.GridViewColumnHeader_GIAOHANG_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

