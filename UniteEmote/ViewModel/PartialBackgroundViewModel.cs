using System;
using UnitePlugin.ViewModel;

namespace UnitePlugin.ViewModel
{
    [Serializable]
    public class PartialBackgroundViewModel : HubViewModel
    {
        public string Title { get; set; } = "Partial Presentation View";
    }
}