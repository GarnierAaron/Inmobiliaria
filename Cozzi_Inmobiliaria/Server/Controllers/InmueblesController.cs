using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cozzi_Inmobiliaria.Server.Data;
using Cozzi_Inmobiliaria.Shared.Models;
using Cozzi_Inmobiliaria.Server.Interfaces;
using Cozzi_Inmobiliaria.Server.Dto;

namespace Cozzi_Inmobiliaria.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmueblesController : ControllerBase
    {
        private readonly IInmuebleService _inmuebleService;
        public InmueblesController(IInmuebleService inmuebleService)
        {
            _inmuebleService = inmuebleService;
        }

        /// <summary>
        /// Obtiene todos los inmuebles activos
        /// </summary>
        /// <returns>Lista de Inmuebles</returns> 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InmuebleResponseDto>>> GetInmuebles()
        {
            return Ok(await _inmuebleService.GetInmuebles());
        }

        /// <summary>
        /// Obtiene los datos de un Inmueble por id
        /// </summary>
        /// <param name="id">Id del Inmueble</param>
        /// <returns>Datos de un inmueble especifico</returns> 
        [HttpGet("{id}")]
        public async Task<ActionResult<InmuebleRequestDto>> GetInmueble([FromRoute] long id)
        {
            return Ok(await _inmuebleService.GetInmueble(id));
        }

        /// <summary>
        /// Actualiza datos de un inmueble por id
        /// </summary>
        /// <param name="id">Id del Inmueble</param>
        /// <param name="request">Datos enviados por request</param>
        /// <returns></returns> 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInmueble([FromRoute] long id, [FromBody] InmuebleRequestDto request)
        {
            await _inmuebleService.PutInmueble(id, request);
            return Ok();
        }

        /// <summary>
        /// Crea un nuevo registro de inmueble
        /// </summary>
        /// <param name="request">Datos enviados por request del inmueble</param>
        /// <returns></returns> 
        [HttpPost]
        public async Task<IActionResult> PostInmueble([FromBody] InmuebleRequestDto request)
        {
            await _inmuebleService.PostInmueble(request);
            return Ok();
        }

        /// <summary>
        /// Elimina un inmueble por id
        /// </summary>
        /// <param name="id">Id del Inmueble</param>
        /// <returns></returns> 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInmueble(long id)
        {
            await _inmuebleService.DeleteInmueble(id);
            return Ok();
        }
    }
}
