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
    public class ContactFormsController : ApiController
    {
        private tociEntities1 db = new tociEntities1();

        // GET: api/ContactForms
        public IQueryable<ContactForm> GetContactForms()
        {
            return db.ContactForms;
        }

        // GET: api/ContactForms/5
        [ResponseType(typeof(ContactForm))]
        public IHttpActionResult GetContactForm(int id)
        {
            ContactForm contactForm = db.ContactForms.Find(id);
            if (contactForm == null)
            {
                return NotFound();
            }

            return Ok(contactForm);
        }

        // PUT: api/ContactForms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContactForm(int id, ContactForm contactForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactForm.Id)
            {
                return BadRequest();
            }

            db.Entry(contactForm).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactFormExists(id))
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

        // POST: api/ContactForms
        [ResponseType(typeof(ContactForm))]
        public IHttpActionResult PostContactForm(ContactForm contactForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContactForms.Add(contactForm);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contactForm.Id }, contactForm);
        }

        // DELETE: api/ContactForms/5
        [ResponseType(typeof(ContactForm))]
        public IHttpActionResult DeleteContactForm(int id)
        {
            ContactForm contactForm = db.ContactForms.Find(id);
            if (contactForm == null)
            {
                return NotFound();
            }

            db.ContactForms.Remove(contactForm);
            db.SaveChanges();

            return Ok(contactForm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactFormExists(int id)
        {
            return db.ContactForms.Count(e => e.Id == id) > 0;
        }
    }
}