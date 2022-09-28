using System;
using UnitePlugin.ViewModel;

namespace UnitePlugin.ViewModel
{
    [Serializable]
    public class BackgroundViewModel : HubViewModel
    {
        public string Title { get; set; } = "Background View";

    }
}