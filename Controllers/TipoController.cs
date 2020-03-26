using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manutencao.Data;
using Manutencao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//Endoint => URL
// http://localhost:5000
// https://localhost:5001/tipos
[Route("tipos")]
public class TipoController : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Tipo>>> Get([FromServices]DataContext context)
    {
        var tipos = await context.Tipos.AsNoTracking().ToListAsync();
        return Ok(tipos);
    }


    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Tipo>> GetById(int id, [FromServices]DataContext context)
    {
        var tipo = await context.Tipos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (tipo == null)
        {
            return NotFound(new {message = "Tipo não localizado"});
        }
        return Ok(tipo);
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<List<Tipo>>> Post(
        [FromBody]Tipo model,
        [FromServices]DataContext context)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        try 
        {
            context.Tipos.Add(model);
            await context.SaveChangesAsync();

            return Ok(model);
        }
        catch
        {
            return BadRequest(new {message = "Não foi possível criar o tipo !"});
        }
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Tipo>> Put(
        int id,
        [FromBody]Tipo model,
        [FromServices]DataContext context)
    {
        if (model.Id != id)
            return NotFound(new {message = "Categoria não encontrada"});
       
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try{
            context.Entry<Tipo>(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch(DbUpdateConcurrencyException)
        {
            return BadRequest(new {message = "Este registro já foi atualizado"});
        }
        catch
        {
            return BadRequest(new {message = "Não foi possível atualizar o tipo"});
        }            

        

    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<List<Tipo>>> Delete(
        int id,
        [FromServices]DataContext context
    )
    {
        var tipo = await context.Tipos.FirstOrDefaultAsync(x => x.Id == id);
        if (tipo == null)
            return NotFound(new {message = "Tipo não localizado"});
        
        try{
            context.Tipos.Remove(tipo);
            await context.SaveChangesAsync();
            return Ok(new {message = "Tipo Removido"});
        }
        catch(Exception)
        {
            return BadRequest(new{message = "Não foi possivel excluir o tipo"});
        }
        
    }

}