using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.DTO
{
    public class EmployeeQuery
    {
        public string Name
        {
            get;set;
        }
        public string Emp_No
        {
            get;
            set;
        }

        public DateTime?[] Birth_Date_Range
        {
            get;
            set;
        }

        public DateTime?[] Hire_Date_Range
        {
            get; set;
        }

        public string Gender
        {
            get;set;
        }

    }
}
