﻿#pragma checksum "..\..\..\Pages\AuthorizePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AF4DF10363C94939B05A3A3567067BBC"
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
using VrManager.Pages;


namespace VrManager.Pages {
    
    
    /// <summary>
    /// AuthorizePage
    /// </summary>
    public partial class AuthorizePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\Pages\AuthorizePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VrManager.Pages.AuthorizePage thisPage;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\AuthorizePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Login;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\AuthorizePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LoginValidMessage;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\AuthorizePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TB_Password;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\AuthorizePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PasswordValidMessage;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\AuthorizePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Authorize;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Pages\AuthorizePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AuthorizeEndOut;
        
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
            System.Uri resourceLocater = new System.Uri("/VrManager;component/pages/authorizepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AuthorizePage.xaml"
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
            this.thisPage = ((VrManager.Pages.AuthorizePage)(target));
            
            #line 11 "..\..\..\Pages\AuthorizePage.xaml"
            this.thisPage.Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TB_Login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.LoginValidMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.TB_Password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.PasswordValidMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.Authorize = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Pages\AuthorizePage.xaml"
            this.Authorize.Click += new System.Windows.RoutedEventHandler(this.Authorize_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AuthorizeEndOut = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\Pages\AuthorizePage.xaml"
            this.AuthorizeEndOut.Click += new System.Windows.RoutedEventHandler(this.Authorize_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

