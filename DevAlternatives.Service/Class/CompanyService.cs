using DevAlternatives.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevAlternatives.Data;
using DevAlternatives.Repository.UnitOfWork;
using DevAlternatives.Models.Company;

namespace DevAlternatives.Service.Class
{
    public class CompanyService : ICompanyService
    {
        private IUnitOfWork _unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<CompanyNames> CompanyDropDownList()
        {
            List<CompanyNames> names = new List<CompanyNames>();
            foreach (var item in _unitOfWork.CompanyRepository.GetAll().ToList())
            {
                CompanyNames obj = new CompanyNames();
                obj.CompanyName = item.CompanyName;
                obj.Id = item.CompanyID;
                names.Add(obj);
            }
            return names;
        }
    }
}
