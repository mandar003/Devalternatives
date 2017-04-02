using DevAlternatives.Data;
using DevAlternatives.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAlternatives.Service.Interface
{
    public interface ICompanyService
    {
        IEnumerable<CompanyNames> CompanyDropDownList();
    }
}
