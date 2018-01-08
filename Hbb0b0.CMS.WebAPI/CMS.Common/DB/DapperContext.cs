using CMS.Common.Config;
using CMS.Common.DB;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Common
{
    public  class DapperContext: IDapperContext
    {
        private WebApiOption m_Config;
        public string GetConnectionString()
        {
            return m_Config.DB.ConnectionString;
        }
        public  DapperContext(WebApiOption config )
        {
            m_Config = config;
           
        }

       
    }
}
