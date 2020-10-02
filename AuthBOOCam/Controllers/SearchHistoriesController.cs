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
    public class SearchHistoriesController : ApiController
    {
        private SearchContext db = new SearchContext();


        // GET: api/SearchHistories
        public IQueryable<SearchHistory> GetSearchHistories()
        {


            return db.SearchHistories;
        }
        // GET: api/SearchHistories/ForCurrentUser
        [Route("GET: api/SearchHistories/ForCurrentUser")]
        public IQueryable<SearchHistory> GetSearchHistoriesForCurrentUser()
        {

            string userId = User.Identity.GetUserId();
            return db.SearchHistories.Where(searchHistory => searchHistory.UserID == userId);
        }

        // GET: api/SearchHistories/5
        [ResponseType(typeof(SearchHistory))]
        public IHttpActionResult GetSearchHistory(int id)
        {
            SearchHistory searchHistory = db.SearchHistories.Find(id);
            if (searchHistory == null)
            {
                return NotFound();
            }

            return Ok(searchHistory);
        }

        // PUT: api/SearchHistories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSearchHistory(int id, SearchHistory searchHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != searchHistory.SearchID)
            {
                return BadRequest();
            }

            db.Entry(searchHistory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SearchHistoryExists(id))
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

        // POST: api/SearchHistories
        [ResponseType(typeof(SearchHistory))]
        public IHttpActionResult PostSearchHistory(SearchHistory searchHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string userId = User.Identity.GetUserId();
            searchHistory.UserID = userId;
            db.SearchHistories.Add(searchHistory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = searchHistory.SearchID }, searchHistory);
        }

        // DELETE: api/SearchHistories/5
        [ResponseType(typeof(SearchHistory))]
        public IHttpActionResult DeleteSearchHistory(int id)
        {
            SearchHistory searchHistory = db.SearchHistories.Find(id);
            if (searchHistory == null)
            {
                return NotFound();
            }
            string userId = User.Identity.GetUserId();
            if(userId != searchHistory.UserID)
            {
                return StatusCode(HttpStatusCode.Conflict);
            }
            db.SearchHistories.Remove(searchHistory);
            db.SaveChanges();

            return Ok(searchHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SearchHistoryExists(int id)
        {
            return db.SearchHistories.Count(e => e.SearchID == id) > 0;
        }
    }
}