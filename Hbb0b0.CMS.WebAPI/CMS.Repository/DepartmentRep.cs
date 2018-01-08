using CMS.Common.DB;
using CMS.Entity;
using CMS.IRepository;
using System;
using System.Collections.Generic;

namespace CMS.Repository
{
    public class DepartmentRep : ReponsitoryBase<DepartmentModel>, IDepartmentRep
    {

        public DepartmentRep(IDapperContext dapper):base(dapper)
        {

        }

    
       
    }
}
