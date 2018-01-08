using CMS.Common.Config;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.WebApi.Common
{
    [Route("api/[controller]")]
    [EnableCors(WebApiOption.CORS_POLICY_NAME)]
    public abstract class BaseController: Controller
    {
        protected readonly ILogger m_Logger;

        public BaseController(ILogger<BaseController> logger)
        {
            m_Logger = logger;
        }
    }
}
