using System;

namespace pet.dal.Model.Entities
{
    public class Usuario
    {
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
