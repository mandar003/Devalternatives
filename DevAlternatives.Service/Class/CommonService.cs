using DevAlternatives.Repository.UnitOfWork;
using DevAlternatives.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAlternatives.Service.Class
{
    public class CommonService : ICommonService
    {
        private IUnitOfWork _unitOfWork;
        public CommonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Dictionary<int, string> GetAllCities()
        {
            return _unitOfWork.CityRepository.GetAll().Select(t => new { t.Id, t.city_name }).ToDictionary(t => t.Id, t => t.city_name);
        }

        public Dictionary<string, string> GetAllCountries()
        {
            return _unitOfWork.CountryRepository.GetAll().Select(t => new { t.citycode, t.printable_name }).ToDictionary(t => t.citycode, t => t.printable_name);
        }

        public Dictionary<string, string> GetAllStates()
        {
            return _unitOfWork.StateRepository.GetAll().Select(t => new { t.state_code, t.name }).ToDictionary(t => t.state_code, t => t.name);
        }

        public Dictionary<int, string> GetCityByState(string StateID)
        {
            return _unitOfWork.CityRepository.GetAll().Where(e=>e.state_code == StateID).Select(t => new { t.Id, t.city_name }).ToDictionary(t => t.Id, t => t.city_name);
        }

        public Dictionary<string, string> GetStateByCountry(string CountryId)
        {
            throw new NotImplementedException();
        }
    }
}
