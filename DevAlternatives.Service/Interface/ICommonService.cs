using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAlternatives.Service.Interface
{
    public interface ICommonService
    {
        #region Country City State
        Dictionary<string, string> GetAllCountries();
        Dictionary<string, string> GetAllStates();
        Dictionary<int, string> GetAllCities();
        Dictionary<string, string> GetStateByCountry(string CountryId);
        Dictionary<int, string> GetCityByState(string StateID);

        #endregion
    }
}
