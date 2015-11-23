using CFT.Repo.IBAL;
using CFT.Repo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT.Repo.BAL
{
    public class CreateProductInfo : ICreateProductInfo
    {
        private CAS_ProductInfoVM _cAS_ProductInfoVM;
        private CAS_FeedbackDataVM _cAS_FeedbackDataVM;
        private CFT_DBEntities _db;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CAS_ProductInfoVM CreateProductData(CAS_ProductInfoVM model)
        {
            try
            {
                using (_db = new CFT_DBEntities())
                {
                    _cAS_ProductInfoVM = new CAS_ProductInfoVM();
                    CAS_ProductInfo productInfo = new CAS_ProductInfo();

                    productInfo.CAS_ProductId = model.CAS_ProductId;
                    productInfo.Business_Unit = model.Business_Unit;
                    productInfo.Project_Name = model.Project_Name;
                    productInfo.Customer_Name = model.Customer_Name;
                    productInfo.Customer_Email = model.Customer_Name;
                    productInfo.Customer_Phone = model.Customer_Name;
                    productInfo.IEC_Contact = model.IEC_Contact;
                    productInfo.Project_Team = model.Project_Team;
                    productInfo.Function = model.Function;
                    productInfo.CreatedAt = model.CreatedAt;
                    productInfo.CreatedBy = model.CreatedBy;
                    productInfo.UpdateAt = model.UpdateAt;
                    productInfo.UpdateBy = model.UpdateBy;
                    productInfo.IsActive = model.IsActive;
                    productInfo.ISDeleted = model.ISDeleted;

                    productInfo.CAS_FeedbackData = GetCAS_FeedbackData(model);

                    _db.CAS_ProductInfo.Add(productInfo);
                    _db.SaveChanges();

                    _cAS_ProductInfoVM.Id = productInfo.Id;
                    return _cAS_ProductInfoVM;
                }
            }
            catch (Exception ex)
            {
                return _cAS_ProductInfoVM;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Collection<CAS_FeedbackData> GetCAS_FeedbackData(CAS_ProductInfoVM model)
        {
            Collection<CAS_FeedbackData> feedBackList = new Collection<CAS_FeedbackData>();
            try
            {
                foreach (var data in model.CAS_FeedbackData)
                {
                    feedBackList.Add(new CAS_FeedbackData()
                    {
                        CAS_ProdInfo_FK = 0,
                        Quality = data.Quality,
                        Adherence_To_Schedule = data.Adherence_To_Schedule,
                        Alternate_Solutions_Value_addition = data.Alternate_Solutions_Value_addition,
                        Effectiveness_of_Communication = data.Effectiveness_of_Communication,
                        Independent_project_execution_Customers_Efforts = data.Independent_project_execution_Customers_Efforts,
                        Overall_Satisfaction = data.Overall_Satisfaction,
                        Additional_Comments_Issues_Concerns_Suggestions = data.Additional_Comments_Issues_Concerns_Suggestions,
                        Status = data.Status,
                        CreatedAt = data.CreatedAt,
                        CreatedBy = data.CreatedBy,
                        UpdatedAt = data.UpdatedAt,
                        UpdatedBy = data.UpdatedBy,
                        IsActive = true,
                        IsDeleted = false
                    });
                }
                return feedBackList;
            }
            catch (Exception ex)
            {
                return feedBackList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CAS_ProductInfoVM UpdateProductData(CAS_ProductInfoVM model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CAS_FeedbackDataVM UpdateFeedbackData(CAS_ProductInfoVM model)
        {
            throw new NotImplementedException();
        }


    }
}
