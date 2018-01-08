using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Common;
using CMS.Common.Config;
using CMS.Common.Message;
using CMS.DTO;
using CMS.Entity;
using CMS.IService;
using CMS.WebApi.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CMS.WebApi.Controllers
{


    public class EmployeeController : BaseController
    {

        private DBOption m_CmsOptions;
        private IEmployeeService m_Service;

        public EmployeeController(IOptions<DBOption> option, IEmployeeService employeeService, ILogger<EmployeeController> logger) : base(logger)
        {
            this.m_CmsOptions = option.Value;
            m_Service = employeeService;
        }


        [Route("[action]/{pageNumber}/{rowsPerPage}")]
        [HttpGet]
        public ReponseMessage<PagedList<EmployeeDTO>> GetPagedList(int pageNumber, int rowsPerPage)
        {
            var result = m_Service.GetPagedList(pageNumber, rowsPerPage);

            return m_Service.GetPagedList(pageNumber, rowsPerPage);
        }

        [Route("[action]")]
        [HttpPost]
        public ReponseMessage<PagedList<EmployeeDTO>> Query([FromBody]QueryCondition<EmployeeQuery> condition)
        {
            var result = m_Service.Query(condition);
            m_Logger.LogInformation("GetPagedList:{0}", JsonConvert.SerializeObject(result));
            return result;
        }
    }


}
