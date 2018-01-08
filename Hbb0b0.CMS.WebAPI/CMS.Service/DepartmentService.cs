using CMS.Common;
using CMS.Common.Message;
using CMS.Entity;
using CMS.IRepository;
using CMS.IService;
using System;
using System.Collections.Generic;

namespace CMS.Service
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRep m_DepartmentRep;
        public DepartmentService(IDepartmentRep departmentRep)
        {
            m_DepartmentRep = departmentRep;
        }

        public ReponseMessage<DepartmentModel> GetByID(string id)
        {
            ReponseMessage<DepartmentModel> result = new ReponseMessage<DepartmentModel>();

            result.Data = m_DepartmentRep.Get(id);
            result.IsSuccess = true;
           
            return result;
        }

        public ReponseMessage<List<DepartmentModel>> GetList()
        {
            ReponseMessage<List<DepartmentModel>> result = new ReponseMessage<List<DepartmentModel>>
            {
                Data = m_DepartmentRep.GetList(),
                IsSuccess = true
            };

            return result;
        }

        public ReponseMessage<PagedList<DepartmentModel>> GetPagedList(int pageNumber, int rowsPerPage)
        {
            int total = 0;
            ReponseMessage<PagedList<DepartmentModel>> result = new ReponseMessage<PagedList<DepartmentModel>>();

            result.Data = m_DepartmentRep.GetPagedList(pageNumber, rowsPerPage,null,null,out total);

            result.IsSuccess = true;

            return result;
        }
    }
}
