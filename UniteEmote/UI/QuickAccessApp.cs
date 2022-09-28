using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Intel.Unite.Common.Context.Hub;
using Intel.Unite.Common.Display;
using Intel.Unite.Common.Display.Hub;
using Intel.Unite.Common.Module.Common;
using UniteEmote.Model.EventArguments;
using UniteEmote.View;
using UniteEmote.ViewModel;

namespace UniteEmote.UI
{
    [Serializable]
    public class QuickAccessApp : HubViewBase
    {
        [field: NonSerialized]
        private readonly HubDisplayViewType _hubDisplayViewType = HubDisplayViewType.QuickAccessAppView;

        [field: NonSerialized]
        private QuickAccessAppView _quickAccessAppView;
        private QuickAccessAppViewModel _quickAccessAppViewModel;

        protected override UserControl HubView => _quickAccessAppView;
        protected override HubViewModel HubViewModel => _quickAccessAppViewModel;
        public override void SetDeallocate()
        {
            IsAllocated = false;
            SetQuickAccessAppView();
        }

        protected override HubDisplayViewType HubDisplayViewType => _hubDisplayViewType;

        public QuickAccessAppViewModel QuickAccessAppViewModel => _quickAccessAppViewModel;


        public QuickAccessApp(IHubModuleRuntimeContext runtimeContext, Func<FrameworkElement, MarshalNativeHandleContract> createContract, PhysicalDisplay display, Dispatcher currentUiDispatcher, EventHandler<HubViewEventArgs> eventCommandInvoker)
            : base(runtimeContext, display, currentUiDispatcher, createContract)
        {
            SetQuickAccessAppView();
        }


        private void SetQuickAccessAppView()
        {
            CurrentUiDispatcher.Invoke(delegate
            {
                _quickAccessAppView = new QuickAccessAppView();

                _quickAccessAppViewModel = _quickAccessAppView.DataContext as QuickAccessAppViewModel;
                _quickAccessAppViewModel.ControlIdentifier = ViewGuid;
            });
        }





    }
}
