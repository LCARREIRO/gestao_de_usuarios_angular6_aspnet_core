using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestaoDeUsuario.Api.Dto;
using GestaoDeUsuario.Aplicacao.Interfaces;
using GestaoDeUsuario.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeUsuario.Api.Controllers
{
    [ApiController]
    public class SexoController : ControllerBase
    {
        private readonly IMapper _mapper;

        public SexoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/Usuario
        [Route("v1/sexo")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SexoDTO>>> Get([FromServices] ISexoAppServico app)
        {
            return Ok(_mapper.Map<IEnumerable<Sexo>>(await app.GetAsync()));
        }
    }
}
