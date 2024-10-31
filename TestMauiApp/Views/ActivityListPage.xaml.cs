using TestMauiApp.ViewModels;

namespace TestMauiApp.Views;

public partial class ActivityListPage : ContentPage
{
	public ActivityListPage(ActivityListPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}