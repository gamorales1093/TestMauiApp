using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestMauiApp.Models;
using TestMauiApp.WebServices.Interfaces;
using Newtonsoft.Json;

namespace TestMauiApp.WebServices.Implementation
{
    public partial class ProxyAPI : IProxyAPI
    {
        #region parameters
        protected readonly ISettings _settingsSrv;
        #endregion parameters
        #region constructor
        public ProxyAPI(ISettings _settings)
        {
            _settingsSrv = _settings;
        }


        #endregion cosntructor
        #region interfaz implementation
        public async Task<List<Prospect>> GetProspects()
        {
            List<Prospect> prospects = new List<Prospect>();
            try
            {
                //http client
                var uri = new Uri(_settingsSrv.GetProspects());
                var client = new HttpClient();

                //call service
                var response = await client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    var resultJson = await response.Content.ReadAsStringAsync();
                    if(!string.IsNullOrEmpty(resultJson))
                    {
                        prospects = JsonConvert.DeserializeObject<List<Prospect>>(resultJson);
                    }
                }


            }
            catch (Exception ex)
            {

                throw;
            }

            return prospects;
        }

        public async Task<List<Activity>> GetActivitiesByPr(int idProspect)
        {
            List<Activity> prospects = new List<Activity>();
            try
            {
                //http client
                var uri = new Uri($"{_settingsSrv.GetActivities()}/{idProspect}");
                var client = new HttpClient();

                //call service
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var resultJson = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(resultJson))
                    {
                        prospects = JsonConvert.DeserializeObject<List<Activity>>(resultJson);
                    }
                }


            }
            catch (Exception ex)
            {

                throw;
            }

            return prospects;
        }

        public async Task<string> DeleteActivityById(int idActivity)
        {
            string status = string.Empty;
            try
            {
                //http client
                var uri = new Uri($"{_settingsSrv.GetActivities()}/{idActivity}");
                var client = new HttpClient();

                //call service
                var response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    status = await response.Content.ReadAsStringAsync();

                }


            }
            catch (Exception ex)
            {

                throw;
            }

            return status;
        }

        public async Task<string> UpdateActivityById(int idActivity, Activity activity)
        {
            string activiti = string.Empty;
            try
            {
                //http client
                var uri = new Uri($"{_settingsSrv.GetActivities()}/{idActivity}");
                var client = new HttpClient();

                //call service
                var stringContent = new StringContent(JsonConvert.SerializeObject(activity), Encoding.UTF8, "application/json");
                var response = await client.PutAsync(uri, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    activiti = await response.Content.ReadAsStringAsync();
                }


            }
            catch (Exception ex)
            {

                throw;
            }

            return activiti;
        }

        public async Task<List<Types>> GetTypes()
        {
            List<Types> types = new List<Types>();
            try
            {
                //http client
                var uri = new Uri(_settingsSrv.GetTypes());
                var client = new HttpClient();

                //call service
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var resultJson = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(resultJson))
                    {
                        types = JsonConvert.DeserializeObject<List<Types>>(resultJson);
                    }
                }


            }
            catch (Exception ex)
            {

                throw;
            }

            return types;
        }

        public async Task<Activity> InsertActivity(Activity activity)
        {
            Activity activiti =new Activity();
            try
            {
                //http client
                var uri = new Uri($"{_settingsSrv.GetActivities()}");
                var client = new HttpClient();

                //call service
                var stringContent = new StringContent(JsonConvert.SerializeObject(activity), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, stringContent);
                var resultJson = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(resultJson))
                {
                    activiti = JsonConvert.DeserializeObject<Activity>(resultJson);
                }


            }
            catch (Exception ex)
            {

                throw;
            }

            return activiti;
        }

        #endregion interfaz implementation
    }
}
