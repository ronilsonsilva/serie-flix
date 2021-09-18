using Microsoft.AspNetCore.Mvc;
using SerieFlix.Domain.Contracts.DomainServices;
using SerieFlix.Domain.Entities;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SerieFlix.ServicesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        protected readonly ISerieDomainServices _serieDomainServices;

        public SeriesController(ISerieDomainServices serieDomainServices)
        {
            _serieDomainServices = serieDomainServices;
        }

        // GET: api/<SerieController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var series = await this._serieDomainServices.Consultar();
            if (series?.Count > 0)
                return Ok(series);
            return NoContent();
        }

        // GET api/<SerieController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var serie = await this._serieDomainServices.Consultar(id);
            if (serie != null)
                return Ok(serie);
            return NoContent();
        }

        // POST api/<SerieController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Serie serie)
        {
            var retornoDominio = await this._serieDomainServices.Adicionar(serie);
            if (retornoDominio.Ok)
                return Created(uri: $"series/{serie.Id}", retornoDominio);
            return BadRequest(retornoDominio);
        }

        // PUT api/<SerieController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Serie serie)
        {
            var retornoDominio = await this._serieDomainServices.Atualizar(serie);
            if (retornoDominio.Ok)
                return Ok(retornoDominio);
            return BadRequest(retornoDominio);
        }

        // DELETE api/<SerieController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var retornoDominio = await this._serieDomainServices.Excluir(id);
            return Ok(retornoDominio);
        }
    }
}
