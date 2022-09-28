using System;
using UniteEmote.ViewModel.Controls;

namespace UniteEmote.Model.EventArguments
{
    [Serializable]
    public class ShowPresentationViewEventArgs : HubViewEventArgs
    {
        public PresentationControlViewModel ViewModel { get; set; }
    }
}