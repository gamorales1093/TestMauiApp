using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMauiApp.Helper;
using TestMauiApp.Models;
using TestMauiApp.WebServices.Interfaces;

namespace TestMauiApp.ViewModels
{
    public partial class ActivityEditPageViewModel : ObservableObject, IQueryAttributable
    {
        #region properties

        protected readonly IProxyAPI proxyAPI;
        [ObservableProperty]
        public ObservableCollection<Types> typesList;

        [ObservableProperty]
        public Types currentType;

        [ObservableProperty]
        public int param;

        [ObservableProperty]
        public int prospectGlobal;

        [ObservableProperty]
        public Activity activitie;

        #endregion properties

        public ActivityEditPageViewModel(IProxyAPI _proxyAPI)
        {
            proxyAPI = _proxyAPI;
        }

        #region methods
        [RelayCommand]
        async Task NewEvent(object obj)
        {
            try
            {
                DialogHelper.ShowLoading();

                if(Param == 0)
                {

                    bool validateData = await ValidateData();

                    if (validateData)
                    {
                        Activitie.TypesId = CurrentType.Id;
                        Activitie.Type = CurrentType;

                        var resul = await proxyAPI.UpdateActivityById(Activitie.Id, Activitie);
                        if (resul.Contains("successfully"))
                        {
                            await DialogHelper.ShowAlert("Datos actualizado con exito", "Actividad", "Aceptar");

                            await Shell.Current.Navigation.PopAsync();
                        }
                    }
                }
                
                if(Param == 1)
                {
                    bool validateData = await ValidateData();

                    if(validateData)
                    {
                        Activitie.TypesId = CurrentType.Id;
                        Activitie.Type = CurrentType;
                        Activitie.ProspectId = ProspectGlobal;

                        var resul = await proxyAPI.InsertActivity(Activitie);
                        if (resul !=null)
                        {
                            await DialogHelper.ShowAlert("Datos guardados con exito", "Actividad", "Aceptar");

                            await Shell.Current.Navigation.PopAsync();
                        }
                    }

                }

                DialogHelper.HideLoading();
                        
            }
            catch (Exception)
            {

                DialogHelper.HideLoading();
            }

        }

        public async Task<bool> ValidateData()
        {
            bool status = true;
            try
            {
                if (string.IsNullOrEmpty(Activitie.Description))
                {
                    await DialogHelper.ShowAlert("El campo descripción es requerido", "Actividad", "Aceptar");
                    return false; 
                }
                if (Activitie.Rate<0 || Activitie.Rate > 5)
                {
                    await DialogHelper.ShowAlert("El campo calificación debe estar en el rango de 0-5", "Actividad", "Aceptar");
                    return false;
                }
                if (CurrentType ==null)
                {
                    await DialogHelper.ShowAlert("El campo tipo es requerido", "Actividad", "Aceptar");
                    return false;
                }



            }
            catch (Exception)
            {

                throw;
            }

            return status;
        }
        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            DialogHelper.ShowLoading();
            TypesList = new ObservableCollection<Types>();
            //get Types
            var types = await proxyAPI.GetTypes();
            foreach (var type in types)
            {
                TypesList.Add(type);  
            }

            if (TypesList !=null)
            {

                Param = int.Parse(query["param"].ToString());
                if (Param == 0)//Edit
                {
                    var id = int.Parse(query["id"].ToString());
                    var fecha = DateTime.Parse(query["fecha"].ToString());
                    var des = query["des"].ToString().Replace("%20", " ");
                    var rate = int.Parse(query["rate"].ToString());
                    var typesId = int.Parse(query["tipe"].ToString());
                    var ProspectId = int.Parse(query["idpro"].ToString());

                    CurrentType = TypesList.FirstOrDefault(x => x.Id == typesId);

                    Activitie = new Activity
                    {
                        Id = id,
                        DateOfActivity = fecha,
                        Description = des,
                        Rate = rate,
                        TypesId = typesId,
                        Type = CurrentType,
                        ProspectId = ProspectId
                    };

                }
                if (Param == 1)//New
                {
                    ProspectGlobal = int.Parse(query["id"].ToString());
                    Activitie = new Activity();
                    Activitie.DateOfActivity = DateTime.Now;


                }
            }


            DialogHelper.HideLoading();
        }

        #endregion methods

    }
}
