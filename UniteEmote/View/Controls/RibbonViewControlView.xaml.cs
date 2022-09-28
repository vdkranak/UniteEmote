using System.Windows.Controls;
using UniteEmote.ViewModel.Controls;
using UniteEmote.ViewModel.Factory;

namespace UniteEmote.View.Controls
{
    /// <summary>
    /// Interaction logic for RibbonViewControlView.xaml
    /// </summary>
    public partial class RibbonViewControlView : UserControl
    {
        public RibbonViewControlView()
        {
            InitializeComponent();
            DataContext = SingletonViewModelFactory<RibbonViewControlViewModel>.GetInstance;
        }
    }
}
