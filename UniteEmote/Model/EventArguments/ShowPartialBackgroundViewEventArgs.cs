using System;
using UniteEmote.ViewModel.Controls;

namespace UniteEmote.Model.EventArguments
{
    [Serializable]
    public class ShowPartialBackgroundViewEventArgs : HubViewEventArgs
    {
        public PartialBackgroundControlViewModel ViewModel { get; set; }
    }
}
