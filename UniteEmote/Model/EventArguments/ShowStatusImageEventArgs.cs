﻿using System;
using UnitePlugin.ViewModel.Controls;

namespace UnitePlugin.Model.EventArguments
{
    ///Create in UnitePlugin.Model.EventArguments
    ///and add to enum EventArgumentTypes
    [Serializable]
    public class ShowStatusImageEventArgs : HubViewEventArgs
    {
        public StatusViewControlViewModel ViewModel { get; set; }
    }
}
