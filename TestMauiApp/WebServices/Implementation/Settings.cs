using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMauiApp.WebServices.Interfaces;

namespace TestMauiApp.WebServices.Implementation
{
    public partial class Settings : ISettings
    {
        #region parameters

        private readonly string URLBase = "http://10.0.2.2:5041/api/";//android;
        private readonly string _entryPointProspects="prospect";
        private readonly string _entryPointActivities = "activity";
        private readonly string _entryPointTypes = "types";
        #endregion parameters
        public string GetBaseURL()
        {
            return URLBase;
        }
        public string GetProspects()
        {
            return $"{GetBaseURL()}{_entryPointProspects}";
        }
        public string GetActivities()
        {
            return $"{GetBaseURL()}{_entryPointActivities}";
        }
        public string GetTypes()
        {
            return $"{GetBaseURL()}{_entryPointTypes}";
        }
    }
}
