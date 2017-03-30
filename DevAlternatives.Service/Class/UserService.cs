using DevAlternatives.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevAlternatives.Repository.UnitOfWork;
using DevAlternatives.Models.User;

namespace DevAlternatives.Service.Class
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool ValidateUser(Login login)
        {
            if(_unitOfWork.LoginRepository.GetAll().Where(e=>e.UserName == login.EmailOrPhone && e.Password == login.Password).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
