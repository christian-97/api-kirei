using api_peliculas.Dtos;
using api_peliculas.Entitys;
using api_peliculas.Filtros;
using api_peliculas.Utilidades;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_peliculas.Controllers
{
    [Route("api-peliculas/generos")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GeneroController : ControllerBase
    {
        
        private readonly ILogger<GeneroController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GeneroController(
            ILogger<GeneroController> logger,
            ApplicationDbContext context,
            IMapper mapper
            )
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        } 

        [HttpGet]
        public async Task<ActionResult<List<GeneroDto>>>
            getAll([FromQuery] PaginacionDto paginacionDto)
        {
            var queryable = context.T_Genero.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionCabecera(queryable);
            var generos = await queryable.OrderBy(x => x.codigo)
                .Paginar(paginacionDto).ToListAsync();
            return mapper.Map<List<GeneroDto>>(generos);

            /*
            var resultados = new List<GeneroDto>();
            foreach (var genero in generos)
            {
                resultados.Add(
                    new GeneroDto(){
                        codigo=genero.codigo,
                        nombre=genero.nombre,
                        estado=genero.estado});
            }
            */
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<GeneroDto>> findById(int id)
        {
            var genero = await context.T_Genero
                .FirstOrDefaultAsync(x => x.codigo == id);
            if (genero == null)
            {
                return NotFound();
            }

            return mapper.Map<GeneroDto>(genero);
        }


        [HttpPost]
        public async Task<ActionResult> add([FromBody] GeneroInsertarDto generodto)
        {
            var genero=mapper.Map<Genero>(generodto);
            context.Add(genero);
            await context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> update
            (int id, [FromBody] GeneroInsertarDto generodto)
        {
            var genero = await context.T_Genero.FirstOrDefaultAsync(x => x.codigo == id);
            if(genero == null)
            {
                return NotFound();
            }

            genero = mapper.Map(generodto, genero);
            await context.SaveChangesAsync();
            return NoContent();

        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {

            var genero = await context.T_Genero.FirstOrDefaultAsync(x => x.codigo == id);
            if (genero == null)
            {
                return NotFound();
            }

            genero.estado = false;
            await context.SaveChangesAsync();
            return NoContent();


            /*
            var existe = await context.T_Genero
                .AnyAsync(x => x.codigo == id);
            if (!existe)
            {
                return NotFound();

            }
            context.Remove(new Genero() { codigo = id });
            await context.SaveChangesAsync();
            return NoContent();
            */

        }
    }
}
