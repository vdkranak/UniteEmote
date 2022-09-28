using System;
using System.Collections.ObjectModel;
using Intel.Unite.Common.Manifest;
using Intel.Unite.Common.Module.Common;

namespace UniteEmote.Constants
{
    public static class ModuleConstants
    {
        private const string _guid = "a9bbad72-eeb3-47cc-b147-345cc48738cf";
        private const string _name = "Unite Plugin Example";
        private const string _description = "Unite Plugin Example";
        private const string _copyright = "Intel Corporation 2019";
        private const string _vendor = "Intel Corporation";
        private const string _version = "4.1.0.0007";

        private const string _minimumUniteVersion = "4.0.0.0";
        private const string _entryPoint = "UniteEmote.dll";

        public const string EntryPoint = _entryPoint;

        private static readonly ManifestOsSet _files = new ManifestOsSet
        {
            Windows = new Collection<ManifestFile>
            {
                new ManifestFile()
                {
                    SourcePath = _entryPoint,
                    TargetPath = _entryPoint,
                },
                new ManifestFile()
                {
                    SourcePath = "Appccelerate.EventBroker.dll",
                    TargetPath = "Appccelerate.EventBroker.dll",
                },
                new ManifestFile()
                {
                    SourcePath = "Appccelerate.Fundamentals.dll",
                    TargetPath = "Appccelerate.Fundamentals.dll",
                },
            }
        };

        public static ModuleInfo ModuleInfo { get; } = new ModuleInfo
        {
            ModuleType = ModuleType.Feature,
            Id = Guid.Parse(_guid),
            Name = _name,
            Description = _description,
            Copyright = _copyright,
            Vendor = _vendor,
            Version = Version.Parse(_version),
            SupportedPlatforms = 
                ModuleSupportedPlatform.Android | 
                ModuleSupportedPlatform.Chrome | 
                ModuleSupportedPlatform.Ios | 
                ModuleSupportedPlatform.Linux | 
                ModuleSupportedPlatform.Mac | 
                ModuleSupportedPlatform.Windows,
        };

        public static Collection<ConfigurationSetting> ConfigurationSettings = new Collection<ConfigurationSetting>()
        {
            new ConfigurationSetting()
            {
                KeyName = "ShowDebug",
                Name = new MultiLanguageString("ShowDebug"),
                Description = new MultiLanguageString("Set to load default test data"),
                AllowEmpty = false,
                Type = ConfigurationSettingType.Bool,
                UnitType = new MultiLanguageString("ShowDebug Data"),
                DefaultValue = "True",
                //Regex = @"^(True|False)$",
            },
        };

        public static ModuleManifest ModuleManifest { get; } = new ModuleManifest
        {
            Owner = UniteModuleOwner.Hub,
            ModuleId = ModuleInfo.Id,
            Name = new MultiLanguageString(ModuleInfo.Name),
            Description = new MultiLanguageString(ModuleInfo.Description),
            ModuleVersion = ModuleInfo.Version,
            MinimumUniteVersion = Version.Parse(_minimumUniteVersion),
            Settings = ConfigurationSettings,
            Files = _files,
            Installers = new Collection<ManifestInstaller>(),
            EntryPoint = _entryPoint,
            ModuleType = ModuleInfo.ModuleType,
        };
    }
}
