using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT.Repo.Model
{
    public class SearchVM
    {
        public SearchVM()
        {
            Expert = true;
            IsSortAsc = true;
            PageSize = 5;
            PageCurrentIndex = 0;
        }
        public string SortName { get; set; }
        public bool IsSortAsc { get; set; }
        public string Keyword { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int PageCurrentIndex { get; set; }
        public bool Expert { get; set; }
    }
}
