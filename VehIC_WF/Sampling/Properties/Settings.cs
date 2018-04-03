namespace VehIC_WF.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings) SettingsBase.Synchronized(new Settings()));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [SpecialSetting(SpecialSetting.WebServiceUrl), ApplicationScopedSetting, DebuggerNonUserCode, DefaultSettingValue("http://localhost:1198/VehIC_WS/AuthService.asmx")]
        public string VehIC_WF_AuthService_AuthService
        {
            get
            {
                return (string) this["VehIC_WF_AuthService_AuthService"];
            }
        }

        [ApplicationScopedSetting, DebuggerNonUserCode, DefaultSettingValue("http://localhost:1198/VehIC_WS/CommonService.asmx"), SpecialSetting(SpecialSetting.WebServiceUrl)]
        public string VehIC_WF_CommonService_CommonService
        {
            get
            {
                return (string) this["VehIC_WF_CommonService_CommonService"];
            }
        }

        [DebuggerNonUserCode, DefaultSettingValue("http://localhost:1198/VehIC_WS/DoorService.asmx"), ApplicationScopedSetting, SpecialSetting(SpecialSetting.WebServiceUrl)]
        public string VehIC_WF_DoorService_DoorService
        {
            get
            {
                return (string) this["VehIC_WF_DoorService_DoorService"];
            }
        }

        [DebuggerNonUserCode, DefaultSettingValue("http://localhost:1198/VehIC_WS/GoodsSite.asmx"), ApplicationScopedSetting, SpecialSetting(SpecialSetting.WebServiceUrl)]
        public string VehIC_WF_GoodsSite_GoodsSite
        {
            get
            {
                return (string) this["VehIC_WF_GoodsSite_GoodsSite"];
            }
        }

        [DebuggerNonUserCode, ApplicationScopedSetting, SpecialSetting(SpecialSetting.WebServiceUrl), DefaultSettingValue("http://localhost:1198/VehIC_WS/ICCardManageService.asmx")]
        public string VehIC_WF_ICCardManageService_ICCardManageService
        {
            get
            {
                return (string) this["VehIC_WF_ICCardManageService_ICCardManageService"];
            }
        }

        [DefaultSettingValue("http://localhost:1198/VehIC_WS/SamplingService.asmx"), ApplicationScopedSetting, DebuggerNonUserCode, SpecialSetting(SpecialSetting.WebServiceUrl)]
        public string VehIC_WF_SamplingService_SamplingService
        {
            get
            {
                return (string) this["VehIC_WF_SamplingService_SamplingService"];
            }
        }

        [ApplicationScopedSetting, SpecialSetting(SpecialSetting.WebServiceUrl), DefaultSettingValue("http://localhost:1198/VehIC_WS/ScaleService.asmx"), DebuggerNonUserCode]
        public string VehIC_WF_ScaleService_ScaleService
        {
            get
            {
                return (string) this["VehIC_WF_ScaleService_ScaleService"];
            }
        }
    }
}

