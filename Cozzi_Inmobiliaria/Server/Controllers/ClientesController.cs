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
using Cozzi_Inmobiliaria.Server.Services;
using Cozzi_Inmobiliaria.Shared.Dto;
using Azure.Core;

namespace Cozzi_Inmobiliaria.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Obtiene todos los Clientes activos
        /// </summary>
        /// <returns>Lista de Clientes</returns> 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteResponseDto>>> GetClientes()
        {
            return Ok(await _clienteService.GetClientes());
        }

        /// <summary>
        /// Obtiene los datos de un Cliente por id
        /// </summary>
        /// <param name="id">Id del Cliente</param>
        /// <returns>Datos de un Cliente especifico</returns> 
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteResponseDto>> GetCliente([FromRoute] long id)
        {
            return Ok(await _clienteService.GetCliente(id));
        }

        /// <summary>
        /// Actualiza datos de un Cliente por id
        /// </summary>
        /// <param name="id">Id del Cliente</param>
        /// <param name="request">Datos enviados por request</param>
        /// <returns></returns> 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente([FromRoute] long id, [FromBody] ClienteRequestDto request)
        {
            await _clienteService.PutCliente(id, request);
            return Ok();
        }

        /// <summary>
        /// Crea un nuevo registro de Cliente
        /// </summary>
        /// <param name="request">Datos enviados por request del Cliente</param>
        /// <returns></returns> 
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente([FromBody] ClienteRequestDto request)
        {
            await _clienteService.PostCliente(request);
            return Ok();
        }

        /// <summary>
        /// Elimina un Cliente por id
        /// </summary>
        /// <param name="id">Id del Cliente</param>
        /// <returns></returns> 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente([FromRoute] long id)
        {
            await _clienteService.DeleteCliente(id);
            return Ok();
        }       
    }
}
