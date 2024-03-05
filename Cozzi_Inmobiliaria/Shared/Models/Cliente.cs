using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cozzi_Inmobiliaria.Shared.Models
{
    [Description("Clientes")]
    public class Cliente : Persona
    {
        public IEnumerable<Inmueble>? Inmuebles { get; set; }
    }
}
