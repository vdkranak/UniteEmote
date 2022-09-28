using System.Windows.Controls;
using UniteEmote.ViewModel.Controls;
using UniteEmote.ViewModel.Factory;

namespace UniteEmote.View.Controls
{
    /// <summary>
    /// Interaction logic for AuthViewControlView.xaml
    /// </summary>
    public partial class AuthViewControlView : UserControl
    {
        public AuthViewControlView()
        {
            InitializeComponent();
            DataContext = SingletonViewModelFactory<AuthViewControlViewModel>.GetInstance;
        }
    }
}
