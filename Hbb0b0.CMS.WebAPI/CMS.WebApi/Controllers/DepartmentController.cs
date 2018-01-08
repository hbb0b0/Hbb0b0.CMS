using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Common;
using CMS.Common.Config;
using CMS.Common.Message;
using CMS.Entity;
using CMS.IService;
using CMS.WebApi.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CMS.WebApi.Controllers
{
   
  
    public class DepartmentController : BaseController
    {

        private DBOption m_CmsOptions;
        private IDepartmentService m_DepartmentService;
        public DepartmentController(IOptions<DBOption> option, IDepartmentService departmentService,ILogger<EmployeeController> logger) : base(logger)
        {
            this.m_CmsOptions = option.Value;
            m_DepartmentService = departmentService;
        }

        //GET api/values
        
        [Route("[action]")]
        [HttpGet]
        public ReponseMessage<List<DepartmentModel>> GetList()
        {
            return m_DepartmentService.GetList();
        }

        [Route("[action]/{pageNumber}/{rowsPerPage}")]
        [HttpGet]
        public ReponseMessage<PagedList<DepartmentModel>> GetPagedList(int pageNumber, int rowsPerPage)
        {
            return m_DepartmentService.GetPagedList(pageNumber, rowsPerPage);
        }


        [Route("[action]")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { DateTime.Now.ToString() };
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ReponseMessage<DepartmentModel> Get(string id)
        {
            return m_DepartmentService.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
