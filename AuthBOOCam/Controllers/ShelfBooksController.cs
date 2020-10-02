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
using AuthBOOCam.Models;
using Microsoft.AspNet.Identity;

namespace AuthBOOCam.Controllers
{
    [Authorize]
    public class ShelfBooksController : ApiController
    {
        private BOOCamContext db = new BOOCamContext();

        // GET: api/ShelfBooks
        public IQueryable<ShelfBooks> GetShelfBooks()
        {
            return db.ShelfBooks;
        }


        // GET: api/ShelfBooks/CurrentUser
        public IQueryable<ShelfBooks> GetShelfBooksForCurrentUser()
        {
            string userId = User.Identity.GetUserId();
            return db.ShelfBooks.Where(shelfBooks => shelfBooks.UserId == userId);
           
        }

        // GET: api/ShelfBooks/5
        [ResponseType(typeof(ShelfBooks))]
        public IHttpActionResult GetShelfBooks(int id)
        {
            ShelfBooks shelfBooks = db.ShelfBooks.Find(id);
            if (shelfBooks == null)
            {
                return NotFound();
            }

            return Ok(shelfBooks);
        }

        // PUT: api/ShelfBooks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShelfBooks(int id, ShelfBooks shelfBooks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shelfBooks.BookID)
            {
                return BadRequest();
            }

            db.Entry(shelfBooks).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShelfBooksExists(id))
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

        // POST: api/ShelfBooks
        [ResponseType(typeof(ShelfBooks))]
        public IHttpActionResult PostShelfBooks(ShelfBooks shelfBooks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string userId = User.Identity.GetUserId();
            shelfBooks.UserId = userId;
            db.ShelfBooks.Add(shelfBooks);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shelfBooks.BookID }, shelfBooks);
        }

        // DELETE: api/ShelfBooks/5
        [ResponseType(typeof(ShelfBooks))]
        public IHttpActionResult DeleteShelfBooks(int id)
        {
            ShelfBooks shelfBooks = db.ShelfBooks.Find(id);
            if (shelfBooks == null)
            {
                return NotFound();
            }
            string userId = User.Identity.GetUserId();
            if(userId != shelfBooks.UserId)
            {
                return StatusCode(HttpStatusCode.Conflict);

            }
            db.ShelfBooks.Remove(shelfBooks);
            db.SaveChanges();

            return Ok(shelfBooks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShelfBooksExists(int id)
        {
            return db.ShelfBooks.Count(e => e.BookID == id) > 0;
        }
    }
}