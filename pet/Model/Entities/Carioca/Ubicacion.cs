namespace pet.dal.Model.Entities.Carioca
{
    public class Ubicacion
    {
        public virtual int UbicacionId { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual bool Activada { get; set; }

        public virtual int? TipoUbicacionId { get; set; }
        public virtual TipoUbicacion Tipo { get; set; }

        public virtual int EmpresaId { get; set; }

        public virtual int ContenedorId { get; set; }
        public virtual Contenedor Contenedor { get; set; }
    }
}