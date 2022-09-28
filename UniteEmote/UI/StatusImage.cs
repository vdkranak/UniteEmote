using System;
using System.Windows;
using System.Windows.Threading;
using Intel.Unite.Common.Context.Hub;
using Intel.Unite.Common.Display;
using Intel.Unite.Common.Display.Hub;
using Intel.Unite.Common.Module.Common;
using UniteEmote.Model.EventArguments;
using UniteEmote.Utility;

namespace UniteEmote.UI
{
    [Serializable]
    public class StatusImage : ImageViewBase
    {
        protected override HubDisplayViewType HubDisplayViewType { get; set; } = HubDisplayViewType.StatusView;

        public StatusImage(IHubModuleRuntimeContext runtimeContext, PhysicalDisplay display, Dispatcher currentUiDispatcher, Func<FrameworkElement, MarshalNativeHandleContract> createContract, EventHandler<HubViewEventArgs> eventCommandInvoker)
            : base(runtimeContext, display, currentUiDispatcher, createContract)
        {
            Image = UniteImageHelper.GetUniteImageFromResource("/UniteEmote;component/Images/business-user.png", UniteImageType.Png);
        }
    }
}

