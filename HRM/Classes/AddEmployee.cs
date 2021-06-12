using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Classes
{
    class AddEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nid { get; set; }
        public string FatherName { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Photo { get; set; }
        public int DeptId { get; set; }
        public int DesigId { get; set; }
        public string JoinDate { get; set; }
        public decimal JoinSalary { get; set; }
        public string BankAccName { get; set; }
        public string BankAccNumber { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
    enum EGender { 
        Male=1,
        Female
    }
    enum ECity { 
        Dhaka=1,
        Chittagong,
        Noakhali
    }
    enum ECountry { 
        Bangladesh=1,
        India,
        Pakistan
    }
}
