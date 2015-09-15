using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace pet.dal.Model.Entities.Carioca
{
    public class Zona
    {
        public Zona()
        {
            Contenedores = new Collection<Contenedor>();
        }

        public virtual int ZonaId { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual bool Activada { get; set; }

        public virtual int? ZonaTipoId { get; set; }
        public virtual ZonaTipo ZonaTipo { get; set; }

        public virtual int TiendaId { get; set; }
        public virtual Tienda Tienda { get; set; }

        public virtual ICollection<Contenedor> Contenedores { get; set; }
    }
}