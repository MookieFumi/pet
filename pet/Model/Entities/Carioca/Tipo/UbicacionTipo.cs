namespace pet.dal.Model.Entities.Carioca
{
    public class UbicacionTipo : ICariocaTipo
    {
        public virtual int UbicacionTipoId { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Descripcion { get; set; }

        public virtual int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}