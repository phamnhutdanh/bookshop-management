﻿#pragma checksum "..\..\PrintPreview.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4185B13BD90C64F0117D471A81503E34B6AE9BA05EED4BBD428A6B90A14BE870"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BookShop;
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


namespace BookShop {
    
    
    /// <summary>
    /// PrintPreview
    /// </summary>
    public partial class PrintPreview : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 135 "..\..\PrintPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_TieuDe;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\PrintPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_exit;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\PrintPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid print;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\PrintPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button print_btn;
        
        #line default
        #line hidden
        
        
        #line 208 "..\..\PrintPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_cusname;
        
        #line default
        #line hidden
        
        
        #line 217 "..\..\PrintPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_date;
        
        #line default
        #line hidden
        
        
        #line 226 "..\..\PrintPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_sohd;
        
        #line default
        #line hidden
        
        
        #line 235 "..\..\PrintPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_tennv;
        
        #line default
        #line hidden
        
        
        #line 256 "..\..\PrintPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listview_hoadon;
        
        #line default
        #line hidden
        
        
        #line 296 "..\..\PrintPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_sotien;
        
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
            System.Uri resourceLocater = new System.Uri("/BookShop;component/printpreview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PrintPreview.xaml"
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
            
            #line 128 "..\..\PrintPreview.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid_TieuDe = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.btn_exit = ((System.Windows.Controls.Button)(target));
            
            #line 146 "..\..\PrintPreview.xaml"
            this.btn_exit.Click += new System.Windows.RoutedEventHandler(this.btn_exit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.print = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.print_btn = ((System.Windows.Controls.Button)(target));
            
            #line 179 "..\..\PrintPreview.xaml"
            this.print_btn.Click += new System.Windows.RoutedEventHandler(this.print_btn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txt_cusname = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.txt_date = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.txt_sohd = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.txt_tennv = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.listview_hoadon = ((System.Windows.Controls.ListView)(target));
            return;
            case 11:
            this.txt_sotien = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

