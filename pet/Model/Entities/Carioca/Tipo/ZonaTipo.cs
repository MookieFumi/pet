using System.ComponentModel.DataAnnotations.Schema;

namespace pet.dal.Model.Entities.Carioca
{
    public class ZonaTipo: ICariocaTipo
    {
        public virtual int ZonaTipoId { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Descripcion { get; set; }

        public virtual int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
