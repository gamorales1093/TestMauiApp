using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestMauiApp.Models;
using TestMauiApp.Views;
using TestMauiApp.Helper;
using TestMauiApp.WebServices.Interfaces;

namespace TestMauiApp.ViewModels
{
    public partial class ProspectListPageViewModel : ObservableObject
    {


        #region properties
        protected readonly IProxyAPI proxyAPI;
        [ObservableProperty]
        public List<Prospect> prospects;

        [ObservableProperty]
        public List<Prospect> prospectsAll;

        [ObservableProperty]
        Prospect prospectSelect;

        [ObservableProperty]
        bool isVisibleClear;

        [ObservableProperty]
        public string searchText;
        #endregion properties
        partial void OnSearchTextChanged(string? oldValue, string? newValue) => FilterProducts();

        [RelayCommand]
        private async void Clear()
        {
            SearchText = string.Empty;
            IsVisibleClear = false;
        }

        [RelayCommand]
        async Task ProspectEventSelected(object obj)
        {
            var prospect = obj as Prospect;
            if (prospect != null)
            {
                var uri = $"{nameof(ActivityListPage)}?id={prospect.Id}";
                await Shell.Current.GoToAsync(uri);
                ProspectSelect = null;
            }

        }

        public ProspectListPageViewModel(IProxyAPI _proxy)
        {
            //var settingsService = this.Handler.MauiContext.Services.GetServices<ISettingsService>();
            proxyAPI = _proxy;
        }


        public async void ApplyQueryAttributes()
        {

            DialogHelper.ShowLoading();

            var lisProspects = await proxyAPI.GetProspects();
            Prospects = new List<Prospect>();
            ProspectsAll= new List<Prospect>();
            foreach (var p in lisProspects)
            {
                Prospects.Add(p);
                ProspectsAll.Add(p);
            }

            DialogHelper.HideLoading();
        }

        public async void FilterProducts()
        {
            try
            {

                Prospects = new List<Prospect>();

                if (!string.IsNullOrEmpty(SearchText))
                {
                    IsVisibleClear = true;
                    var listProspects =  ProspectsAll.Where(x => x.FullName.ToLower().Contains(SearchText.ToLower()));

                    foreach (var p in listProspects)
                    {

                        Prospects.Add(p);
                    }

                }
                else
                {
                    IsVisibleClear = false;
                    ApplyQueryAttributes();
                }


            }
            catch (Exception ex)
            {


            }



        }
    }
}
