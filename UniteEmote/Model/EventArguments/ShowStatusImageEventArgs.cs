using System;
using UniteEmote.ViewModel.Controls;

namespace UniteEmote.Model.EventArguments
{
    [Serializable]
    public class ShowStatusImageEventArgs : HubViewEventArgs
    {
        public StatusViewControlViewModel ViewModel { get; set; }
    }
}
