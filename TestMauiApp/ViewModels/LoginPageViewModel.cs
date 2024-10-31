using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMauiApp.Helper;

namespace TestMauiApp.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        public string user = string.Empty;
        [ObservableProperty]
        public string password = string.Empty;

        [CommunityToolkit.Mvvm.Input.RelayCommand]
        private async Task Login()
        {
            DialogHelper.ShowLoading();
            if (User == "Admin" && Password == "123456")
            {
                Preferences.Set("logged", "ok");
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                await DialogHelper.ShowAlert("User or Password invalid", "Alert", "OK");
            }
            DialogHelper.HideLoading();
        }
    }
}
