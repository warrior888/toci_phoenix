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
using TestingVsixOptions;

namespace TestingVsixOptions.Controllers
{
    public class ApplyFormsController : ApiController
    {
        private tociEntities1 db = new tociEntities1();

        // GET: api/ApplyForms
        public IQueryable<ApplyForm> GetApplyForms()
        {
            return db.ApplyForms;
        }

        // GET: api/ApplyForms/5
        [ResponseType(typeof(ApplyForm))]
        public IHttpActionResult GetApplyForm(int id)
        {
            ApplyForm applyForm = db.ApplyForms.Find(id);
            if (applyForm == null)
            {
                return NotFound();
            }

            return Ok(applyForm);
        }

        // PUT: api/ApplyForms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApplyForm(int id, ApplyForm applyForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applyForm.Id)
            {
                return BadRequest();
            }

            db.Entry(applyForm).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplyFormExists(id))
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

        // POST: api/ApplyForms
        [ResponseType(typeof(ApplyForm))]
        public IHttpActionResult PostApplyForm(ApplyForm applyForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApplyForms.Add(applyForm);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = applyForm.Id }, applyForm);
        }

        // DELETE: api/ApplyForms/5
        [ResponseType(typeof(ApplyForm))]
        public IHttpActionResult DeleteApplyForm(int id)
        {
            ApplyForm applyForm = db.ApplyForms.Find(id);
            if (applyForm == null)
            {
                return NotFound();
            }

            db.ApplyForms.Remove(applyForm);
            db.SaveChanges();

            return Ok(applyForm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplyFormExists(int id)
        {
            return db.ApplyForms.Count(e => e.Id == id) > 0;
        }
    }
}