using System;
using UniteEmote.ViewModel.Controls;

namespace UniteEmote.Model.EventArguments
{
    [Serializable]
    public class ShowAuthViewEventArgs : HubViewEventArgs
    {
        public AuthViewControlViewModel ViewModel { get; set; }
    }
}
