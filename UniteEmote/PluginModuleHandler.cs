using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Intel.Unite.Common.Command;
using Intel.Unite.Common.Context;
using Intel.Unite.Common.Core;
using Intel.Unite.Common.Display;
using Intel.Unite.Common.Display.Hub;
using Intel.Unite.Common.Manifest;
using Intel.Unite.Common.Module.Common;
using Intel.Unite.Common.Module.Feature.Hub;
using UniteEmote.ClientUI;
using UniteEmote.Model.EventArguments;
using UniteEmote.Static;
using UniteEmote.Utility;
using UniteEmote.View;
using UniteEmote.ViewModel;
using UniteEmote.Constants;


namespace UniteEmote
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
        
        public override ModuleInfo ModuleInfo => ModuleConstants.ModuleInfo;
        
        public override ModuleManifest ModuleManifest => ModuleConstants.ModuleManifest;

        public override string HtmlUrlOrContent => _htmlUrlOrContent;

        public override Dispatcher CurrentUiDispatcher { get ; set; }

        public readonly List<FrameworkElement> Views = new List<FrameworkElement>();
        private readonly string _htmlUrlOrContent = "error";

        private void AddQuickAccessIconToViews()
        {
            CurrentUiDispatcher.Invoke(delegate
            {
                RuntimeContext.DisplayManager.AvailableDisplays.ToList().ForEach(d => Views.Add(GetNewQuickAccessIconView(d)));
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
            List<FrameworkElement> quickAccessIconViews = Views.Where(view => (view.DataContext as HubViewModel).HubAllocationInfo.ViewType == 
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
            ModuleImage = UniteImageHelper.GetUniteImageFromResource("/UniteEmote;component/Images/menu-icon.png", UniteImageType.Png);
            _html = ClientUISetup.getHtml();
        }
    }
}
