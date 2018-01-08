using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.DTO
{
    public  class QueryCondition<T>
    {
        

        public PageInfo pageInfo
        {
            get;
            set;
        }
        public T Param
        {
            get;
            set;
        }

        public  string GetLikeValue(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                return string.Format("%{0}%", str.Replace("%", "\\%"));
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public class PageInfo
    {
        public int PageSize
        {
            get;
            set;
        }

        public int PageIndex
        {
            get;
            set;
        }
    }
}
