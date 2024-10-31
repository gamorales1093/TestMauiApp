using TestMauiApp.ViewModels;

namespace TestMauiApp.Views;

public partial class ActivityEditPage : ContentPage
{
    public ActivityEditPage(ActivityEditPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}