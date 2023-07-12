﻿#pragma checksum "..\..\..\Pages\EmployeePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4ED9E22A229C8A67C27E0D5E48F1BA6619E561F9515FB2E4796CA6F2B2A1E408"
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
    /// EmployeePage
    /// </summary>
    public partial class EmployeePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 94 "..\..\..\Pages\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_textfilter;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Pages\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_save_empl;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\Pages\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_clear_empl;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\Pages\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_delete_empl;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\Pages\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_addimage;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\Pages\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image_box;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\Pages\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_name_empl;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\Pages\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_phone_empl;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\Pages\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_address_empl;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\..\Pages\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_NgaySinh_empl;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\..\Pages\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_NgayVaoLam_empl;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\Pages\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_username_empl;
        
        #line default
        #line hidden
        
        
        #line 217 "..\..\..\Pages\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txt_password_empl;
        
        #line default
        #line hidden
        
        
        #line 225 "..\..\..\Pages\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox txt_gioitinh_empl;
        
        #line default
        #line hidden
        
        
        #line 243 "..\..\..\Pages\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl ListViewProducts;
        
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
            System.Uri resourceLocater = new System.Uri("/BookShop;component/pages/employeepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\EmployeePage.xaml"
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
            
            #line 7 "..\..\..\Pages\EmployeePage.xaml"
            ((BookShop.Pages.EmployeePage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbx_textfilter = ((System.Windows.Controls.TextBox)(target));
            
            #line 96 "..\..\..\Pages\EmployeePage.xaml"
            this.txbx_textfilter.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txbx_textfilter_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_save_empl = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\..\Pages\EmployeePage.xaml"
            this.btn_save_empl.Click += new System.Windows.RoutedEventHandler(this.btn_save_empl_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_clear_empl = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\Pages\EmployeePage.xaml"
            this.btn_clear_empl.Click += new System.Windows.RoutedEventHandler(this.btn_clear_empl_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_delete_empl = ((System.Windows.Controls.Button)(target));
            
            #line 131 "..\..\..\Pages\EmployeePage.xaml"
            this.btn_delete_empl.Click += new System.Windows.RoutedEventHandler(this.btn_delete_empl_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_addimage = ((System.Windows.Controls.Button)(target));
            
            #line 146 "..\..\..\Pages\EmployeePage.xaml"
            this.btn_addimage.Click += new System.Windows.RoutedEventHandler(this.btn_addimage_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.image_box = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.txt_name_empl = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txt_phone_empl = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.txt_address_empl = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.date_NgaySinh_empl = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 12:
            this.date_NgayVaoLam_empl = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 13:
            this.txt_username_empl = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.txt_password_empl = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 15:
            this.txt_gioitinh_empl = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 16:
            this.ListViewProducts = ((System.Windows.Controls.ItemsControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 17:
            
            #line 250 "..\..\..\Pages\EmployeePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_item_Click);
            
            #line default
            #line hidden
            
            #line 251 "..\..\..\Pages\EmployeePage.xaml"
            ((System.Windows.Controls.Button)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.btn_item_MouseDoubleClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
