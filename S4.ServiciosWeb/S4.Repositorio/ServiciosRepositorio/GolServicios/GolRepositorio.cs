namespace S4.Repositorio.ServiciosRepositorio.GolServicios;

public class GolRepositorio : IGolRepositorio
{
    public IGolDAC _golDAC;
    public GolRepositorio(IGolDAC golDAC)
    {
        _golDAC = golDAC;
    }

    public async Task<Gol> ActualizaGol(Gol gol)
    {
        var ActualizaGol = await _golDAC.ActualizarGol(gol);
        if (ActualizaGol)
        {
            var InformacionGolActualizado = await _golDAC.ObtieneGol(gol.IdGol);
            return InformacionGolActualizado;
        }
        else
            return new Gol();
    }

    public async Task<Gol> InsertaGol(Gol gol)
    {
        Gol golInsertado = new Gol();
        var InsertaGol = await _golDAC.InsertarGol(gol);
        if (InsertaGol > 0)
            golInsertado = await _golDAC.ObtieneGol(InsertaGol);
        else
            golInsertado = new Gol();

        return golInsertado;
    }

    public async Task<Gol> ObtieneGol(int IdGol)
    {
        var obtieneGol = await _golDAC.ObtieneGol(IdGol);
        return obtieneGol;
    }

    public async Task<List<Gol>> ObtienelistaGol()
    {
        var obtieneListaGol = await _golDAC.ListaGol();
        return obtieneListaGol;
    }
}
