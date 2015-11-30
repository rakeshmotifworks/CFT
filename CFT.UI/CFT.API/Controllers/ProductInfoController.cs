using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CFT.Repo;
using CFT.Repo.Model;
using CFT.Repo.BAL;

namespace CFT.API.Controllers
{
    public class ProductInfoController : ApiController
    {
        private CFT_DBEntities db = new CFT_DBEntities();
        private ProductInfoBAL _createProductInfo;

        // GET: api/ProductInfo
        //public IQueryable<CAS_ProductInfoVM> GetCAS_ProductInfoVM()
        //{
        //    return new IQueryable<CAS_ProductInfoVM>();
        //}

        // GET: api/ProductInfo/5
        [ResponseType(typeof(CAS_ProductInfoVM))]
        //public IHttpActionResult GetCAS_ProductInfoVM(int id)
        //{
        //    CAS_ProductInfoVM cAS_ProductInfoVM = CAS_ProductInfoVM.Find(id);
        //    if (cAS_ProductInfoVM == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(cAS_ProductInfoVM);
        //}

        // PUT: api/ProductInfo/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCAS_ProductInfoVM(int id, CAS_ProductInfoVM cAS_ProductInfoVM)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != cAS_ProductInfoVM.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(cAS_ProductInfoVM).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CAS_ProductInfoVMExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/ProductInfo
        [ResponseType(typeof(CAS_ProductInfoVM))]
        public IHttpActionResult PostCAS_ProductInfoVM(CAS_ProductInfoVM cAS_ProductInfoVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _createProductInfo = new ProductInfoBAL();
                _createProductInfo.CreateProductData(cAS_ProductInfoVM);

                return Ok("Product Information Created ref id - " + cAS_ProductInfoVM.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
            return CreatedAtRoute("DefaultApi", new { id = cAS_ProductInfoVM.Id }, cAS_ProductInfoVM);
        }

        // DELETE: api/ProductInfo/5
       // [ResponseType(typeof(CAS_ProductInfoVM))]
        //public IHttpActionResult DeleteCAS_ProductInfoVM(int id)
        //{
        //    CAS_ProductInfoVM cAS_ProductInfoVM = db.CAS_ProductInfoVM.Find(id);
        //    if (cAS_ProductInfoVM == null)
        //    {
        //        return NotFound();
        //    }

        //    db.CAS_ProductInfoVM.Remove(cAS_ProductInfoVM);
        //    db.SaveChanges();

        //    return Ok(cAS_ProductInfoVM);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool CAS_ProductInfoVMExists(int id)
        //{
        //    return db.CAS_ProductInfoVM.Count(e => e.Id == id) > 0;
        //}
    }
}