using Controls.UserDialogs.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMauiApp.Helper
{
    public static class DialogHelper
    {
        public static bool IsShowed = false;

        public static void ShowLoading(string text = "Loading")
        {
            if (IsShowed)
                return;

            IsShowed = true;
            UserDialogs.Instance.ShowLoading(text);
        }

        public static void HideLoading()
        {
            if (IsShowed == true)
            {
                IsShowed = false;
                UserDialogs.Instance.HideHud();
            }
        }

        public async static Task ShowAlert(string message, string title, string okText)
        {

            await UserDialogs.Instance.AlertAsync(message, title, okText);
        }

        public async static Task<bool> ConfirmAlert(string message, string title, string okText)
        {

            return await UserDialogs.Instance.ConfirmAsync(message, title, okText);
        }
    }
}
