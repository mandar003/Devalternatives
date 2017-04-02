using DevAlternatives.Models.Company;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DevAlternatives.Models.Employee
{
    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }
        public Nullable<int> ManagerID { get; set; }

        [Display(Name = "Company")]
        [Required(ErrorMessage = "Please select comapny")]
        public int CompanyID { get; set; }

        [Display(Name = "Company")]
        public IEnumerable<CompanyNames> Companies { get; set; }

        [Required(ErrorMessage = "Please enter first Name")]
        [StringLength(30, ErrorMessage = "First Name cannot be longer than 30 characters.")]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [StringLength(1, ErrorMessage = "Middle Name cannot be longer than 1 characters.")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(30, ErrorMessage = "Address1 cannot be longer than 30 characters.")]
        [Display(Name = "Address 1")]
        public string FisicalAddress1 { get; set; }

        [StringLength(30, ErrorMessage = "Address2 cannot be longer than 30 characters.")]
        [Display(Name = "Address 2")]
        public string FisicalAddress2 { get; set; }

        [Display(Name = "City")]
        public Dictionary<int, string> FisicalCity { get; set; }
        [Display(Name = "City")]
        public string FisicalCitySelected { get; set; }

        [StringLength(15, ErrorMessage = "Zip Code cannot be longer than 15 characters.")]
        [Display(Name = "Zip")]
        public string FisicalZip { get; set; }

        [Display(Name = "State")]
        public Dictionary<string, string> FisicalState { get; set; }
        [StringLength(30, ErrorMessage = "Address1 cannot be longer than 30 characters.")]
        [Display(Name = "State")]
        public string FisicalStateSelected { get; set; }

        [Display(Name = "Address 1")]
        public string PostalAddress1 { get; set; }
        [StringLength(30, ErrorMessage = "Address2 cannot be longer than 30 characters.")]
        [Display(Name = "Address 2")]
        public string PostalAddress2 { get; set; }

        [Display(Name = "City")]
        public Dictionary<int, string> PostalCity { get; set; }
        [Display(Name = "City")]
        public string PostalCitySelected { get; set; }

        [StringLength(15, ErrorMessage = "Zip Code cannot be longer than 15 characters.")]
        [Display(Name = "Zip")]
        public string PostalZip { get; set; }

        [Display(Name = "State")]
        public Dictionary<string, string> PostalState { get; set; }
        [Display(Name = "State")]
        public string PostalStateSelected { get; set; }

        [StringLength(10, ErrorMessage = "Home Phone cannot be longer than 10 characters.")]
        [Display(Name = "Home")]
        [RegularExpression(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Home Phone must be numeric and 9 digit long")]
        public string HomePhone { get; set; }

        [StringLength(10, ErrorMessage = "Extension cannot be longer than 10 characters.")]
        [Display(Name = "Extension")]
        public string Extension { get; set; }


        [StringLength(10, ErrorMessage = "Mobile cannot be longer than 10 characters.")]
        [Display(Name = "Mobile")]
        
        [RegularExpression(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Mobile must be numeric and 9 digit long")]
        public string MobilePhone { get; set; }

        [StringLength(10, ErrorMessage = "Work Phone cannot be longer than 10 characters.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Work Phone must be numeric")]
        [Display(Name = "Work")]
        public string WorkPhone { get; set; }

        [Display(Name = "StartDate Date")]
        public Nullable<System.DateTime> StartDate { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }

        [Display(Name = "TerminationDate Date")]
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public EmployeeNewLogin loginDetails { get; set; }


    }


    public class EmployeeLogin
    {
        [StringLength(50, ErrorMessage = "User Name cannot be longer than 50 characters.")]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "password cannot be longer than 50 characters.")]
        [Display(Name = "password")]
        public string Password { get; set; }
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password values must be same")]
        public string ComfirmPassword { get; set; }
        [StringLength(50, ErrorMessage = "Email Name cannot be longer than 50 characters.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Please enter a valid email address or phone number")]
        [Display(Name = "Email")]
        public virtual string Email { get; set; }

    }


    public class EmployeeNewLogin : EmployeeLogin
    {
        [Required]
        [Remote("CheckForValidEmployeeEmail", "Employee", ErrorMessage = "Employee Email is alreadyin use available")]
        [StringLength(50, ErrorMessage = "Email Name cannot be longer than 50 characters.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|", ErrorMessage = "Please enter a valid email address or phone number")]
        [Display(Name = "Email")]
        public override string Email { get; set; }
    }




}
