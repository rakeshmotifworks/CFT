using CFT.Repo.BAL;
using CFT.Repo.Model;
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
        private ProductInfoBAL _productInfoBAL;
        // GET: ProductInfo
        public ActionResult Index()
        {
            _productInfoBAL = new ProductInfoBAL();
            _cAS_ProductInfoVMList = new List<CAS_ProductInfoVM>();
            try
            {
                _cAS_ProductInfoVMList = _productInfoBAL.GetAllProductData();
            }
            catch (Exception ex)
            {
              
            }

            return View(_cAS_ProductInfoVMList);
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
