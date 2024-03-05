using Cozzi_Inmobiliaria.Server.Data;
using Cozzi_Inmobiliaria.Server.Dto;
using Cozzi_Inmobiliaria.Server.Interfaces;
using Cozzi_Inmobiliaria.Shared.Dto;
using Cozzi_Inmobiliaria.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Cozzi_Inmobiliaria.Server.Services
{
    public class ClienteService : IClienteService
    {
        private readonly Context _context;
        public ClienteService(Context context)
        {
            _context = context;
        }

        public async Task DeleteCliente(long id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id && x.Activo)
                ?? throw new Exception("Cliente no encontrado");

            cliente.Activo = false;
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<ClienteResponseDto> GetCliente(long id)
        {
            var cliente = await _context.Clientes.Include(x => x.Inmuebles).Where(x => x.Id == id && x.Activo)
                .Select(x => new ClienteResponseDto
                {
                    Id = x.Id,
                    Nombres = x.Nombres,
                    Apellidos = x.Apellidos,
                    Documento = x.Documento.ToString(),
                    CuitCuil = x.CuitCuil.ToString(),
                    Telefono = x.Telefono,
                    Email = x.Email                    
                }).FirstOrDefaultAsync()
                ?? throw new Exception("Cliente no encontrado");

            cliente.Inmuebles = await _context.Inmuebles
                .Where(x => x.ClienteId == cliente.Id && x.Activo)
                .Select(x => new InmuebleResponseDto
                {
                    Id = x.Id,
                    Direccion = x.Direccion,
                    Propietario = $"{x.Cliente.Apellidos} {x.Cliente.Nombres}",
                    Habitaciones = x.Habitaciones,
                    Baños = x.Baños,
                    Garages = x.Garages,
                    Patios = x.Patios,
                    Pisos = x.Pisos,
                    MetrosCuadrados = x.MetrosCuadrados,
                    Disponible = x.Disponible ? "Si" : "No",
                    Propio = x.Propio ? "Si" : "No",
                    Nota = x.Nota
                }).ToListAsync();

            return cliente; 
        }

        public async Task<IEnumerable<ClienteResponseDto>> GetClientes()
        {
            var clientes = await _context.Clientes.Where(x => x.Activo)
                .Select(x => new ClienteResponseDto
                {
                    Id = x.Id,
                    Nombres = x.Nombres,
                    Apellidos = x.Apellidos,
                    Documento = x.Documento.ToString(),
                    CuitCuil = x.CuitCuil.ToString(),
                    Telefono = x.Telefono,
                    Email = x.Email                    
                }).ToArrayAsync();

            for (int i = 0; i < clientes.Length; i++)
            {
                clientes[i].Inmuebles = await _context.Inmuebles
                .Where(x => x.ClienteId == clientes[i].Id && x.Activo)
                .Select(x => new InmuebleResponseDto
                {
                    Id = x.Id,
                    Direccion = x.Direccion,
                    Propietario = $"{x.Cliente.Apellidos} {x.Cliente.Nombres}",
                    Habitaciones = x.Habitaciones,
                    Baños = x.Baños,
                    Garages = x.Garages,
                    Patios = x.Patios,
                    Pisos = x.Pisos,
                    MetrosCuadrados = x.MetrosCuadrados,
                    Disponible = x.Disponible ? "Si" : "No",
                    Propio = x.Propio ? "Si" : "No",
                    Nota = x.Nota
                }).ToListAsync();
            }           

            return clientes.ToList();
        }

        public async Task PostCliente(ClienteRequestDto request)
        {
            validarRequest(request);

            _context.Clientes.Add(new Cliente
            {
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                Documento = request.Documento,
                CuitCuil = request.CuitCuil,
                Telefono = request.Telefono,
                Email = request.Email,
                Activo = true
            });
            await _context.SaveChangesAsync();
        }

        public async Task PutCliente(long id, ClienteRequestDto request)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id && x.Activo)
               ?? throw new Exception("Cliente no encontrado");

            validarRequest(request);

            cliente.Nombres = request.Nombres;
            cliente.Apellidos = request.Apellidos;
            cliente.Documento = request.Documento;
            cliente.CuitCuil = request.CuitCuil;
            cliente.Telefono = request.Telefono;
            cliente.Email = request.Email;

            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
        private void validarRequest(ClienteRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Nombres)) throw new Exception("Nombres es requerida");
            if (string.IsNullOrWhiteSpace(request.Apellidos)) throw new Exception("Apellidos es requerido");
            if (string.IsNullOrWhiteSpace(request.Telefono)) throw new Exception("Telefono es requerido");
        }
    }
}
