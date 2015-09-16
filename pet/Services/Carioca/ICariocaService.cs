using pet.dal.Model.Entities.Carioca;

namespace pet.dal.Services.Carioca
{
    public interface ICariocaService
    {
        void AddUbicacion(Ubicacion ubicacion);
        void UpdateUbicacion(Ubicacion ubicacion);
        void RemoveUbicacion(int ubicacionId);
        Ubicacion GetUbicacion(int ubicacionId);
        void AddContenedor(Contenedor contenedor);
        void UpdateContenedor(Contenedor contenedor);
        void RemoveContenedor(int contenedorId);
        Contenedor GetContenedor(int contenedorId);
        void AddZona(Zona zona);
        void UpdateZona(Zona zona);
        void RemoveZona(int zonaId);
        Zona GetZona(int zonaId);
        void AddTipoZona(TipoZona tipoZona);
        void UpdateTipoZona(TipoZona tipoZona);
        void RemoveTipoZona(int tipoZonaId);
        TipoZona GetTipoZona(int tipoZonaId);
        void AddTipoContenedor(TipoContenedor tipoContenedor);
        void UpdateTipoContenedor(TipoContenedor tipoContenedor);
        void RemoveTipoContenedor(int tipoContenedorId);
        TipoContenedor GetTipoContenedor(int tipoContenedorId);
        void AddTipoUbicacion(TipoUbicacion tipoUbicacion);
        void UpdateTipoUbicacion(TipoUbicacion tipoUbicacion);
        void RemoveTipoUbicacion(int tipoUbicacionId);
        TipoUbicacion GetTipoUbicacion(int tipoUbicacionId);
    }
}