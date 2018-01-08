using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Common.Message
{
    public class ReponseMessage<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }

        public MessageInfo Message
        {
            get; set;
        }
    }

        
}
