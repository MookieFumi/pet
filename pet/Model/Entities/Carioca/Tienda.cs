using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace pet.dal.Model.Entities.Carioca
{
    public class Tienda
    {
        public Tienda()
        {
            Zonas = new Collection<Zona>();
        }

        public virtual int TiendaId { get; set; }
        public virtual string Nombre { get; set; }

        public virtual int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<Zona> Zonas { get; set; }
    }
}