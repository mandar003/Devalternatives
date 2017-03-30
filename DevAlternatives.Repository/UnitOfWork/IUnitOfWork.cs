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
        void Save();
    }
}
