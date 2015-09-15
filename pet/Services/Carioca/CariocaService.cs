using System;
using pet.dal.Model;
using pet.dal.Model.Entities.Carioca;
using System.Linq;
using System.Data.Entity;

namespace pet.dal.Services.Carioca
{
    public class CariocaService : ICariocaService
    {
        private readonly MeContext _context;

        public CariocaService(MeContext context)
        {
            _context = context;
        }

        public void AddZonaTipo(ZonaTipo zonaTipo)
        {
            if (Exists<ZonaTipo>(zonaTipo.EmpresaId, zonaTipo.Codigo))
            {
                throw new ApplicationException("Ya existe un tipo de zona con el código indicado");
            }

            _context.ZonaTipos.Add(zonaTipo);
            _context.SaveChanges();
        }

        public void UpdateZonaTipo(ZonaTipo zonaTipo)
        {
            _context.ZonaTipos.Attach(zonaTipo);
            _context.Entry(zonaTipo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveZonaTipo(int zonaTipoId)
        {
            var zonaTipo = GetZonaTipo(zonaTipoId);
            _context.ZonaTipos.Remove(zonaTipo);
            _context.SaveChanges();
        }

        public ZonaTipo GetZonaTipo(int zonaTipoId)
        {
            return _context.ZonaTipos.Find(zonaTipoId);
        }

        public void AddContenedorTipo(ContenedorTipo contenedorTipo)
        {
            if (Exists<ContenedorTipo>(contenedorTipo.EmpresaId, contenedorTipo.Codigo))
            {
                throw new ApplicationException("Ya existe un tipo de contenedor con el código indicado");
            }

            _context.ContenedorTipos.Add(contenedorTipo);
            _context.SaveChanges();
        }

        public void UpdateContenedorTipo(ContenedorTipo contenedorTipo)
        {
            _context.ContenedorTipos.Attach(contenedorTipo);
            _context.Entry(contenedorTipo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveContenedorTipo(int contenedorTipoId)
        {
            var contenedorTipo = GetContenedorTipo(contenedorTipoId);
            _context.ContenedorTipos.Remove(contenedorTipo);
            _context.SaveChanges();
        }

        public ContenedorTipo GetContenedorTipo(int contenedorTipoId)
        {
            return _context.ContenedorTipos.Find(contenedorTipoId);
        }

        public void AddUbicacionTipo(UbicacionTipo ubicacionTipo)
        {
            if (Exists<UbicacionTipo>(ubicacionTipo.EmpresaId, ubicacionTipo.Codigo))
            {
                throw new ApplicationException("Ya existe un tipo de ubicacion con el código indicado");
            }

            _context.UbicacionTipos.Add(ubicacionTipo);
            _context.SaveChanges();
        }

        public void UpdateUbicacionTipo(UbicacionTipo ubicacionTipo)
        {
            _context.UbicacionTipos.Attach(ubicacionTipo);
            _context.Entry(ubicacionTipo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveUbicacionTipo(int ubicacionTipoId)
        {
            var ubicacionTipo = GetUbicacionTipo(ubicacionTipoId);
            _context.UbicacionTipos.Remove(ubicacionTipo);
            _context.SaveChanges();
        }

        public UbicacionTipo GetUbicacionTipo(int ubicacionTipoId)
        {
            return _context.UbicacionTipos.Find(ubicacionTipoId);
        }

        private bool Exists<T>(int empresaId, string codigo) where T : class, ICariocaTipo
        {
            return _context.Set<T>().Any(p => p.EmpresaId == empresaId && p.Codigo == codigo);
        }
    }
}