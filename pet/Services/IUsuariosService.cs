using System.Collections.Generic;
using pet.dal.Services.DTO;

namespace pet.dal.Services
{
    public interface IUsuariosService
    {
        IList<UsuarioEmpresa> GetUsuarios();
        UsuarioEmpresa GetUsuario(int usuarioId);
    }
}
