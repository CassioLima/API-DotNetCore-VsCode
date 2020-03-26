using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Manutencao.Data;
using Manutencao.Models;

namespace Manutencao.Controllers
{
    [Route("Equipamentos")]
    public class EquipamentoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Equipamento>>> Get([FromServices]DataContext context)
        {
            var equipamentos = await context.Equipamentos.Include(x => x.Tipo).AsNoTracking().ToListAsync();
            return equipamentos;

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Tipo>>> GetById(int id, [FromServices]DataContext context)
        {
            var equipamento = await context.Equipamentos.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();

            if (equipamento == null)
            {
                return NotFound(new {message = "Equipamento não localizado"});
            }
            return Ok(equipamento);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Tipo>>> GetByTipo(int id, [FromServices]DataContext context)
        {
            var equipamento = await context.Equipamentos.Include(x => x.Tipo).AsNoTracking().Where(x => x.TipoId == id).ToListAsync();

            if (equipamento == null)
            {
                return NotFound(new {message = "Nenhum Equipamento para esta categoria"});
            }
            return Ok(equipamento);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Equipamento>> Post(
            [FromBody]Equipamento model,
            [FromServices]DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try 
            {
                context.Equipamentos.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest(new {message = "Não foi possível criar o tipo !"});
            }
        }
    }
}