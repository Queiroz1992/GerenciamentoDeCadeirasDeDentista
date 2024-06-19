using GerenDeCadeiraDeDentista.Application.DTOs;
using GerenDeCadeiraDeDentista.Application.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenDeCadeiraDeDentista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadeiraDentistaController : ControllerBase
    {
        private readonly IServicoDeCadeiraDentista _servicoDeCadeiraDentista;

        public CadeiraDentistaController(IServicoDeCadeiraDentista servicoDeCadeiraDentista)
        {
            _servicoDeCadeiraDentista = servicoDeCadeiraDentista;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CadeiraDentistaDTO>>> Get()
        {
            var cadeiraDentistas = await _servicoDeCadeiraDentista.GetAllAsync();
            return Ok(cadeiraDentistas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CadeiraDentistaDTO>> Get(int id)
        {
            var cadeiraDentista = await _servicoDeCadeiraDentista.GetByIdAsync(id);
            if (cadeiraDentista == null)
            {
                return NotFound();
            }
            return Ok(cadeiraDentista);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CadeiraDentistaDTO cadeiraDentistaDTO)
        {
            await _servicoDeCadeiraDentista.CreateAsync(cadeiraDentistaDTO);
            return CreatedAtAction(nameof(Get), new { id = cadeiraDentistaDTO.Id }, cadeiraDentistaDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CadeiraDentistaDTO cadeiraDentistaDTO)
        {
            if (id != cadeiraDentistaDTO.Id)
            {
                return BadRequest();
            }
            await _servicoDeCadeiraDentista.UpdateAsync(cadeiraDentistaDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _servicoDeCadeiraDentista.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("alocacao")]
        public async Task<ActionResult<IEnumerable<AlocacaoAutomaticaDTO>>> Alocacao([FromQuery] DateTime inicio, [FromQuery] DateTime fim, [FromQuery] int encaixes)
        {
            var alocacoes = await _servicoDeCadeiraDentista.AlocarCadeiras(inicio, fim, encaixes);
            return Ok(alocacoes);
        }
    }
}
