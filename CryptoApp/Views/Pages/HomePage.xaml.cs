using Wpf.Ui.Common.Interfaces;

namespace CryptoApp.Views.Pages
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class HomePage : INavigableView<ViewModels.HomeViewModel>
    {
        public ViewModels.HomeViewModel ViewModel
        {
            get;
        }

        public HomePage(ViewModels.HomeViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }
    }
}
