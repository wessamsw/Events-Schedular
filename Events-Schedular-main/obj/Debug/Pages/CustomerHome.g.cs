﻿#pragma checksum "..\..\..\Pages\CustomerHome.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BFB3418D6EC00678B117E4F21720B5D9E1CB464F37D144660B94362F803B6444"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using UIKitTutorials.Pages;


namespace UIKitTutorials.Pages {
    
    
    /// <summary>
    /// CustomerHome
    /// </summary>
    public partial class CustomerHome : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Pages\CustomerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lst_services;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Pages\CustomerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lst_cars;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Pages\CustomerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lst_garages;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\Pages\CustomerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lst_showrooms;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\Pages\CustomerHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox adminbox;
        
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
            System.Uri resourceLocater = new System.Uri("/UIKitTutorials;component/pages/customerhome.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\CustomerHome.xaml"
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
            
            #line 11 "..\..\..\Pages\CustomerHome.xaml"
            ((System.Windows.Controls.Border)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Border_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lst_services = ((System.Windows.Controls.ListView)(target));
            
            #line 14 "..\..\..\Pages\CustomerHome.xaml"
            this.lst_services.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lst_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lst_cars = ((System.Windows.Controls.ListView)(target));
            
            #line 39 "..\..\..\Pages\CustomerHome.xaml"
            this.lst_cars.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lst_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lst_garages = ((System.Windows.Controls.ListView)(target));
            
            #line 83 "..\..\..\Pages\CustomerHome.xaml"
            this.lst_garages.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lst_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lst_showrooms = ((System.Windows.Controls.ListView)(target));
            
            #line 95 "..\..\..\Pages\CustomerHome.xaml"
            this.lst_showrooms.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lst_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.adminbox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 108 "..\..\..\Pages\CustomerHome.xaml"
            this.adminbox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.adminbox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
