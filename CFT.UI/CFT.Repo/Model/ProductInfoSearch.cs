using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT.Repo.Model
{
    public class ProductInfoSearch
    {
        public List<CAS_ProductInfoVM> CAS_ProductInfoVM { get; set; }
        public List<CAS_FeedbackDataVM> CAS_FeedbackDataVM { get; set; }
        public SearchVM SearchExpression { get; set; }
        public int TotalCount { get; set; }
    }
}
