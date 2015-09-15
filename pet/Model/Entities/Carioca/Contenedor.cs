using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace pet.dal.Model.Entities.Carioca
{
    public class Contenedor
    {
        public Contenedor()
        {
        Ubicaciones = new Collection<Ubicacion>();    
        }

        public virtual int ContenedorId { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual bool Activada { get; set; }

        public virtual int? ContenedorTipoId { get; set; }
        public virtual ContenedorTipo ContenedorTipo { get; set; }

        public virtual int ZonaId { get; set; }
        public virtual Zona Zona { get; set; }

        public virtual ICollection<Ubicacion> Ubicaciones { get; set; }
    }
}