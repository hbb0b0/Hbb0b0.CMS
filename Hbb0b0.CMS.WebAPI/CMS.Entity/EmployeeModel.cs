using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Model
{
    [Table("employees")]
    public class EmployeeModel
    {
        [Key]
        public string Emp_No
        {
            get;
            set;
        }

        public string Birth_Date
        {
            get;
            set;
        }

        public string First_Name
        {
            get;
            set;
        }

        public string Last_Name
        {
            get;
            set;
        }

        public DateTime Hire_Date
        {
            get;set;
        }

        public String Gender
        {
            get;
            set;
        }




    }
}
