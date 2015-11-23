using CFT.Repo.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CFT.UI.Controllers
{
    public class HomeController : Controller
    {
        private CAS_ProductInfoVM _cAS_ProductInfoVM;
        public ActionResult Index()
        {
           // CreateWepApi();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void CreateWepApi()
        {
            try
            {
                _cAS_ProductInfoVM = new CAS_ProductInfoVM();

                _cAS_ProductInfoVM.CAS_ProductId = "Prod_ref12";
                _cAS_ProductInfoVM.Business_Unit = "Axis";
                _cAS_ProductInfoVM.Project_Name = "DT_Proj";
                _cAS_ProductInfoVM.Customer_Name = "Rakesh";
                _cAS_ProductInfoVM.Customer_Email = "rakesh@motifworks.com";
                _cAS_ProductInfoVM.Customer_Phone = "9663642655";
                _cAS_ProductInfoVM.IEC_Contact = "Someone";
                _cAS_ProductInfoVM.Project_Team = "Project";
                _cAS_ProductInfoVM.Function = "Proj_Func";
                _cAS_ProductInfoVM.CreatedAt = DateTime.Now;
                _cAS_ProductInfoVM.CreatedBy = "RC";
                _cAS_ProductInfoVM.UpdateAt = DateTime.Now;
                _cAS_ProductInfoVM.UpdateBy = "RC";
                _cAS_ProductInfoVM.IsActive = true;
                _cAS_ProductInfoVM.ISDeleted = false;
                _cAS_ProductInfoVM.CAS_FeedbackData = GetFeedbackData();

                var client = new HttpClient();
                client.BaseAddress = new Uri("http://dcprc-test1.cloudapp.net/lal_api/");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var cftData = _cAS_ProductInfoVM;
                var content = new System.Net.Http.StringContent(JsonConvert.SerializeObject(cftData), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("api/studies", content).Result;
                if (response.IsSuccessStatusCode)
                {
                  
                }
                else
                {
                    JObject root = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                }

            }
            catch (Exception ex)
            {

            }
        }

        Collection<CAS_FeedbackDataVM> GetFeedbackData()
        {
            Collection<CAS_FeedbackDataVM> feedbackList = new Collection<CAS_FeedbackDataVM>();
            
            try
            {
                feedbackList.Add(new CAS_FeedbackDataVM()
                {
                    CAS_ProdInfo_FK = 0,
                    Quality = "0",
                    Adherence_To_Schedule = "0",
                    Alternate_Solutions_Value_addition = "0",
                    Effectiveness_of_Communication = "0",
                    Independent_project_execution_Customers_Efforts = "0",
                    Overall_Satisfaction = "0",
                    Additional_Comments_Issues_Concerns_Suggestions = "Comments",
                    Status = "Pending",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "RC",
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = "RC",
                    IsActive = true,
                    IsDeleted = false
                });

                return feedbackList;
            }
            catch (Exception ex)
            {
                return feedbackList;
            }
        }

    }
}