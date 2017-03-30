using DevAlternatives.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAlternatives.Service.Interface
{
    public interface IUserService
    {
        bool ValidateUser(Login login);
       
    }
}
