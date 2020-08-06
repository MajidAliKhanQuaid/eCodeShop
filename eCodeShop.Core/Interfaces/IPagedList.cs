using System;
using System.Collections.Generic;
using System.Text;

namespace eCodeShop.Core.Interfaces
{
    interface IPagedList<T>
    {
        public int PageSize { get; set; }
        public int PageNo { get; set; }
        public List<T> Elements { get; set; }
    }
}
