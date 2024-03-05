using Cozzi_Inmobiliaria.Server.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cozzi_Inmobiliaria.Shared.Dto
{
    public class ClienteResponseDto
    {
        public long Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Documento { get; set; }
        public string? CuitCuil { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public IEnumerable<InmuebleResponseDto>? Inmuebles { get; set; }
    }
}
