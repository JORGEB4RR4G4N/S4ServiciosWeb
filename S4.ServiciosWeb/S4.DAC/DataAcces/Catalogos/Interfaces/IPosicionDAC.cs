namespace S4.DAC.DataAcces.Catalogos.Interfaces;

public interface IPosicionDAC
{
    Task<int> InsertarPosicion(Posicion posicion);
    Task<bool> ActualizarPosicion(Posicion posicion);
    Task<List<Posicion>> ListaPosicion();
    Task<Posicion> ObtienePosicion(int IdPosicion);
}
