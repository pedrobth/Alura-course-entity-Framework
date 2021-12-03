using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilmesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(
                gerente => gerente.Id == id);

            if (gerente == null)
            {
                return NotFound();
            }

            ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
            return Ok(gerenteDto);
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto dto)
        {
            Gerente gerente = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(
                nameof(RecuperaGerentePorId), new { Id = gerente.Id }, gerente);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
