using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cozzi_Inmobiliaria.Shared.Models
{
    [Description("Alquileres")]
    public class Alquiler : EntidadBase
    {
        public long InquilinoId { get; set; }
        public Inquilino? Inquilino { get; set; }
        public long InmuebleId { get; set; }
        public Inmueble? Inmueble { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaFin { get; set; }
        public double Precio { get; set; }
    }
}
