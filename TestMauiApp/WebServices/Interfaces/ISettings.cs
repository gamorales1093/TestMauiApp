using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMauiApp.WebServices.Interfaces
{
    public interface ISettings
    {
        public string GetBaseURL();
        public string GetProspects();
        public string GetActivities();
        public string GetTypes();
    }
}
