using CMS.Common;
using CMS.Common.Message;
using CMS.DTO;
using CMS.Entity;
using CMS.IRepository;
using CMS.IService;
using CMS.Model;
using CMS.Utility;
using System;
using System.Collections.Generic;

namespace CMS.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRep m_Rep;

        public EmployeeService(IEmployeeRep rep)
        {
            m_Rep = rep;
        }
        public ReponseMessage<PagedList<EmployeeDTO>> GetPagedList(int pageNumber, int rowsPerPage)
        {
            int total = 0;
            ReponseMessage<PagedList<EmployeeDTO>> result = new ReponseMessage<PagedList<EmployeeDTO>>();
            result.Data = new PagedList<EmployeeDTO>();
            var modelResult= m_Rep.GetPagedList(pageNumber, rowsPerPage, null, null, out total);
            result.Data.TotalCount = total;
            result.Data.Items=modelResult.Items.JTransformTo<EmployeeDTO>();
            result.IsSuccess = true;

            return result;
        }
        public ReponseMessage<PagedList<EmployeeDTO>> Query(QueryCondition<EmployeeQuery> condition)
        {
            ReponseMessage<PagedList<EmployeeDTO>> result = new ReponseMessage<PagedList<EmployeeDTO>>();
            result.Data = new PagedList<EmployeeDTO>();
            var modelResult = m_Rep.Query(condition);
            result.Data.TotalCount = modelResult.TotalCount;
            if (modelResult.TotalCount > 0)
            {
                result.Data.Items = modelResult.TotalCount>0 ? modelResult.Items.JTransformTo<EmployeeDTO>():new List<EmployeeDTO>();
            }
            result.IsSuccess = true;

            return result;
        }
    }
}
