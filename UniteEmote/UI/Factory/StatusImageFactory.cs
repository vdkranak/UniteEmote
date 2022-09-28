﻿using System;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using Intel.Unite.Common.Context.Hub;
using Intel.Unite.Common.Display;
using Intel.Unite.Common.Logging;
using Intel.Unite.Common.Module.Common;
using UniteEmote.Constants;
using UniteEmote.Interfaces;
using UniteEmote.Model.EventArguments;

namespace UniteEmote.UI.Factory
{
    public class StatusImageFactory : HubViewFactory
    {
        public override IHubView Create(IHubModuleRuntimeContext runtimeContext,
            Func<FrameworkElement, MarshalNativeHandleContract> createContract,
            PhysicalDisplay display, Dispatcher currentUiDispatcher, EventHandler<HubViewEventArgs> eventCommandInvoker)
        {
            runtimeContext.LogManager.LogMessage(
                ModuleConstants.ModuleInfo.Id,
                LogLevel.Trace,
                GetType().Name,
                MethodBase.GetCurrentMethod() + Environment.NewLine + GetHashCode());

            return new StatusImage(runtimeContext, display, currentUiDispatcher, createContract, eventCommandInvoker);
        }
    }
}