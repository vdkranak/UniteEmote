using System;
using UniteEmote.ViewModel.Controls;

namespace UniteEmote.Model.EventArguments
{
    ///Create in UnitePlugin.Model.EventArguments
    ///and add to enum EventArgumentTypes
    [Serializable]
    public class ShowStatusImageEventArgs : HubViewEventArgs
    {
        public StatusViewControlViewModel ViewModel { get; set; }
    }
}
