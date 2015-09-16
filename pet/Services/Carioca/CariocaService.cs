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

        public void AddUbicacion(Ubicacion ubicacion)
        {
            if (ExistsUbicacion(ubicacion.ContenedorId, ubicacion.Nombre))
            {
                throw new ApplicationException("Ya existe una ubicación con el nombre indicado");
            }

            ubicacion.Activada = true;
            _context.Ubicaciones.Add(ubicacion);
            _context.SaveChanges();
        }

        public void UpdateUbicacion(Ubicacion ubicacion)
        {
            if (ExistsUbicacion(ubicacion.ContenedorId, ubicacion.Nombre, ubicacion.UbicacionId))
            {
                throw new ApplicationException("Ya existe una ubicacion con el nombre indicado");
            }

            _context.Ubicaciones.Attach(ubicacion);
            _context.Entry(ubicacion).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveUbicacion(int ubicacionId)
        {
            var ubicacion = GetUbicacion(ubicacionId);
            _context.Ubicaciones.Remove(ubicacion);
            _context.SaveChanges();
        }

        public Ubicacion GetUbicacion(int ubicacionId)
        {
            return _context.Ubicaciones.Find(ubicacionId);
        }

        public void AddContenedor(Contenedor contenedor)
        {
            if (ExistsContenedor(contenedor.ZonaId, contenedor.Nombre))
            {
                throw new ApplicationException("Ya existe un ubicacion con el nombre indicado");
            }

            contenedor.Activada = true;
            _context.Contenedores.Add(contenedor);
            _context.SaveChanges();
        }

        public void UpdateContenedor(Contenedor contenedor)
        {
            if (ExistsContenedor(contenedor.ZonaId, contenedor.Nombre, contenedor.ContenedorId))
            {
                throw new ApplicationException("Ya existe un ubicacion con el nombre indicado");
            }

            _context.Contenedores.Attach(contenedor);
            _context.Entry(contenedor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveContenedor(int contenedorId)
        {
            var contenedor = GetContenedor(contenedorId);
            _context.Contenedores.Remove(contenedor);
            _context.SaveChanges();
        }

        public Contenedor GetContenedor(int contenedorId)
        {
            return _context.Contenedores.Find(contenedorId);
        }

        public void AddZona(Zona zona)
        {
            if (ExistsZona(zona.TiendaId, zona.Nombre))
            {
                throw new ApplicationException("Ya existe una ubicacion con el nombre indicado");
            }

            zona.Activada = true;
            _context.Zonas.Add(zona);
            _context.SaveChanges();
        }

        public void UpdateZona(Zona zona)
        {
            if (ExistsZona(zona.TiendaId, zona.Nombre, zona.ZonaId))
            {
                throw new ApplicationException("Ya existe una ubicacion con el nombre indicado");
            }

            _context.Zonas.Attach(zona);
            _context.Entry(zona).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveZona(int zonaId)
        {
            var zona = GetZona(zonaId);
            _context.Zonas.Remove(zona);
            _context.SaveChanges();
        }

        public Zona GetZona(int zonaId)
        {
            return _context.Zonas.Find(zonaId);
        }

        public void AddTipoZona(TipoZona tipoZona)
        {
            if (ExistsTipoZona(tipoZona.EmpresaId, tipoZona.Codigo))
            {
                throw new ApplicationException("Ya existe un tipo de ubicacion con el código indicado");
            }

            _context.TiposZona.Add(tipoZona);
            _context.SaveChanges();
        }

        public void UpdateTipoZona(TipoZona tipoZona)
        {
            if (ExistsTipoZona(tipoZona.EmpresaId, tipoZona.Codigo, tipoZona.TipoZonaId))
            {
                throw new ApplicationException("Ya existe un tipo de ubicacion con el código indicado");
            }

            _context.TiposZona.Attach(tipoZona);
            _context.Entry(tipoZona).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveTipoZona(int tipoZonaId)
        {
            var zonaTipo = GetTipoZona(tipoZonaId);
            _context.TiposZona.Remove(zonaTipo);
            _context.SaveChanges();
        }

        public TipoZona GetTipoZona(int tipoZonaId)
        {
            return _context.TiposZona.Find(tipoZonaId);
        }

        public void AddTipoContenedor(TipoContenedor tipoContenedor)
        {
            if (ExistsTipoContenedor(tipoContenedor.EmpresaId, tipoContenedor.Codigo))
            {
                throw new ApplicationException("Ya existe un tipo de ubicacion con el código indicado");
            }

            _context.TiposContenedor.Add(tipoContenedor);
            _context.SaveChanges();
        }

        public void UpdateTipoContenedor(TipoContenedor tipoContenedor)
        {
            if (ExistsTipoContenedor(tipoContenedor.EmpresaId, tipoContenedor.Codigo, tipoContenedor.TipoContenedorId))
            {
                throw new ApplicationException("Ya existe un tipo de ubicacion con el código indicado");
            }

            _context.TiposContenedor.Attach(tipoContenedor);
            _context.Entry(tipoContenedor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveTipoContenedor(int tipoContenedorId)
        {
            var contenedorTipo = GetTipoContenedor(tipoContenedorId);
            _context.TiposContenedor.Remove(contenedorTipo);
            _context.SaveChanges();
        }

        public TipoContenedor GetTipoContenedor(int tipoContenedorId)
        {
            return _context.TiposContenedor.Find(tipoContenedorId);
        }

        public void AddTipoUbicacion(TipoUbicacion tipoUbicacion)
        {
            if (ExistsTipoUbicacion(tipoUbicacion.EmpresaId, tipoUbicacion.Codigo))
            {
                throw new ApplicationException("Ya existe un tipo de ubicacion con el código indicado");
            }

            _context.TiposUbicacion.Add(tipoUbicacion);
            _context.SaveChanges();
        }

        public void UpdateTipoUbicacion(TipoUbicacion tipoUbicacion)
        {
            if (ExistsTipoUbicacion(tipoUbicacion.EmpresaId, tipoUbicacion.Codigo, tipoUbicacion.TipoUbicacionId))
            {
                throw new ApplicationException("Ya existe un tipo de ubicacion con el código indicado");
            }

            _context.TiposUbicacion.Attach(tipoUbicacion);
            _context.Entry(tipoUbicacion).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveTipoUbicacion(int tipoUbicacionId)
        {
            var ubicacionTipo = GetTipoUbicacion(tipoUbicacionId);
            _context.TiposUbicacion.Remove(ubicacionTipo);
            _context.SaveChanges();
        }

        public TipoUbicacion GetTipoUbicacion(int tipoUbicacionId)
        {
            return _context.TiposUbicacion.Find(tipoUbicacionId);
        }

        private bool ExistsUbicacion(int contenedorId, string nombre, int? ubicacionId = null)
        {
            if (ubicacionId.HasValue)
            {
                return _context.Ubicaciones.Any(p => p.ContenedorId == contenedorId && p.Nombre == nombre && p.UbicacionId != ubicacionId);
            }
            return _context.Ubicaciones.Any(p => p.ContenedorId == contenedorId && p.Nombre == nombre);
        }

        private bool ExistsContenedor(int zonaId, string nombre, int? contenedorId = null)
        {
            if (contenedorId.HasValue)
            {
                return _context.Contenedores.Any(p => p.ZonaId == zonaId && p.Nombre == nombre && p.ContenedorId != contenedorId);
            }
            return _context.Contenedores.Any(p => p.ZonaId == zonaId && p.Nombre == nombre);
        }

        private bool ExistsTipoZona(int empresaId, string codigo, int? tipoZonaId = null)
        {
            if (tipoZonaId.HasValue)
            {
                return _context.TiposZona.Any(p => p.EmpresaId == empresaId && p.Codigo == codigo && p.TipoZonaId != tipoZonaId);
            }
            return _context.TiposZona.Any(p => p.EmpresaId == empresaId && p.Codigo == codigo);
        }

        private bool ExistsTipoContenedor(int empresaId, string codigo, int? tipoContenedorId = null)
        {
            if (tipoContenedorId.HasValue)
            {
                return _context.TiposContenedor.Any(p => p.EmpresaId == empresaId && p.Codigo == codigo && p.TipoContenedorId != tipoContenedorId);
            }
            return _context.TiposContenedor.Any(p => p.EmpresaId == empresaId && p.Codigo == codigo);
        }

        private bool ExistsTipoUbicacion(int empresaId, string codigo, int? tipoUbicacionId = null)
        {
            if (tipoUbicacionId.HasValue)
            {
                return _context.TiposUbicacion.Any(p => p.EmpresaId == empresaId && p.Codigo == codigo && p.TipoUbicacionId != tipoUbicacionId);
            }
            return _context.TiposUbicacion.Any(p => p.EmpresaId == empresaId && p.Codigo == codigo);
        }

        private bool ExistsZona(int tiendaId, string nombre, int? zonaId = null)
        {
            if (zonaId.HasValue)
            {
                return _context.Zonas.Any(p => p.TiendaId == tiendaId && p.Nombre == nombre && p.ZonaId != zonaId);
            }
            return _context.Zonas.Any(p => p.TiendaId == tiendaId && p.Nombre == nombre);
        }
    }
}