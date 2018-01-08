using CMS.Common;
using CMS.Common.Message;
using CMS.DTO;
using CMS.Entity;
using CMS.Model;
using System;
using System.Collections.Generic;

namespace CMS.IService
{
    public interface IEmployeeService
    {

        ReponseMessage<PagedList<EmployeeDTO>> GetPagedList(int pageNumber, int rowsPerPage);

        ReponseMessage<PagedList<EmployeeDTO>> Query(QueryCondition<EmployeeQuery> condition);
    }
}
