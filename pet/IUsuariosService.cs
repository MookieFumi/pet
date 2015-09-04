using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using kk.Model;
using kk.Model.Entities;

namespace kk
{
    public interface IUsuariosService
    {
        IList<UsuarioEmpresa> GetUsuarios();
    }

    public class UsuariosService : IUsuariosService
    {
        private readonly MeContext _context;

        public UsuariosService(MeContext context)
        {
            _context = context;
        }

        public IList<UsuarioEmpresa> GetUsuarios()
        {
            AutoMapper.Mapper.CreateMap<Usuario, UsuarioEmpresa>()
                .ForMember(dst => dst.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId))
                .ForMember(dst => dst.Usuario, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dst=>dst.Empresa, opt=>opt.MapFrom(src=>src.Empresa.Nombre));

            return _context.Usuarios
                .Project()
                .To<UsuarioEmpresa>()
                .ToList();
        }
    }

    public class UsuarioEmpresa
    {
        public string Empresa { get; set; }
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
    }
}
