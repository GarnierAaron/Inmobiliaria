using Cozzi_Inmobiliaria.Server.Dto;
using Cozzi_Inmobiliaria.Shared.Dto;

namespace Cozzi_Inmobiliaria.Server.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteResponseDto>> GetClientes();
        Task<ClienteResponseDto> GetCliente(long id);
        Task PutCliente(long id, ClienteRequestDto request);
        Task PostCliente(ClienteRequestDto request);
        Task DeleteCliente(long id);
    }
}
