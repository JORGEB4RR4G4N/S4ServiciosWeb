namespace S4.Repositorio.ServiciosRepositorio.CatalogosServicios;

public class PosicionRepositorio : IPosicionRepositorio
{
    private readonly IPosicionDAC _posicionDAC;
    public PosicionRepositorio(IPosicionDAC posicionDAC)
    {
        _posicionDAC = posicionDAC;
    }

    public async Task<Posicion> ActualizaPosicion(Posicion posicion)
    {
        var ActualizaPosicion = await _posicionDAC.ActualizarPosicion(posicion);
        if (ActualizaPosicion)
        {
            var InformacionPosicionActualizado = await _posicionDAC.ObtienePosicion(posicion.IdPosicion);
            return InformacionPosicionActualizado;
        }
        else
            return new Posicion();
    }

    public async Task<Posicion> InsertaPosicion(Posicion posicion)
    {
        Posicion posicionInsertado = new Posicion();
        var InsertaPosicion = await _posicionDAC.InsertarPosicion(posicion);
        if (InsertaPosicion > 0)
            posicionInsertado = await _posicionDAC.ObtienePosicion(InsertaPosicion);
        else
            posicionInsertado = new Posicion();

        return posicionInsertado;
    }

    public async Task<List<Posicion>> ListaPosiciones()
    {
        var obtieneListaPosicion = await _posicionDAC.ListaPosicion();
        return obtieneListaPosicion;
    }

    public async Task<Posicion> ObtienePosicion(int IdPosicion)
    {
        var obtienePosicion = await _posicionDAC.ObtienePosicion(IdPosicion);
        return obtienePosicion;
    }
}
