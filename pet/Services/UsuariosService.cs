using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using pet.dal.Model;
using pet.dal.Model.Entities;
using pet.dal.Services.DTO;

namespace pet.dal.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly MeContext _context;

        public UsuariosService(MeContext context)
        {
            _context = context;
            AutoMapper.Mapper.CreateMap<Usuario, UsuarioEmpresa>()
                .ForMember(dst => dst.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId))
                .ForMember(dst => dst.Usuario, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dst => dst.Empresa, opt => opt.MapFrom(src => src.Empresa.Nombre));
        }

        public UsuarioEmpresa GetUsuario(int usuarioId)
        {
            return
                AutoMapper.Mapper.Map<Usuario, UsuarioEmpresa>(
                    _context.Usuarios.SingleOrDefault(p => p.UsuarioId == usuarioId));
        }

        public IList<UsuarioEmpresa> GetUsuarios()
        {


            return _context.Usuarios
                .Project()
                .To<UsuarioEmpresa>()
                .ToList();
        }
    }
}