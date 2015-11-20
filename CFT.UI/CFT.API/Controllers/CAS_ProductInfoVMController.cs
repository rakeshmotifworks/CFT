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

namespace CFT.API.Controllers
{
    public class CAS_ProductInfoVMController : ApiController
    {
        private CFT_DBEntities db = new CFT_DBEntities();

        // GET: api/CAS_ProductInfoVM
        public IQueryable<CAS_ProductInfoVM> GetCAS_ProductInfoVM()
        {
            return db.CAS_ProductInfoVM;
        }

        // GET: api/CAS_ProductInfoVM/5
        [ResponseType(typeof(CAS_ProductInfoVM))]
        public IHttpActionResult GetCAS_ProductInfoVM(int id)
        {
            CAS_ProductInfoVM cAS_ProductInfoVM = db.CAS_ProductInfoVM.Find(id);
            if (cAS_ProductInfoVM == null)
            {
                return NotFound();
            }

            return Ok(cAS_ProductInfoVM);
        }

        // PUT: api/CAS_ProductInfoVM/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCAS_ProductInfoVM(int id, CAS_ProductInfoVM cAS_ProductInfoVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cAS_ProductInfoVM.Id)
            {
                return BadRequest();
            }

            db.Entry(cAS_ProductInfoVM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAS_ProductInfoVMExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CAS_ProductInfoVM
        [ResponseType(typeof(CAS_ProductInfoVM))]
        public IHttpActionResult PostCAS_ProductInfoVM(CAS_ProductInfoVM cAS_ProductInfoVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CAS_ProductInfo productInfo = new CAS_ProductInfo();

            db.CAS_ProductInfo.Add(productInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cAS_ProductInfoVM.Id }, cAS_ProductInfoVM);
        }

        // DELETE: api/CAS_ProductInfoVM/5
        [ResponseType(typeof(CAS_ProductInfoVM))]
        public IHttpActionResult DeleteCAS_ProductInfoVM(int id)
        {
            CAS_ProductInfoVM cAS_ProductInfoVM = db.CAS_ProductInfoVM.Find(id);
            if (cAS_ProductInfoVM == null)
            {
                return NotFound();
            }

            db.CAS_ProductInfoVM.Remove(cAS_ProductInfoVM);
            db.SaveChanges();

            return Ok(cAS_ProductInfoVM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CAS_ProductInfoVMExists(int id)
        {
            return db.CAS_ProductInfoVM.Count(e => e.Id == id) > 0;
        }
    }
}