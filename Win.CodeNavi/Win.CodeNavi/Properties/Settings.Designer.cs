﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Win.CodeNavi.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection CodeFolders {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["CodeFolders"]));
            }
            set {
                this["CodeFolders"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection SearchStrings {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["SearchStrings"]));
            }
            set {
                this["SearchStrings"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Extensions {
            get {
                return ((string)(this["Extensions"]));
            }
            set {
                this["Extensions"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool Regex {
            get {
                return ((bool)(this["Regex"]));
            }
            set {
                this["Regex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool CaseSensitive {
            get {
                return ((bool)(this["CaseSensitive"]));
            }
            set {
                this["CaseSensitive"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection ExtensionSets {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["ExtensionSets"]));
            }
            set {
                this["ExtensionSets"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ShowNotesPanel {
            get {
                return ((bool)(this["ShowNotesPanel"]));
            }
            set {
                this["ShowNotesPanel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool IgnoreTest {
            get {
                return ((bool)(this["IgnoreTest"]));
            }
            set {
                this["IgnoreTest"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IgnoreComments {
            get {
                return ((bool)(this["IgnoreComments"]));
            }
            set {
                this["IgnoreComments"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool NotesWordWrap {
            get {
                return ((bool)(this["NotesWordWrap"]));
            }
            set {
                this["NotesWordWrap"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Font NotesFont {
            get {
                return ((global::System.Drawing.Font)(this["NotesFont"]));
            }
            set {
                this["NotesFont"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Black")]
        public global::System.Drawing.Color NotesColour {
            get {
                return ((global::System.Drawing.Color)(this["NotesColour"]));
            }
            set {
                this["NotesColour"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutoSaveNotes {
            get {
                return ((bool)(this["AutoSaveNotes"]));
            }
            set {
                this["AutoSaveNotes"] = value;
            }
        }
    }
}