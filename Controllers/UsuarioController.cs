using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Manutencao.Data;
using Manutencao.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Manutencao.Services;

[Route("usuarios")]
public class UsuarioController : Controller
{
    [HttpPost]
    [Route("")]
    [AllowAnonymous]
    public async Task<ActionResult<Usuario>> Post(
        [FromServices] DataContext context,
        [FromBody]Usuario model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try{
            context.Usuarios.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch (Exception)
        {
            return BadRequest(new {message = "Não foi possível criar o usuário"});
        }
    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Authenticate(
        [FromServices]DataContext context,
        [FromBody]Usuario model)
        {
            var user = await context.Usuarios
                        .AsNoTracking()
                        .Where(x => x.Username == model.Username & x.Password == model.Password)
                        .FirstOrDefaultAsync();

            if (user == null)
                return NotFound(new {message = "Usuário ou senha invalidos"});

            var token = TokenService.GenereteToken(user);
            return new {
                user = user,
                token = token
            };

        }

}