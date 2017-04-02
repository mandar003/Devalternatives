using DevAlternatives.Data;
using DevAlternatives.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAlternatives.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Login> LoginRepository { get; }
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Company> CompanyRepository { get; }
        IRepository<Country> CountryRepository { get; }
        IRepository<State> StateRepository { get; }
        IRepository<City> CityRepository { get; }
        IRepository<Employee> EmployeeRepository { get; }
        void Save();
    }
}
