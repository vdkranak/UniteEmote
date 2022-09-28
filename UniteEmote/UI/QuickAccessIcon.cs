﻿using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Intel.Unite.Common.Context.Hub;
using Intel.Unite.Common.Display;
using Intel.Unite.Common.Display.Hub;
using Intel.Unite.Common.Module.Common;
using UniteEmote.Constants;
using UniteEmote.Model.EventArguments;
using UniteEmote.View;
using UniteEmote.ViewModel;

namespace UniteEmote.UI
{
    [Serializable]
    public class QuickAccessIcon : HubViewBase
    {
        [field: NonSerialized]
        private readonly HubDisplayViewType _hubDisplayViewType = HubDisplayViewType.QuickAccessAppIconView;



        [field: NonSerialized]
        private QuickAccessIconView _quickAccessIconView;
        private QuickAccessIconViewModel _quickAccessIconViewModel;
        [field: NonSerialized]
        private EventHandler<HubViewEventArgs> _eventCommandInvoker;

        protected override UserControl HubView => _quickAccessIconView;
        protected override HubViewModel HubViewModel => _quickAccessIconViewModel;
        public override void SetDeallocate()
        {
            IsAllocated = false;
            SetQuickAccessIconView();
        }

        protected override HubDisplayViewType HubDisplayViewType => _hubDisplayViewType;

        public QuickAccessIconViewModel QuickAccessIconViewModel => _quickAccessIconViewModel;


        public QuickAccessIcon(IHubModuleRuntimeContext runtimeContext, Func<FrameworkElement, MarshalNativeHandleContract> createContract, PhysicalDisplay display, Dispatcher currentUiDispatcher, EventHandler<HubViewEventArgs> eventCommandInvoker)
            : base(runtimeContext, display, currentUiDispatcher, createContract)
        {
            _eventCommandInvoker = eventCommandInvoker;
            SetQuickAccessIconView();
        }

        private void SetCommandEvents()
        {
            _quickAccessIconViewModel.ShowQuickAccessControl += _eventCommandInvoker;
        }

        private void SetQuickAccessIconView()
        {
            CurrentUiDispatcher.Invoke(delegate
            {
                _quickAccessIconView = new QuickAccessIconView();
                _quickAccessIconViewModel = _quickAccessIconView.DataContext as QuickAccessIconViewModel;
                _quickAccessIconViewModel.ControlIdentifier = ViewGuid;
                SetCommandEvents();

                string assemblyPath = ModuleConstants.EntryPoint;
                if (!File.Exists(assemblyPath))
                    assemblyPath = @"C:\ProgramData\Intel\Intel Unite\Hub\current\FeatureModules\" +
                                   ModuleConstants.ModuleInfo.Id + "\\" + ModuleConstants.EntryPoint;

                _quickAccessIconViewModel.Image = Intel.Unite.Common.Utils.BytesHelper.SetImageFromResource(Guid.NewGuid(),
                        UniteImageType.Png, "UniteEmote.Images.menu-icon.png", Assembly.LoadFrom(assemblyPath));
            });
        }
    }
}
