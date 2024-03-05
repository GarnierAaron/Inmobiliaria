using Cozzi_Inmobiliaria.Server.Dto;
using Cozzi_Inmobiliaria.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cozzi_Inmobiliaria.Server.Interfaces
{
    public interface IInmuebleService
    {
        Task<IEnumerable<InmuebleResponseDto>> GetInmuebles();
        Task<InmuebleRequestDto> GetInmueble(long id);
        Task PutInmueble(long id, InmuebleRequestDto request);
        Task PostInmueble(InmuebleRequestDto request);
        Task DeleteInmueble(long id);
    }
}
