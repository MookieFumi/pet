namespace pet.dal.Model.Entities.Carioca
{
    public class Ubicacion
    {
        public virtual int UbicacionId { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual bool Activada { get; set; }

        public virtual int? UbicacionTipoId { get; set; }
        public virtual UbicacionTipo UbicacionTipo { get; set; }

        public virtual int ContenedorId { get; set; }
        public virtual Contenedor Contenedor { get; set; }
    }
}