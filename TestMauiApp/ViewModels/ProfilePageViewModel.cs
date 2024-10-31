using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestMauiApp.Helper;
using TestMauiApp.Views;

namespace TestMauiApp.ViewModels
{
    public partial class ProfilePageViewModel : ObservableObject
    {

        [RelayCommand]
        public async Task LogOut()
        {
            bool answer = await DialogHelper.ConfirmAlert("Desea salir de la aplicación?", "Perfil", "Aceptar");
            if (answer)
            {
                Preferences.Set("logged", string.Empty);
                Application.Current.MainPage = new LoginPage();
            }
        }
    }
}

