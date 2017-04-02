using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DevAlternatives.Models.Customer
{
    public class Login
    {
        public int Id { get; set; }
        [Required]        
        [Display(Name = "Email or Phone")]
        /* /<email-pattern>|<phone-pattern>/ */
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Please enter a valid email address or phone number")]
        public virtual string EmailOrPhone { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage ="Password values must be same")]
        public string ComfirmPassword { get; set; }
    }


    public class NewLogin:Login
    {
        [Required]
        [Remote("CheckForValidCustomerName", "Customer", ErrorMessage = "Customer Name is not available")]
        [Display(Name = "Email or Phone")]
        /* /<email-pattern>|<phone-pattern>/ */
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Please enter a valid email address or phone number")]
        public override string EmailOrPhone { get; set; }      
    }
}
