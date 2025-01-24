namespace S4.Repositorio.ServiciosRepositorio.CatalogosServicios;

public class OrigenRepositorio : IOrigenRepositorio
{
    private readonly IOrigenDAC _origenDAC;
    public OrigenRepositorio(IOrigenDAC origenDAC)
    {
        _origenDAC = origenDAC;
    }

    public async Task<Origen> ActualizaOrigen(Origen origen)
    {
        var ActualizaOrigen = await _origenDAC.ActualizarOrigen(origen);
        if (ActualizaOrigen)
        {
            var InformacionOrigenActualizado = await _origenDAC.ObtenOrigen(origen.IdOrigen);
            return InformacionOrigenActualizado;
        }
        else
            return new Origen();
    }

    public async Task<Origen> InsertaOrigen(Origen origen)
    {
        Origen oorigenInsertado = new Origen();
        var InsertaOrigen = await _origenDAC.InsertarOrigen(origen);
        if (InsertaOrigen > 0)
            oorigenInsertado = await _origenDAC.ObtenOrigen(InsertaOrigen);
        else
            oorigenInsertado = new Origen();

        return oorigenInsertado;
    }

    public async Task<List<Origen>> listaOrigen()
    {
        var obtieneListaPosicion = await _origenDAC.ListaOrigen();
        return obtieneListaPosicion;
    }

    public async Task<Origen> ObtieneOrigen(int IdOrigen)
    {
        var obtienePosicion = await _origenDAC.ObtenOrigen(IdOrigen);
        return obtienePosicion;
    }
}
