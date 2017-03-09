﻿#pragma checksum "..\..\..\Pages\MainSettingPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9A49DF3159466E850346C142AA75AFA4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
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
using VrManager.Helpers;
using VrManager.Pages;


namespace VrManager.Pages {
    
    
    /// <summary>
    /// MainSettingPage
    /// </summary>
    public partial class MainSettingPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Pages\MainSettingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VrManager.Pages.MainSettingPage thisPage;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Pages\MainSettingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_OpenFile;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Pages\MainSettingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_OpenFileDialog;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Pages\MainSettingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_SaveNewFolderToFile;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Pages\MainSettingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FirstMessage;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\Pages\MainSettingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.TimePicker TP_TimeOut;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\Pages\MainSettingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_ChangeAllTimeOff;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\Pages\MainSettingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.ToggleSwitch TS_KioskMode;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\Pages\MainSettingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_ChangeKioskMode;
        
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
            System.Uri resourceLocater = new System.Uri("/VrManager;component/pages/mainsettingpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\MainSettingPage.xaml"
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
            this.thisPage = ((VrManager.Pages.MainSettingPage)(target));
            
            #line 13 "..\..\..\Pages\MainSettingPage.xaml"
            this.thisPage.Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TB_OpenFile = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Btn_OpenFileDialog = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\Pages\MainSettingPage.xaml"
            this.Btn_OpenFileDialog.Click += new System.Windows.RoutedEventHandler(this.Btn_OpenFileDialog_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Btn_SaveNewFolderToFile = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\Pages\MainSettingPage.xaml"
            this.Btn_SaveNewFolderToFile.Click += new System.Windows.RoutedEventHandler(this.Btn_SaveNewFolderToFile_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FirstMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.TP_TimeOut = ((MahApps.Metro.Controls.TimePicker)(target));
            return;
            case 7:
            this.Btn_ChangeAllTimeOff = ((System.Windows.Controls.Button)(target));
            
            #line 106 "..\..\..\Pages\MainSettingPage.xaml"
            this.Btn_ChangeAllTimeOff.Click += new System.Windows.RoutedEventHandler(this.Btn_ChangeAllTimeOff_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TS_KioskMode = ((MahApps.Metro.Controls.ToggleSwitch)(target));
            return;
            case 9:
            this.Btn_ChangeKioskMode = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\..\Pages\MainSettingPage.xaml"
            this.Btn_ChangeKioskMode.Click += new System.Windows.RoutedEventHandler(this.Btn_ChangeKioskMode_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

