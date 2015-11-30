using CFT.Repo.BAL;
using CFT.Repo.Model;
using CFT.UI.GenClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CFT.UI.Controllers
{
    public class ProductInfoController : Controller
    {
        private List<CAS_ProductInfoVM> _cAS_ProductInfoVMList;
        private CAS_ProductInfoVM _cAS_ProductInfoVM;
        private ProductInfoBAL _productInfoBAL;
        private SearchVM _searchVM;
        private ProductInfoSearch _productInfoSearch;
        // GET: ProductInfo
        public ActionResult Index(SearchVM obj)
        {
            _productInfoBAL = new ProductInfoBAL();
            _cAS_ProductInfoVMList = new List<CAS_ProductInfoVM>();
            _searchVM = new SearchVM();
            _productInfoSearch = new ProductInfoSearch();
            try
            {
                obj = obj ?? new SearchVM();
                SearchVM objjsearch = Session["searchvm"] != null ? Session["searchvm"] as SearchVM : obj;
                objjsearch.PageCurrentIndex = obj.PageCurrentIndex <= 0 ? 0 : obj.PageCurrentIndex;

                int totalcount;

                _cAS_ProductInfoVMList = _productInfoBAL.GetAllProductData(objjsearch, out totalcount);
                _productInfoSearch.TotalCount = totalcount;
                _productInfoSearch.SearchExpression = objjsearch;
                _productInfoSearch.CAS_ProductInfoVM = _cAS_ProductInfoVMList;
            }
            catch (Exception ex)
            {
              
            }

            return View(_productInfoSearch);
        }

        public ActionResult GetSelectedProductInfo(string id)
        {
            _productInfoBAL = new ProductInfoBAL();
            _cAS_ProductInfoVM = new CAS_ProductInfoVM();

            _cAS_ProductInfoVM = _productInfoBAL.GetProductDataById(id);

            return PartialView("_SelectedProductInfo", _cAS_ProductInfoVM);
        }

        public ActionResult SendFeedBackMail(string id)
        {

              _productInfoBAL = new ProductInfoBAL();
            _cAS_ProductInfoVM = new CAS_ProductInfoVM();

            _cAS_ProductInfoVM = _productInfoBAL.GetProductDataById(id);

            CommonClass common = new CommonClass();
            common.SendMail(_cAS_ProductInfoVM.Customer_Name, _cAS_ProductInfoVM.Project_Name);

            _productInfoBAL = new ProductInfoBAL();
            _productInfoBAL.UpdateProductInfoAfterMailSent(id);

            SearchVM obj = new SearchVM();

            return RedirectToAction("Index", obj);
        }

        // GET: ProductInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductInfo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
