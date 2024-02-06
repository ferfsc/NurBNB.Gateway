namespace NurBNB.Gateway.Dto
{
    public class PropiedadDto
    {
        public Guid ID_Propiedad { get; set; }
        public string Propietario_ID { get; set; }

        public string Titulo { get; set; }
        public decimal Precio { get; set; }
        public string Detalle { get; set; }
        public string ubicacion { get; set; }
        public string Estado { get; set; }
    }
}
