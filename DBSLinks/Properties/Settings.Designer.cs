﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Links.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("true")]
        public string TopMost {
            get {
                return ((string)(this["TopMost"]));
            }
            set {
                this["TopMost"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=//vcn.ds.volvo.net/it-cta/ITPROJ02/" +
            "002378/DESENV/DBS/AUTOMATOR/LINKS FORM/Database/Links.accdb; Persist Security In" +
            "fo=False;")]
        public string networkDatabaseConnectionString {
            get {
                return ((string)(this["networkDatabaseConnectionString"]));
            }
            set {
                this["networkDatabaseConnectionString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\vcn.ds.volvo.net\\it-cta\\ITPROJ02\\002378\\DESENV\\DBS\\AUTOMATOR\\LINKS FORM\\")]
        public string ApplicationPath {
            get {
                return ((string)(this["ApplicationPath"]));
            }
            set {
                this["ApplicationPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public string ApplicationWaitForNetworkMinutes {
            get {
                return ((string)(this["ApplicationWaitForNetworkMinutes"]));
            }
            set {
                this["ApplicationWaitForNetworkMinutes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("true")]
        public string ApplicationWaitForNetwork {
            get {
                return ((string)(this["ApplicationWaitForNetwork"]));
            }
            set {
                this["ApplicationWaitForNetwork"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("true")]
        public string StartLinksWhenWindowsIsStarted {
            get {
                return ((string)(this["StartLinksWhenWindowsIsStarted"]));
            }
            set {
                this["StartLinksWhenWindowsIsStarted"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\\\Temp\\\\Links\\\\Links.accdb; Persi" +
            "st Security Info=False;")]
        public string localDatabaseConnectionString {
            get {
                return ((string)(this["localDatabaseConnectionString"]));
            }
            set {
                this["localDatabaseConnectionString"] = value;
            }
        }
    }
}
