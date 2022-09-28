using System;
using UniteEmote.ViewModel.Controls;

namespace UniteEmote.Model.EventArguments
{
    [Serializable]
    public class ShowRibbonViewEventArgs : HubViewEventArgs
    {
        public RibbonViewControlViewModel ViewModel { get; set; }
    }
}
