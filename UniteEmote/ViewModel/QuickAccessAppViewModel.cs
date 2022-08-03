using System;
using UnitePlugin.ViewModel;

namespace UnitePlugin.ViewModel
{
    [Serializable]
    public class QuickAccessAppViewModel : HubViewModel
    {
        public string Title { get; set; } = "Quick Access App View";
    }
}