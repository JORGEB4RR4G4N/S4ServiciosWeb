namespace S4.DAC.DataAcces.General.Interfaces;

public interface ITablaGeneralDAC
{
    Task<List<TablaGeneralDTO>> ListaTablaGeneral();
    Task<TablaGeneralDTO> ObtieneTablaGeneral(int IdTablaGeneral);
    Task<int> InsertaTablaGeneral(TablaGeneral tablaGeneral);
    Task<bool> ActualizaTablaGeneralGolesPuntos(TablaGeneral tablaGeneral);
    Task<bool> ActualizaTablaGeneralResultados(TablaGeneral tablaGeneral);
}
