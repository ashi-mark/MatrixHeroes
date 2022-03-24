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
using MatrixHeroes;

namespace WebApplication1.Controllers
{
    public class AbilitiesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Abilities
        public IQueryable<Ability> GetAbilities()
        {
            return db.Abilities;
        }

        // GET: api/Abilities/5
        [ResponseType(typeof(Ability))]
        public IHttpActionResult GetAbility(int id)
        {
            Ability ability = db.Abilities.Find(id);
            if (ability == null)
            {
                return NotFound();
            }

            return Ok(ability);
        }

        // PUT: api/Abilities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAbility(int id, Ability ability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ability.Id)
            {
                return BadRequest();
            }

            db.Entry(ability).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbilityExists(id))
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

        // POST: api/Abilities
        [ResponseType(typeof(Ability))]
        public IHttpActionResult PostAbility(Ability ability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Abilities.Add(ability);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ability.Id }, ability);
        }

        // DELETE: api/Abilities/5
        [ResponseType(typeof(Ability))]
        public IHttpActionResult DeleteAbility(int id)
        {
            Ability ability = db.Abilities.Find(id);
            if (ability == null)
            {
                return NotFound();
            }

            db.Abilities.Remove(ability);
            db.SaveChanges();

            return Ok(ability);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AbilityExists(int id)
        {
            return db.Abilities.Count(e => e.Id == id) > 0;
        }
    }
}