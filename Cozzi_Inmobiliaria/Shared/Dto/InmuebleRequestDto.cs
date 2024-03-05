namespace Cozzi_Inmobiliaria.Server.Dto
{
    public class InmuebleRequestDto
    {
        public long? Id { get; set; }
        public string? Direccion { get; set; }
        public long? ClienteId { get; set; }
        public long Habitaciones { get; set; }
        public long Baños { get; set; }
        public long Garages { get; set; }
        public long Patios { get; set; }
        public long Pisos { get; set; }
        public long MetrosCuadrados { get; set; }
        public bool Propio { get; set; }
        public string? Nota { get; set; }
    }
}
