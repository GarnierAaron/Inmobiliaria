using Azure.Core;
using Cozzi_Inmobiliaria.Server.Data;
using Cozzi_Inmobiliaria.Server.Dto;
using Cozzi_Inmobiliaria.Server.Interfaces;
using Cozzi_Inmobiliaria.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Cozzi_Inmobiliaria.Server.Services
{
    public class InmuebleService : IInmuebleService
    {
        private readonly Context _context;
        public InmuebleService(Context context) 
        {  
            _context = context; 
        }

        public async Task DeleteInmueble(long id)
        {
            var inmueble = await _context.Inmuebles.FirstOrDefaultAsync(x => x.Id == id && x.Activo)
                ?? throw new Exception("Inmueble no encontrado");

            inmueble.Activo = false;
            _context.Inmuebles.Update(inmueble);
            await _context.SaveChangesAsync();
        }

        public async Task<InmuebleRequestDto> GetInmueble(long id)
        {
            return await _context.Inmuebles.Where(x => x.Id == id && x.Activo)
                .Select(x => new InmuebleRequestDto
                {
                    Id = x.Id,
                    Direccion = x.Direccion,
                    ClienteId = x.ClienteId,
                    Habitaciones = x.Habitaciones,
                    Baños = x.Baños,
                    Garages = x.Garages,
                    Patios = x.Patios,
                    Pisos = x.Pisos,
                    MetrosCuadrados = x.MetrosCuadrados,
                    Propio = x.Propio,
                    Nota = x.Nota,
                }).FirstOrDefaultAsync() 
                ?? throw new Exception("Inmueble no encontrado");
        }

        public async Task<IEnumerable<InmuebleResponseDto>> GetInmuebles()
        {
            return await _context.Inmuebles.Where(x => x.Activo).Select(x => new InmuebleResponseDto
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
                Nota = x.Nota,
            }).ToArrayAsync();
        }

        public async Task PostInmueble(InmuebleRequestDto request)
        {
            validarRequest(request);

            _context.Inmuebles.Add(new Inmueble
            {
                Direccion = request.Direccion,
                ClienteId = request.ClienteId.Value,
                Habitaciones = request.Habitaciones,
                Baños = request.Baños,
                Garages = request.Garages,
                Patios = request.Patios,
                Pisos = request.Pisos,
                MetrosCuadrados = request.MetrosCuadrados,
                Propio = request.Propio,
                Nota = request.Nota,
                Disponible = true,
                Activo = true
            });

            await _context.SaveChangesAsync();
        }

        public async Task PutInmueble(long id, InmuebleRequestDto request)
        {
            var inmueble = await _context.Inmuebles.FirstOrDefaultAsync(x => x.Id == id && x.Activo)
                ?? throw new Exception("Inmueble no encontrado");

            validarRequest(request);

            inmueble.Direccion = request.Direccion;
            inmueble.ClienteId = request.ClienteId.Value;
            inmueble.Habitaciones = request.Habitaciones;
            inmueble.Baños = request.Baños;
            inmueble.Garages = request.Garages;
            inmueble.Patios = request.Patios;
            inmueble.Pisos = request.Pisos;
            inmueble.MetrosCuadrados = request.MetrosCuadrados;
            inmueble.Propio = request.Propio;
            inmueble.Nota = request.Nota;

            _context.Inmuebles.Update(inmueble);
            await _context.SaveChangesAsync();
        }

        private void validarRequest(InmuebleRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Direccion)) throw new Exception("La direccion es requerida");
            if (!_context.Clientes.Any(x => x.Id == request.ClienteId && x.Activo)) throw new Exception("Cliente no encontrado");
        }
    }
}
