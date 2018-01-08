using CMS.Common;
using CMS.Common.DB;
using CMS.DTO;
using CMS.Entity;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.IRepository
{
    public interface IEmployeeRep: IRepository<EmployeeModel>
    {
        PagedList<EmployeeDTO> Query(QueryCondition<EmployeeQuery> query);
    }
}
