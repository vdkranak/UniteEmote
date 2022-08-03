using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using Intel.Unite.Common.Command;
using Intel.Unite.Common.Context;
using Intel.Unite.Common.Core;
using Intel.Unite.Common.Manifest;
using Intel.Unite.Common.Module.Common;
using Intel.Unite.Common.Module.Feature.Hub;
using System.Windows;
using UnitePlugin.ViewModel;
using System.Linq;
using Intel.Unite.Common.Display.Hub;
using Intel.Unite.Common.Display;
using UnitePlugin.View;
using UnitePlugin.ClientUI;
using UnitePlugin.UI;
using UnitePlugin.Static;
using UnitePlugin.Model.EventArguments;

namespace UnitePlugin
{

    public class PluginModuleHandler : HubFeatureModuleBase
    {
        public PluginModuleHandler() : base()
        { 

        }

        public PluginModuleHandler(IModuleRuntimeContext runtimeContext) : base(runtimeContext)
        {
            ConfigureModuleForClient();
        }

        private const string _guid = "06553064-76f4-48b1-ae57-f66d264634ea";
        private const string _name = "UnitePlugin";
        private const string _description = "UnitePlugin";
        private const string _copyright = "Intel Corporation 2022";
        private const string _vendor = "Intel Corporation";
        private const string _version = "1.0.0";

        private static readonly ModuleInfo _moduleInfo = new ModuleInfo
        {
            ModuleType = ModuleType.Feature,
            Id = Guid.Parse(_guid),
            Name = _name,
            Description = _description,
            Copyright = _copyright,
            Vendor = _vendor,
            Version = Version.Parse(_version),
            SupportedPlatforms = ModuleSupportedPlatform.Mac | ModuleSupportedPlatform.Windows,
        };
        public override ModuleInfo ModuleInfo => _moduleInfo;

        private const string _minimumUniteVersion = "4.0.0.0";
        private const string _entryPoint = "UniteEmote.dll";
        private static readonly ManifestOsSet _files = new ManifestOsSet
        {
            Windows = new Collection<ManifestFile>
            {
                 new ManifestFile()
                {
                    SourcePath = _entryPoint,
                    TargetPath = _entryPoint,
                }
                }
        };
        private static readonly ModuleManifest _moduleManifest = new ModuleManifest
        {
            Owner = UniteModuleOwner.Hub,
            ModuleId = _moduleInfo.Id,
            Name = new MultiLanguageString(_moduleInfo.Name),
            Description = new MultiLanguageString(_moduleInfo.Description),
            ModuleVersion = _moduleInfo.Version,
            MinimumUniteVersion = Version.Parse(_minimumUniteVersion),
            Settings = new Collection<ConfigurationSetting>(),
            Files = _files,
            Installers = new Collection<ManifestInstaller>(),
            EntryPoint = _entryPoint,
            ModuleType = _moduleInfo.ModuleType,
        };
        public override ModuleManifest ModuleManifest => _moduleManifest;

        public override string HtmlUrlOrContent => _htmlUrlOrContent;

        public override Dispatcher CurrentUiDispatcher { get ; set; }

        private readonly List<FrameworkElement> views = new List<FrameworkElement>();
        private string _htmlUrlOrContent;

        private void AddQuickAccessIconToViews()
        {
            CurrentUiDispatcher.Invoke(delegate
            {
                RuntimeContext.DisplayManager.AvailableDisplays.ToList().ForEach(d => views.Add(GetNewQuickAccessIconView(d)));
            });
        }

        private QuickAccessAppIconView GetNewQuickAccessIconView(PhysicalDisplay display)
        {
            return new QuickAccessAppIconView
            {
                DataContext = new HubViewModel
                {
                    HubAllocationInfo = new HubAllocationInfo
                    {
                        FriendlyName = "QuickAccessIcon",
                        ModuleOwnerId = ModuleInfo.Id,
                        PhysicalDisplay = display,
                        ViewType = HubDisplayViewType.QuickAccessAppIconView,
                    }
                }
            };
        }

        public override void Load()
        {
            AddQuickAccessIconToViews();
            AllocatedQuickAccessIconViewsToHub();
        }

        private void AllocatedQuickAccessIconViewsToHub()
        {
            List<FrameworkElement> quickAccessIconViews = views.Where(view => (view.DataContext as HubViewModel).HubAllocationInfo.ViewType == 
            HubDisplayViewType.QuickAccessAppIconView).ToList();
            quickAccessIconViews.ForEach(view => AllocateView(view));

        }

        private void AllocateView(FrameworkElement view)
        {
            HubViewModel hubViewModel = null;
            CurrentUiDispatcher.Invoke(delegate
            {
                hubViewModel = (HubViewModel)view.DataContext;
            });
            RuntimeContext.DisplayManager.AllocateUiInHubDisplayAsync(
            CreateContract(view),
            hubViewModel.HubAllocationInfo,
            hubViewModel.AllocatedCallBack
            );
        }

        public override void IncomingMessage(Message message)
        {
            if(message.TargetModuleId == ModuleInfo.Id)
            {
                if (typeof(EventArgumentTypes).IsEnumDefined(message.DataType))
                {
                    MessagingEventBroker.Process(message);
                }
            }
        }

        public override void SessionKeyChanged(KeyValuePair sessionKey)
        {
            
        }

        public override void UserConnected(UserInfo userInfo)
        {
            
        }

        public override void UserInfoChanged(UserInfo userInfo)
        {
            
        }

        public override void UserDisconnected(UserInfo userInfo)
        {
            
        }

        public override void HubConnected(HubInfo hubInfo)
        {
            
        }

        public override void HubInfoChanged(HubInfo hubInfo)
        {
            
        }

        public override void HubDisconnected(HubInfo hubInfo)
        {
            
        }

        public override bool OkToSleepDisplay()
        {
            return true;
        }

        public override void Unload()
        {
            
        }



        private string _html = @"<!DOCTYPE html><html><head><title>Error</title><script type='text/javascript'>window.onload=function(){alert();}</script></head>
                                <body onclick='alert()'><div>If you're reading this, something went wrong.</div></body></html>";

        private void ConfigureModuleForClient()
        {
            FeatureModuleType = FeatureModuleType.Html;
            ModuleImage = UniteImageHelper.GetUniteImageFromResource("/UnitePlugin;component/Images/menu-icon.png", UniteImageType.Png);
            _html = ClientUISetup.getHtml();
        }
    }
}
