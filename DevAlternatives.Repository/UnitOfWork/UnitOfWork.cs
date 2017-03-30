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
