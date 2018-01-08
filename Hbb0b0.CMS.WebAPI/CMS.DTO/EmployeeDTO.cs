using CMS.Common;
using System;

namespace CMS.DTO
{
    public class EmployeeDTO: DTOBase
    {
        public string Emp_No
        {
            get;
            set;
        }

        public DateTime Birth_Date
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
            get; set;
        }

        public String Gender
        {
            get;
            set;
        }

        public string Name
        {
            get
            {
                return string.Format($"{First_Name?.ToString()}  {Last_Name?.ToString()}");
            }
        }

        public string Hire_Date_Display
        {
            get
            {
               return  Hire_Date.ToLongDateString();
            }
        }

        public string Birth_Date_Display
        {
            get
            {
                return Birth_Date.ToLongDateString();
            }
        }

    }
}
