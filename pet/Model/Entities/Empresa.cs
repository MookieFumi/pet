using System.Collections;
using System.Collections.Generic;

namespace kk.Model.Entities
{
    public class Empresa
    {
        public Empresa()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int EmpresaId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}