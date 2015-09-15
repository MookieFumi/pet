using pet.dal.Model.Entities.Carioca;

namespace pet.dal.Services.Carioca
{
    public interface ICariocaService
    {
        void AddZonaTipo(ZonaTipo zonaTipo);
        void UpdateZonaTipo(ZonaTipo zonaTipo);
        void RemoveZonaTipo(int zonaTipoId);
        ZonaTipo GetZonaTipo(int zonaTipoId);
        void AddContenedorTipo(ContenedorTipo contenedorTipo);
        void UpdateContenedorTipo(ContenedorTipo contenedorTipo);
        void RemoveContenedorTipo(int contenedorTipoId);
        ContenedorTipo GetContenedorTipo(int contenedorTipoId);
        void AddUbicacionTipo(UbicacionTipo ubicacionTipo);
        void UpdateUbicacionTipo(UbicacionTipo ubicacionTipo);
        void RemoveUbicacionTipo(int ubicacionTipoId);
        UbicacionTipo GetUbicacionTipo(int ubicacionTipoId);
    }
}
