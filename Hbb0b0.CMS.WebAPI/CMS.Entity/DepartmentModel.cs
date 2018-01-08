using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Entity
{
    [Table("departments")]
    public class DepartmentModel
    {
        [Key]
        public string Dept_No
        {
            get;
            set;
        }

        public string Dept_Name
        {
            get;
            set;
        }
    }
}