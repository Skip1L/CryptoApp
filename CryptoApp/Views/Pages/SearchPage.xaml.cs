using Wpf.Ui.Common.Interfaces;

namespace CryptoApp.Views.Pages
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : INavigableView<ViewModels.SearchViewModel>
    {
        public ViewModels.SearchViewModel ViewModel
        {
            get;
        }


        public SearchPage(ViewModels.SearchViewModel viewModel)
        {
            ViewModel = viewModel;
            
            InitializeComponent();

        }
    }
}