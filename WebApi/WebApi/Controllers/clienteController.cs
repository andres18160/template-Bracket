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
using WebApi.Datos;

namespace WebApi.Controllers
{
    public class clienteController : ApiController
    {
        private PruebaFacturaEntities1 db = new PruebaFacturaEntities1();

        // GET: api/cliente
        public IQueryable<tb_cliente> Gettb_cliente()
        {
            return db.tb_cliente;
        }

        // GET: api/cliente/5
        [ResponseType(typeof(tb_cliente))]
        public IHttpActionResult Gettb_cliente(int id)
        {
            tb_cliente tb_cliente = db.tb_cliente.Find(id);
            if (tb_cliente == null)
            {
                return NotFound();
            }

            return Ok(tb_cliente);
        }

        // PUT: api/cliente/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_cliente(int id, tb_cliente tb_cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_cliente.Id)
            {
                return BadRequest();
            }

            db.Entry(tb_cliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_clienteExists(id))
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

        // POST: api/cliente
        [ResponseType(typeof(tb_cliente))]
        public IHttpActionResult Posttb_cliente(tb_cliente tb_cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_cliente.Add(tb_cliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_cliente.Id }, tb_cliente);
        }

        // DELETE: api/cliente/5
        [ResponseType(typeof(tb_cliente))]
        public IHttpActionResult Deletetb_cliente(int id)
        {
            tb_cliente tb_cliente = db.tb_cliente.Find(id);
            if (tb_cliente == null)
            {
                return NotFound();
            }

            db.tb_cliente.Remove(tb_cliente);
            db.SaveChanges();

            return Ok(tb_cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_clienteExists(int id)
        {
            return db.tb_cliente.Count(e => e.Id == id) > 0;
        }
    }
}