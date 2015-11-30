using CFT.Repo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT.Repo.IBAL
{
    public interface IProductInfoBAL
    {
        CAS_ProductInfoVM CreateProductData(CAS_ProductInfoVM model);
        Collection<CAS_FeedbackData> GetCAS_FeedbackData(CAS_ProductInfoVM model);
        CAS_ProductInfoVM UpdateProductData(CAS_ProductInfoVM model);
        CAS_FeedbackDataVM UpdateFeedbackData(CAS_ProductInfoVM model);
        List<CAS_ProductInfoVM> GetAllProductData(SearchVM search, out int totalcount);
        CAS_ProductInfoVM GetProductDataById(string id);
        void UpdateProductInfoAfterMailSent(string id);
    }
}
