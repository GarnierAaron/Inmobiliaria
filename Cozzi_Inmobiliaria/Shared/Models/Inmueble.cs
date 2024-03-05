using System.ComponentModel;

namespace Cozzi_Inmobiliaria.Shared.Models
{
    [Description("Inmuebles")]
    public class Inmueble : EntidadBase
    {
        public string? Direccion { get; set; }
        public long Habitaciones { get; set; }
        public long Baños { get; set; }
        public long Garages { get; set; }
        public long Patios { get; set; }
        public long Pisos { get; set; }
        public long MetrosCuadrados { get; set; }
        public bool Disponible { get; set; }
        public bool Propio { get; set; }
        public long ClienteId {  get; set; }
        public Cliente? Cliente { get; set; }
        public ICollection<Alquiler>? Alquileres { get; set; }
    }
}
