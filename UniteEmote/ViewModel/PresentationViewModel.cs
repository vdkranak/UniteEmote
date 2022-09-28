using System;

namespace UniteEmote.ViewModel
{
    [Serializable]
    public class PresentationViewModel : HubViewModel
    {
        public string Title { get; set; } = "Presentation View";
    }
}