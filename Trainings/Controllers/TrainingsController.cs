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
using Trainings.DataAccess;
using Trainings.Models;

namespace Trainings.Controllers
{
    public class TrainingsController : ApiController
    {
        private TrainingDataAccess db = new TrainingDataAccess();

        // GET: api/Trainings
        public IQueryable<Trainings.Models.Trainings> GetTrainings()
        {
            return db.Trainings;
        }

        // GET: api/Trainings/5
        [ResponseType(typeof(Trainings.Models.Trainings))]
        public IHttpActionResult GetTrainings(int id)
        {
            Trainings.Models.Trainings trainings = db.Trainings.Find(id);
            if (trainings == null)
            {
                return NotFound();
            }

            return Ok(trainings);
        }

        // PUT: api/Trainings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrainings(int id, Trainings.Models.Trainings trainings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainings.RecordID)
            {
                return BadRequest();
            }

            db.Entry(trainings).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingsExists(id))
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

        // POST: api/Trainings
        [ResponseType(typeof(Trainings.Models.Trainings))]
        public IHttpActionResult PostTrainings(Trainings.Models.Trainings trainings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Trainings.Add(trainings);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return CreatedAtRoute("DefaultApi", new { id = trainings.RecordID }, trainings);
        }

        // DELETE: api/Trainings/5
        [ResponseType(typeof(Trainings.Models.Trainings))]
        public IHttpActionResult DeleteTrainings(int id)
        {
            Trainings.Models.Trainings trainings = db.Trainings.Find(id);
            if (trainings == null)
            {
                return NotFound();
            }

            db.Trainings.Remove(trainings);
            db.SaveChanges();

            return Ok(trainings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainingsExists(int id)
        {
            return db.Trainings.Count(e => e.RecordID == id) > 0;
        }
    }
}