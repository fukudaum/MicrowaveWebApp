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
using MicrowaveWebApp.Data;
using MicrowaveWebApp.Models;

namespace MicrowaveWebApp.Controllers
{
    public class ProgramTypesController : ApiController
    {
        private MicrowaveWebAppContext db = new MicrowaveWebAppContext();

        // GET: api/ProgramTypes
        public IQueryable<ProgramType> GetProgramTypes()
        {
            return db.ProgramTypes;
        }

        // GET: api/ProgramTypes/5
        [ResponseType(typeof(ProgramType))]
        public IHttpActionResult GetProgramType(int id)
        {
            ProgramType programType = db.ProgramTypes.Find(id);
            if (programType == null)
            {
                return NotFound();
            }

            return Ok(programType);
        }

        // PUT: api/ProgramTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProgramType(int id, ProgramType programType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != programType.Id)
            {
                return BadRequest();
            }

            db.Entry(programType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramTypeExists(id))
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

        // POST: api/ProgramTypes
        [ResponseType(typeof(ProgramType))]
        public IHttpActionResult PostProgramType(ProgramType programType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProgramTypes.Add(programType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = programType.Id }, programType);
        }

        // DELETE: api/ProgramTypes/5
        [ResponseType(typeof(ProgramType))]
        public IHttpActionResult DeleteProgramType(int id)
        {
            ProgramType programType = db.ProgramTypes.Find(id);
            if (programType == null)
            {
                return NotFound();
            }

            db.ProgramTypes.Remove(programType);
            db.SaveChanges();

            return Ok(programType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProgramTypeExists(int id)
        {
            return db.ProgramTypes.Count(e => e.Id == id) > 0;
        }
    }
}