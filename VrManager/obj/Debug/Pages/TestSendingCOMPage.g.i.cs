﻿#pragma checksum "..\..\..\Pages\TestSendingCOMPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "20C70580F80A3A0CCDCB0C6B2E883F9B"
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
    /// SendingCOMTestPage
    /// </summary>
    public partial class SendingCOMTestPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Pages\TestSendingCOMPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button startSend;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Pages\TestSendingCOMPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPause;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Pages\TestSendingCOMPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnReusume;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Pages\TestSendingCOMPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnStop;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Pages\TestSendingCOMPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Terminal;
        
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
            System.Uri resourceLocater = new System.Uri("/VrManager;component/pages/testsendingcompage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\TestSendingCOMPage.xaml"
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
            this.startSend = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Pages\TestSendingCOMPage.xaml"
            this.startSend.Click += new System.Windows.RoutedEventHandler(this.startSend_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnPause = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Pages\TestSendingCOMPage.xaml"
            this.BtnPause.Click += new System.Windows.RoutedEventHandler(this.BtnPause_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnReusume = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Pages\TestSendingCOMPage.xaml"
            this.BtnReusume.Click += new System.Windows.RoutedEventHandler(this.BtnReusume_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnStop = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Pages\TestSendingCOMPage.xaml"
            this.BtnStop.Click += new System.Windows.RoutedEventHandler(this.BtnStop_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Terminal = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

