using DevAlternatives.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAlternatives.Service.Interface
{
   public interface IEmployeeService
    {
        bool ValidateUser(EmployeeLogin login);
        int CreateEmployee(EmployeeDetails details);
        bool CheckIfEmailAlreadyTaken(string Email);
    }
}
