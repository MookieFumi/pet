namespace pet.dal.Model.Entities.Carioca
{
    public class TipoUbicacion
    {
        public virtual int TipoUbicacionId { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Descripcion { get; set; }

        public virtual int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}