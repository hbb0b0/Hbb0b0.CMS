using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Common.Config
{
    public class WebApiOption
    {
        public const string CORS_POLICY_NAME = "CMSCorsConfig";
       public DBOption DB
        {
            get;set;
        }

        public CorsOption Cors
        {
            get;set;
        }

       

    }
}
