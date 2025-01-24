namespace S4.Repositorio.ServiciosRepositorio.GeneralServicios;
public class TablaGeneralRepositorio : ITablaGeneralRepositorio
{
    private readonly ITablaGeneralDAC _tablaGeneralDAC;
    public TablaGeneralRepositorio(ITablaGeneralDAC tablaGeneralDAC)
    {
        _tablaGeneralDAC = tablaGeneralDAC;
    }
    public async Task<TablaGeneralDTO> ActualizaTablaGeneral(TablaGeneral tablaGeneral)
    {
        var ActualizaTablaGeneral = await _tablaGeneralDAC.ActualizaTablaGeneralResultados(tablaGeneral);
        if (ActualizaTablaGeneral)
        {
            var InformacionTablaGeneralActualizado = await _tablaGeneralDAC.ObtieneTablaGeneral(tablaGeneral.IdTablaGeneral);
            return InformacionTablaGeneralActualizado;
        }
        else
            return new TablaGeneralDTO();
    }

    public async Task<TablaGeneralDTO> InsertaTablaGeneral(TablaGeneral tablaGeneral)
    {
        TablaGeneralDTO tablaGeneralInsertado = new TablaGeneralDTO();
        var InsertaTablaGeneral = await _tablaGeneralDAC.InsertaTablaGeneral(tablaGeneral);
        if (InsertaTablaGeneral > 0)
            tablaGeneralInsertado = await _tablaGeneralDAC.ObtieneTablaGeneral(InsertaTablaGeneral);
        else
            tablaGeneralInsertado = new TablaGeneralDTO();

        return tablaGeneralInsertado;
    }

    public async Task<List<TablaGeneralDTO>> listaTablaGeneral()
    {
        var obtieneListaTablaGeneral = await _tablaGeneralDAC.ListaTablaGeneral();
        return obtieneListaTablaGeneral;
    }

    public async Task<TablaGeneralDTO> ObtieneTablaGeneral(int IdTablaGeneral)
    {
        var obtieneTablaGeneral = await _tablaGeneralDAC.ObtieneTablaGeneral(IdTablaGeneral);
        return obtieneTablaGeneral;
    }
}
