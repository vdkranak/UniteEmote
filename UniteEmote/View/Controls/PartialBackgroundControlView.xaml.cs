using System.Windows.Controls;
using UniteEmote.ViewModel.Controls;
using UniteEmote.ViewModel.Factory;

namespace UniteEmote.View.Controls
{
    /// <summary>
    /// Interaction logic for PartialBackgroundControlView.xaml
    /// </summary>
    public partial class PartialBackgroundControlView : UserControl
    {
        public PartialBackgroundControlView()
        {
            InitializeComponent();
            DataContext = SingletonViewModelFactory<PartialBackgroundControlViewModel>.GetInstance;
        }
    }
}
