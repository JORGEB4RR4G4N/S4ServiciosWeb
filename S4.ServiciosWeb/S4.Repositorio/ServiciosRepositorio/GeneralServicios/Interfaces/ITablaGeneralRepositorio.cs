namespace S4.Repositorio.ServiciosRepositorio.GeneralServicios.Interfaces;

public interface ITablaGeneralRepositorio
{
    Task<List<TablaGeneralDTO>> listaTablaGeneral();
    Task<TablaGeneralDTO> ObtieneTablaGeneral(int IdTablaGeneral);
    Task<TablaGeneralDTO> InsertaTablaGeneral(TablaGeneral tablaGeneral);
    Task<TablaGeneralDTO> ActualizaTablaGeneral(TablaGeneral tablaGeneral);
}
