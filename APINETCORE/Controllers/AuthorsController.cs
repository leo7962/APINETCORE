using APINETCORE.Contexts;
using APINETCORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APINETCORE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AuthorsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //Esta acción va a responder un Get
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            return context.Authors.ToList();
        }

        //Esta acción traerá un get de una sola ID
        [HttpGet("{id}", Name = "ObtenerAutor")]
        public ActionResult<Author> Get(int id)
        {
            Author author = context.Authors.FirstOrDefault(x => x.Id == id);

            if (author == null)
            {
                //NotFound hace referencia a un 404 no encontrado
                return NotFound();
            }

            return author;
        }

        //Esta acción va a realizar un Post
        [HttpPost]
        public ActionResult Post([FromBody] Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerAutor", new { id = author.Id }, author);
        }

        //Esta acción va a realizar una actualización a un registro
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Author value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }

            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //Esta acción elimina un registro 
        [HttpDelete("{id}")]
        public ActionResult<Author> Delete(int id)
        {
            var autor = context.Authors.FirstOrDefault(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            context.Authors.Remove(autor);
            context.SaveChanges();
            return autor;
        }
    }
}