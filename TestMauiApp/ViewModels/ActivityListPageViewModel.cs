
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMauiApp.Helper;
using TestMauiApp.WebServices.Interfaces;
using TestMauiApp.Models;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using TestMauiApp.Views;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace TestMauiApp.ViewModels
{
    public partial class ActivityListPageViewModel : ObservableObject, IQueryAttributable
    {
        #region properties
        protected readonly IProxyAPI proxyAPI;
        [ObservableProperty]
        public ObservableCollection<Activity> activities;

        [ObservableProperty]
        public int idProspect;

        [ObservableProperty]
        Activity activitySelect;
        #endregion properties

        public ActivityListPageViewModel(IProxyAPI _proxyAPI)
        {

            proxyAPI = _proxyAPI;
        }

        [RelayCommand]
        async Task DeleteEvent(object obj)
        {
            var activity = obj as Activity;
            if (activity != null)
            {
                var resp = await DialogHelper.ConfirmAlert("Desea eliminar la actividad seleccionada?", "Actividad", "Aceptar");
                if(resp)
                {
                    var response = await proxyAPI.DeleteActivityById(activity.Id);
                    if(response.Contains("successfully"))
                    {
                        LoadData(activity.ProspectId);
                    }
                }
                //var uri = $"{nameof(ActivityListPage)}?id={prospect.Id}";
                //await Shell.Current.GoToAsync(uri);
                //ProspectSelect = null;
            }

        }
        [RelayCommand]
        async Task EditEvent(object obj)
        {
            var activity = obj as Activity;
            if (activity != null)
            {

               var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                string  enviar = JsonConvert.SerializeObject(activity, Formatting.Indented);
                int Id = activity.Id;
                DateTime DateOfActivity = activity.DateOfActivity;
                string Description = activity.Description;
                int Rate = activity.Rate;
                int TypesId = activity.TypesId;
                int ProspectId = activity.ProspectId;

                var uri = $"{nameof(ActivityEditPage)}?id={Id}&fecha={DateOfActivity.ToShortDateString()}&des={Description}&rate={Rate}&tipe={TypesId}&idpro={ProspectId}&param=0";
                await Shell.Current.GoToAsync(uri);
            }
        }
        [RelayCommand]
        async Task NewEvent(object obj)
        {

            var uri = $"{nameof(ActivityEditPage)}?id={IdProspect}&param=1";
            await Shell.Current.GoToAsync(uri);

        }
        #region methods
        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            IdProspect = int.Parse(query["id"].ToString());
            LoadData(IdProspect);
        }

        public async void LoadData(int idProspect)
        {
            DialogHelper.ShowLoading();
            Activities = new ObservableCollection<Activity>();

            var activitiesList = await proxyAPI.GetActivitiesByPr(idProspect);
            foreach (var item in activitiesList)
            {
                Activities.Add(item);
            }
            DialogHelper.HideLoading();
        }


        #endregion methods
    }
}
