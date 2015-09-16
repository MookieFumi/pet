using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using pet.dal.Model.Entities.Carioca;

namespace pet.test
{
    public static class CariocaServiceTestHelper
    {
        public static IEnumerable<ResumenUbicacion> GetResumenUbicacion()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Carioca"].ConnectionString;
            IEnumerable<ResumenUbicacion> items;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                items = conn.Query<ResumenUbicacion>(@"SELECT TOP 100 PERCENT
                                                    dbo.Tiendas.Nombre AS Tienda,
                                                    dbo.Zonas.Nombre AS Zona,
                                                    dbo.Zonas.Descripcion AS ZonaDescripcion,
                                                    dbo.Zonas.Activado AS ZonaActivada,
                                                    dbo.ZonaMuebles.Nombre AS Contenedor,
                                                    dbo.ZonaMuebles.Descripcion AS ContenedorDescripcion,
                                                    dbo.ZonaMuebles.Activado AS ContenedorActivada,
                                                    dbo.Ubicaciones.Nombre AS Ubicacion,
                                                    dbo.Ubicaciones.Descripcion AS UbicacionDescripcion,
                                                    dbo.Ubicaciones.Activado AS UbicacionActivada
                                                FROM dbo.Tiendas
                                                INNER JOIN dbo.Zonas ON dbo.Tiendas.TiendaID = dbo.Zonas.TiendaID
                                                INNER JOIN dbo.ZonaMuebles ON dbo.Zonas.ZonaID = dbo.ZonaMuebles.ZonaID
                                                INNER JOIN dbo.Ubicaciones ON dbo.ZonaMuebles.ZonaMuebleID = dbo.Ubicaciones.ZonaMuebleID
                                                ORDER BY Tienda, Zona, Contenedor, Ubicacion");
                conn.Close();
            }
            return items;
        }

        public static IEnumerable<string> GetTiendasUnicas(IEnumerable<ResumenUbicacion> items)
        {
            return items.GroupBy(p => p.Tienda).Select(p => p.Key);
        }

        public static void FillZonas(IEnumerable<ResumenUbicacion> items, int empresaId, Tienda tienda)
        {
            var zonas = GetZonasUnicasPorTienda(items, tienda.Nombre);
            foreach (var zona in zonas)
            {
                var nuevaZona = new Zona
                {
                    Nombre = zona.Nombre,
                    Descripcion = zona.Descripcion,
                    Activada = zona.Activado,
                    EmpresaId = empresaId
                };
                FillContenedores(items, empresaId, tienda, nuevaZona);
                tienda.Zonas.Add(nuevaZona);
            }
        }

        private static void FillContenedores(IEnumerable<ResumenUbicacion> items, int empresaId, Tienda tienda, Zona zona)
        {
            var contenedores = GetContenedoresUnicos(items, tienda.Nombre, zona.Nombre);
            foreach (var contenedor in contenedores)
            {
                var nuevoContenedor = new Contenedor
                {
                    Nombre = contenedor.Nombre,
                    Descripcion = contenedor.Descripcion,
                    Activada = contenedor.Activado,
                    EmpresaId = empresaId
                };
                FillUbicaciones(items, empresaId, tienda, zona, nuevoContenedor);
                zona.Contenedores.Add(nuevoContenedor);
            }
        }

        private static void FillUbicaciones(IEnumerable<ResumenUbicacion> items, int empresaId, Tienda tienda, Zona zona, Contenedor contenedor)
        {
            var ubicaciones = GetUbicacionesUnicas(items, tienda.Nombre, zona.Nombre, contenedor.Nombre);
            foreach (var ubicacion in ubicaciones)
            {
                var nuevaUbicacion = new Ubicacion
                {
                    Nombre = ubicacion.Nombre,
                    Descripcion = ubicacion.Descripcion,
                    Activada = ubicacion.Activado,
                    EmpresaId = empresaId
                };
                contenedor.Ubicaciones.Add(nuevaUbicacion);
            }
        }

        private static IEnumerable<ElementoUnico> GetUbicacionesUnicas(IEnumerable<ResumenUbicacion> items, string tienda, string zona, string contenedor)
        {
            return items.Where(p => p.Tienda == tienda && p.Zona == zona && p.Contenedor == contenedor)
                .GroupBy(p => new { p.Ubicacion, Descripcion = p.UbicacionDescripcion, Activada = p.UbicacionActivada })
                .Select(p => new ElementoUnico(p.Key.Ubicacion, p.Key.Descripcion, p.Key.Activada));
        }

        private static IEnumerable<ElementoUnico> GetContenedoresUnicos(IEnumerable<ResumenUbicacion> items, string tienda, string zona)
        {
            return items.Where(p => p.Tienda == tienda && p.Zona == zona)
                .GroupBy(p => new { p.Contenedor, Descripcion = p.ContenedorDescripcion, Activada = p.ContenedorActivada })
                .Select(p => new ElementoUnico(p.Key.Contenedor, p.Key.Descripcion, p.Key.Activada));
        }

        private static IEnumerable<ElementoUnico> GetZonasUnicasPorTienda(IEnumerable<ResumenUbicacion> items, string tienda)
        {
            return items.Where(p => p.Tienda == tienda)
                .GroupBy(p => new { p.Zona, Descripcion = p.ZonaDescripcion, Activada = p.ZonaActivada })
                .Select(p => new ElementoUnico(p.Key.Zona, p.Key.Descripcion, p.Key.Activada));
        }

        private class ElementoUnico
        {
            public ElementoUnico(string nombre, string descripcion, bool activado)
            {
                Nombre = nombre;
                Descripcion = descripcion;
                Activado = activado;
            }

            public string Nombre { get; }
            public string Descripcion { get; }
            public bool Activado { get; }
        }

        public class ResumenUbicacion
        {
            public string Tienda { get; set; }
            public string Zona { get; set; }
            public string ZonaDescripcion { get; set; }
            public bool ZonaActivada { get; set; }
            public string Contenedor { get; set; }
            public string ContenedorDescripcion { get; set; }
            public bool ContenedorActivada { get; set; }
            public string Ubicacion { get; set; }
            public string UbicacionDescripcion { get; set; }
            public bool UbicacionActivada { get; set; }
        }
    }
}