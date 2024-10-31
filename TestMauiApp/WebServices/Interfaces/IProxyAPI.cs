using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMauiApp.Models;

namespace TestMauiApp.WebServices.Interfaces
{
    public interface IProxyAPI
    {
        #region Prospects
        public Task<List<Prospect>> GetProspects();
        #endregion Prospects
        #region Activities
        public Task<List<Activity>> GetActivitiesByPr(int idProspect);
        public Task<Activity> InsertActivity(Activity activity);
        public Task<string> DeleteActivityById(int idActivity);
        public Task<string> UpdateActivityById(int idActivity, Activity activity);
        #endregion Activities
        #region Types
        public Task<List<Types>> GetTypes();
        #endregion Types
    }
}
