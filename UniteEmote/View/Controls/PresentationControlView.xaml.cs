using System.Windows.Controls;
using UniteEmote.ViewModel.Controls;
using UniteEmote.ViewModel.Factory;

namespace UniteEmote.View.Controls
{
    /// <summary>
    /// Interaction logic for PresentationControlView.xaml
    /// </summary>
    public partial class PresentationControlView : UserControl
    {
        public PresentationControlView()
        {
            InitializeComponent();
            DataContext = SingletonViewModelFactory<PresentationControlViewModel>.GetInstance;
        }
    }
}
