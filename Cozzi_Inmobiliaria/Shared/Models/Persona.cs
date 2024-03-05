using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cozzi_Inmobiliaria.Shared.Models
{
    public class Persona : EntidadBase
    {
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public long Documento { get; set; }
        public long CuitCuil { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
    }
}
