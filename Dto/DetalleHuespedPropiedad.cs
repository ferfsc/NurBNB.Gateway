namespace NurBNB.Gateway.Dto
{
    public class DetalleHuespedPropiedad
    {
        public Guid HuespedID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public Guid ID_Propiedad { get; set; }
        public string Propietario_ID { get; set; }
        public string Titulo { get; set; }
        public decimal Precio { get; set; }
    }
}
