using DevAlternatives.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAlternatives.Service.Interface
{
    public interface ICustomerService
    {
        bool ValidateUser(Login login);
        int CreateCustomer(CustomerDetails details);
        bool CheckIfUserNameOrPhoneAvailable(string EmailORPhone);
    }
}
