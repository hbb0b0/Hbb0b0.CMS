using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Common
{
    public class PagedList<T> where T : class
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
