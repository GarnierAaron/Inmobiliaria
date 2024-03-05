namespace Cozzi_Inmobiliaria.Server.Dto
{
    public class InmuebleResponseDto
    {
        public long Id { get; set; }
        public string? Direccion { get; set; }
        public string? Propietario { get; set; }
        public long Habitaciones { get; set; }
        public long Baños { get; set; }
        public long Garages { get; set; }
        public long Patios { get; set; }
        public long Pisos { get; set; }
        public long MetrosCuadrados { get; set; }
        public string? Disponible { get; set; }
        public string? Propio { get; set; }
        public string? Nota { get; set; }
    }
}
