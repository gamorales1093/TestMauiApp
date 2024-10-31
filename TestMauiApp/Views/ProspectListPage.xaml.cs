
using TestMauiApp.ViewModels;
namespace TestMauiApp.Views;

public partial class ProspectListPage : ContentPage
{
    private readonly ProspectListPageViewModel _viewModel;
    public ProspectListPage(ProspectListPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
       _viewModel.ApplyQueryAttributes();
    }
}