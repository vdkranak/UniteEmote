using System.Windows.Controls;
using UniteEmote.ViewModel.Controls;
using UniteEmote.ViewModel.Factory;

namespace UniteEmote.View.Controls
{
    /// <summary>
    /// Interaction logic for StatusViewView.xaml
    /// </summary>
    public partial class StatusViewControlView : UserControl
    {
        public StatusViewControlView()
        {
            InitializeComponent();
            DataContext = SingletonViewModelFactory<StatusViewControlViewModel>.GetInstance;
        }
    }
}
