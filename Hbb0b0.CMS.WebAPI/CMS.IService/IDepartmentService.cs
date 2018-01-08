using CMS.Common;
using CMS.Common.Message;
using CMS.Entity;
using System;
using System.Collections.Generic;

namespace CMS.IService
{
    public interface IDepartmentService
    {
        ReponseMessage<List<DepartmentModel>> GetList();

        ReponseMessage<DepartmentModel> GetByID(string id);

        ReponseMessage<PagedList<DepartmentModel>> GetPagedList(int pageNumber, int rowsPerPage);
    }
}
