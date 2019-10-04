using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestaoDeUsuario.Api.Dto;
using GestaoDeUsuario.Api.Dto.RetornoMsg;
using GestaoDeUsuario.Aplicacao.Interfaces;
using GestaoDeUsuario.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeUsuario.Api.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;

        public UsuarioController(IMapper mapper)
        {
            _mapper = mapper;
        }       

        // GET: api/Usuario
        [Route("v1/usuario")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> Get([FromServices] IUsuarioAppServico app)
        {
            return Ok(_mapper.Map<IEnumerable<Usuario>>(await app.GetAsync()));
        }

        // GET: api/Usuario/5
        [Route("v1/usuario/{id}")]
        [HttpGet]
        public async Task<ActionResult<UsuarioDTO>> Get([FromServices] IUsuarioAppServico app, int id)
        {
            var result = _mapper.Map<Usuario>(app.First(x => x.UsuarioId == id));

            if (result == null)
            {
                return NotFound();
            }

            return  Ok(result);
        }

        // PUT: api/Usuario/5
        //[ClaimsAuthorize("Usuario", "Editar")]
        [Route("v1/usuario")]
        [HttpPut]
        public async Task<IActionResult> Put([FromServices] IUsuarioAppServico app, UsuarioDTO usuarioDTO)
        {
            usuarioDTO.Validate();

            if (usuarioDTO.Invalid)

                return BadRequest(new RetornoDTO()
                {
                    Success = false,
                    Message = "Não foi possível editar usuario",
                    Data = usuarioDTO.Notifications
                });

            try
            {
                app.Update(_mapper.Map <Usuario>(usuarioDTO));
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!app.Exists(x => x.UsuarioId == usuarioDTO.UsuarioId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new RetornoDTO()
            {
                Success = true,
                Message = "Usuario editado com sucesso",
                Data = usuarioDTO
            });
        }

        //[ClaimsAuthorize("Usuario", "Incluir")]
        [Route("v1/usuario")]
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post([FromServices] IUsuarioAppServico app, UsuarioDTO usuarioDTO)
        {
            usuarioDTO.Validate();
            if (usuarioDTO.Invalid)

                return BadRequest(new RetornoDTO()
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o usuario",
                    Data = usuarioDTO.Notifications
                });


            try
            {
                await app.InsertAsync(_mapper.Map<Usuario>(usuarioDTO));

                return Ok(new RetornoDTO()

                {
                    Success = true,
                    Message = "Usuario cadastrado com sucesso",
                    Data = usuarioDTO
                });
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        //[ClaimsAuthorize("Usuario", "Excluir")]
        [Route("v1/usuario/{id}")]
        [HttpDelete]
        public async Task<ActionResult<UsuarioDTO>> Delete([FromServices] IUsuarioAppServico app, int id)
        {
            var usuario = await app.GetAsync();
            if (usuario == null)
            {
                return NotFound();
            }

            app.Delete(x => x.UsuarioId == id);

            return Ok(usuario);
        }

        private bool UsuarioExists([FromServices] IUsuarioAppServico app, int id)
        {
            return app.Exists(x => x.UsuarioId == id);
        }
    }
}
