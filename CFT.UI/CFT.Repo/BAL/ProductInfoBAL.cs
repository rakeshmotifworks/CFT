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
    public class ProductInfoBAL : IProductInfoBAL
    {
        private CAS_ProductInfoVM _cAS_ProductInfoVM;
        private List<CAS_ProductInfoVM> _cAS_ProductInfoVMList;
        private CAS_FeedbackDataVM _cAS_FeedbackDataVM;
        private Collection<CAS_FeedbackDataVM> _cAS_FeedbackDataVMList;
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
                    productInfo.Customer_Email = model.Customer_Email;
                    productInfo.Customer_Phone = model.Customer_Phone;
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
                foreach (var data in model.CAS_FeedbackDataVM)
                {
                    feedBackList.Add(new CAS_FeedbackData()
                    {
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

        public List<CAS_ProductInfoVM> GetAllProductData(SearchVM search, out int totalcount)
        {
            _cAS_ProductInfoVMList = new List<CAS_ProductInfoVM>();
            _db = new CFT_DBEntities();
            IEnumerable<CAS_ProductInfo> query = _db.CAS_ProductInfo.Include("CAS_FeedbackData").ToList();
            totalcount = query.Count();
            search.PageCurrentIndex = search.PageCurrentIndex <= 0 ? 0 : search.PageCurrentIndex;

            query = query.Skip(search.PageCurrentIndex * search.PageSize).Take(search.PageSize);
            search.PageCount =
                Convert.ToInt32(Math.Ceiling((double)((double)(totalcount / (double)search.PageSize))));

            var lists = query.Select((a => new CAS_ProductInfoVM()
            {
                Business_Unit = a.Business_Unit,
                CAS_ProductId = a.CAS_ProductId,
                CAS_FeedbackDataVM = ConvertToFeedBackDataVM(a),
                Customer_Email = a.Customer_Email,
                Customer_Name = a.Customer_Name,
                Customer_Phone = a.Customer_Phone,
                Function = a.Function,
                Id = a.Id,
                IEC_Contact = a.IEC_Contact,
                Project_Name = a.Project_Name,
                Project_Team = a.Project_Team,
                CreatedAt = a.CreatedAt,
                CreatedBy = a.CreatedBy,
                UpdateAt = a.UpdateAt,
                UpdateBy = a.UpdateBy,
                IsActive = a.IsActive,
                ISDeleted = a.ISDeleted
            }));

            List<CAS_ProductInfoVM> listitems = lists.ToList();
            return listitems;
        }

        public CAS_ProductInfoVM GetProductDataById(string id)
        {
            _cAS_ProductInfoVM = new CAS_ProductInfoVM();
            try
            {
                using (_db = new CFT_DBEntities())
                {
                    var getData = (from prod in _db.CAS_ProductInfo.Include("CAS_FeedbackData")
                                          where prod.CAS_ProductId == id
                                          select prod).FirstOrDefault();


                    _cAS_ProductInfoVM.Business_Unit = getData.Business_Unit;
                    _cAS_ProductInfoVM.CAS_FeedbackData = getData.CAS_FeedbackData;
                    _cAS_ProductInfoVM.CAS_ProductId = getData.CAS_ProductId;
                    _cAS_ProductInfoVM.CreatedAt = getData.CreatedAt;
                    _cAS_ProductInfoVM.CreatedBy = getData.CreatedBy;
                    _cAS_ProductInfoVM.Customer_Email = getData.Customer_Email;
                    _cAS_ProductInfoVM.Customer_Name = getData.Customer_Name;
                    _cAS_ProductInfoVM.Customer_Phone = getData.Customer_Phone;
                    _cAS_ProductInfoVM.Function = getData.Function;
                    _cAS_ProductInfoVM.Id = getData.Id;
                    _cAS_ProductInfoVM.IEC_Contact = getData.IEC_Contact;
                    _cAS_ProductInfoVM.IsActive = getData.IsActive;
                    _cAS_ProductInfoVM.ISDeleted = getData.ISDeleted;
                    _cAS_ProductInfoVM.Project_Name = getData.Project_Name;
                    _cAS_ProductInfoVM.Project_Team = getData.Project_Team;
                    _cAS_ProductInfoVM.UpdateAt = getData.UpdateAt;
                    _cAS_ProductInfoVM.UpdateBy = getData.UpdateBy;
                    _cAS_ProductInfoVM.CAS_FeedbackDataVM = ConvertToFeedBackDataVM(getData);
                                         
                }
            }
            catch (Exception ex)
            {
                return _cAS_ProductInfoVM;
            }
            return _cAS_ProductInfoVM;
        }

        public Collection<CAS_FeedbackDataVM> ConvertToFeedBackDataVM(CAS_ProductInfo model)
        {
            _cAS_FeedbackDataVMList = new Collection<CAS_FeedbackDataVM>();
            _cAS_FeedbackDataVM = new CAS_FeedbackDataVM();
            try
            {
                foreach (var item in model.CAS_FeedbackData)
                {
                    _cAS_FeedbackDataVM.Additional_Comments_Issues_Concerns_Suggestions = item.Additional_Comments_Issues_Concerns_Suggestions;
                    _cAS_FeedbackDataVM.Adherence_To_Schedule = item.Adherence_To_Schedule;
                    _cAS_FeedbackDataVM.Alternate_Solutions_Value_addition = item.Alternate_Solutions_Value_addition;
                    _cAS_FeedbackDataVM.CAS_ProdInfo_FK = item.CAS_ProdInfo_FK;
                    _cAS_FeedbackDataVM.CAS_ProductInfo = item.CAS_ProductInfo;
                    _cAS_FeedbackDataVM.CreatedAt = item.CreatedAt;
                    _cAS_FeedbackDataVM.CreatedBy = item.CreatedBy;
                    _cAS_FeedbackDataVM.Effectiveness_of_Communication = item.Effectiveness_of_Communication;
                    _cAS_FeedbackDataVM.Id = item.Id;
                    _cAS_FeedbackDataVM.Independent_project_execution_Customers_Efforts = item.Independent_project_execution_Customers_Efforts;
                    _cAS_FeedbackDataVM.IsActive = item.IsActive;
                    _cAS_FeedbackDataVM.IsDeleted = item.IsDeleted;
                    _cAS_FeedbackDataVM.Overall_Satisfaction = item.Overall_Satisfaction;
                    _cAS_FeedbackDataVM.Quality = item.Quality;
                    _cAS_FeedbackDataVM.Status = item.Status;
                    _cAS_FeedbackDataVM.UpdatedAt = item.UpdatedAt;
                    _cAS_FeedbackDataVM.UpdatedBy = item.UpdatedBy;

                    _cAS_FeedbackDataVMList.Add(_cAS_FeedbackDataVM);
                }
            }
            catch (Exception ex)
            {
                return _cAS_FeedbackDataVMList;
            }
            return _cAS_FeedbackDataVMList;
        }


        public void UpdateProductInfoAfterMailSent(string id)
        {
            try
            {
                using (_db = new CFT_DBEntities())
                {
                    var getData = _db.CAS_ProductInfo
                        .Include("CAS_FeedbackData").Where(p => p.CAS_ProductId == id).FirstOrDefault();

                    foreach (var item in getData.CAS_FeedbackData)
                    {
                        item.Status = "MailSent";
                        item.UpdatedAt = DateTime.UtcNow;
                        item.UpdatedBy = "RC";

                        _db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
              
            }
        }
    }
}
