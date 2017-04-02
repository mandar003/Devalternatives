using DevAlternatives.Models.Common;
using DevAlternatives.Models.Company;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DevAlternatives.Models.Customer
{
    public class CustomerDetails
    {
        public int CustomerID { get; set; }
        [Display(Name = "Company")]
        [Required(ErrorMessage ="Please select comapny")]
        public int CompanyID { get; set; }

        [Display(Name ="Company")]
        public IEnumerable<CompanyNames> Companies { get; set; }

        [Required(ErrorMessage = "Please enter first Name")]
        [StringLength(10, ErrorMessage = "First Name cannot be longer than 10 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(10, ErrorMessage = "Middle Name cannot be longer than 10 characters.")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [StringLength(10, ErrorMessage = "Last Name cannot be longer than 10 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(30, ErrorMessage = "Address1 cannot be longer than 30 characters.")]
        [Display(Name = "Address 1")]
        public string FisicalAddress1 { get; set; }

        [StringLength(30, ErrorMessage = "Address2 cannot be longer than 30 characters.")]
        [Display(Name = "Address 2")]
        public string FisicalAddress2 { get; set; }

        [Display(Name = "City")]
        public Dictionary<int,string> FisicalCity { get; set; }
        [Display(Name = "City")]
        public string FisicalCitySelected { get; set; }

        [StringLength(15, ErrorMessage = "Zip Code cannot be longer than 15 characters.")]
        [Display(Name = "Zip")]
        public string FisicalZip { get; set; }

        [Display(Name = "State")]
        public Dictionary<string,string> FisicalState { get; set; }
        [StringLength(30, ErrorMessage = "Address1 cannot be longer than 30 characters.")]
        [Display(Name = "State")]
        public string FisicalStateSelected { get; set; }

        [Display(Name = "Address 1")]
        public string PostalAddress1 { get; set; }
        [StringLength(30, ErrorMessage = "Address2 cannot be longer than 30 characters.")]
        [Display(Name = "Address 2")]
        public string PostalAddress2 { get; set; }

        [Display(Name = "City")]
        public Dictionary<int,string>  PostalCity { get; set; }
        [Display(Name = "City")]
        public string PostalCitySelected { get; set; }

        [StringLength(15, ErrorMessage = "Zip Code cannot be longer than 15 characters.")]
        [Display(Name = "Zip")]
        public string PostalZip { get; set; }

        [Display(Name = "State")]
        public Dictionary<string,string> PostalState { get; set; }
        [Display(Name = "State")]
        public string PostalStateSelected { get; set; }        

        [StringLength(15, ErrorMessage = "Home Phone cannot be longer than 15 characters.")]
        [Display(Name = "Home")]        
        [RegularExpression(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Home Phone must be numeric and 9 digit long")]
        
        public string HomePhone { get; set; }

        [Remote("CheckForValidCustomerPhone", "Customer", ErrorMessage = "Customer Phone is not available")]
        [StringLength(15, ErrorMessage = "Mobile cannot be longer than 15 characters.")]
        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "Please enter Mobile Number")]
        [RegularExpression(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Mobile must be numeric and 9 digit long")]
        public string MobilePhone { get; set; }

        [StringLength(15, ErrorMessage = "Work Phone cannot be longer than 15 characters.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Work Phone must be numeric")]
        [Display(Name = "Work")]
        public string WorkPhone { get; set; }

        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CustomerStartDate { get; set; }

        [Display(Name = "IsActive")]
        public bool CustomerActive { get; set; }

        [Display(Name = "Last Visited Date")]
        public Nullable<System.DateTime> CustomerLastVisitDate { get; set; }

        public NewLogin loginDetails { get; set; }
    }

    
}
