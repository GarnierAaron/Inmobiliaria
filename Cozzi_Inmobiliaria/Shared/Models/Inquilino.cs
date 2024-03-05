using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cozzi_Inmobiliaria.Shared.Models
{
    [Description("Inquilinos")]
    public class Inquilino : Persona
    {        
        public long CantidadHijos { get; set; }
        public bool Conyuge { get; set; }
        public bool TieneMascotas { get; set; }
        public bool TieneVehiculo { get; set; }
        public ICollection<Alquiler>? Alquileres { get; set; }
    }
}
