using DevAlternatives.Data;
using DevAlternatives.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAlternatives.Repository.UnitOfWork
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private IRepository<Login> _loginRepository;
        private IRepository<Customer> _customerRepository;
        private IRepository<Company> _companyRepository;
        private IRepository<Country> _countryRepository;
        private IRepository<State> _stateRepository;
        private IRepository<City> _cityRepository;
        private IRepository<Employee> _employeeRepository;
        private DevAlternativesEntities _context;
        public IRepository<Login> LoginRepository
        {
            get
            {

                if (_loginRepository == null)
                    _loginRepository = new Repository<Login>(_context);
                return _loginRepository;
            }
        }

        public IRepository<Customer> CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new Repository<Customer>(_context);
                return _customerRepository;
            }
        }

        public IRepository<Company> CompanyRepository
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new Repository<Company>(_context);
                return _companyRepository;
            }
        }

        public IRepository<Country> CountryRepository
        {
            get
            {
                if (_countryRepository == null)
                    _countryRepository = new Repository<Country>(_context);
                return _countryRepository;
            }
        }

        public IRepository<State> StateRepository
        {
            get
            {
                if (_stateRepository == null)
                    _stateRepository = new Repository<State>(_context);
                return _stateRepository;
            }
        }

        public IRepository<City> CityRepository
        {
            get
            {
                if (_cityRepository == null)
                    _cityRepository = new Repository<City>(_context);
                return _cityRepository;
            }
        }

        public IRepository<Employee> EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new Repository<Employee>(_context);
                return _employeeRepository;
            }
        }

        public UnitOfWork()
        {
            _context = new DevAlternativesEntities();
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
