﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BibReader.BibReference {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class BibRefClientConfig : global::System.Configuration.ApplicationSettingsBase {
        
        private static BibRefClientConfig defaultInstance = ((BibRefClientConfig)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new BibRefClientConfig())));
        
        public static BibRefClientConfig Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:8000/styles")]
        public string stylesLink {
            get {
                return ((string)(this["stylesLink"]));
            }
            set {
                this["stylesLink"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:8000/citations?style=[styleName]")]
        public string citationsLink {
            get {
                return ((string)(this["citationsLink"]));
            }
            set {
                this["citationsLink"] = value;
            }
        }
    }
}