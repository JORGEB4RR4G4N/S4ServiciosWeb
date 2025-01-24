namespace S4.DAC.DataAcces.Jugadores;

public class JugadorDAC : IJugadorDAC
{
    private readonly Conexion _conexion;
    public JugadorDAC(Conexion ConnectionString)
    {
        _conexion = ConnectionString;
    }

    public async Task<bool> ActualizarJugador(Jugador jugador)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdJugador", jugador.IdJugador, DbType.Int32);
            parametros.Add("@NombreJugador", jugador.NombreJugador, DbType.String);
            parametros.Add("@PrimerApellido", jugador.PrimerApellido, DbType.String);
            parametros.Add("@Estatura", jugador.Estatura, DbType.Double);
            parametros.Add("@Peso", jugador.Peso, DbType.Int32);
            parametros.Add("@IdOrigen", jugador.IdOrigen, DbType.Int32);
            parametros.Add("@IdPosicion", jugador.IdPosicion, DbType.Int32);
            parametros.Add("@Numero", jugador.Numero, DbType.Int32);
            parametros.Add("@Habilitado", jugador.Habilitado, DbType.Boolean);
            parametros.Add("@FechaNacimiento", jugador.FechaNacimiento, DbType.Date);
            var Resultado = await conexion.ExecuteAsync("SP_JUGADOR_ED", parametros, commandType: CommandType.StoredProcedure);
            return Resultado > 0;
        }
    }

    public async Task<int> InsertarJugador(Jugador jugador)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@NombreJugador", jugador.NombreJugador, DbType.String);
            parametros.Add("@PrimerApellido", jugador.PrimerApellido, DbType.String);
            parametros.Add("@Estatura", jugador.Estatura, DbType.Double);
            parametros.Add("@Peso", jugador.Peso, DbType.Int32);
            parametros.Add("@IdOrigen", jugador.IdOrigen, DbType.Int32);
            parametros.Add("@IdPosicion", jugador.IdPosicion, DbType.Int32);
            parametros.Add("@Numero", jugador.Numero, DbType.Int32);
            parametros.Add("@FechaNacimiento", jugador.FechaNacimiento, DbType.Date);
            var Resultado = await conexion.ExecuteScalarAsync<int>("SP_JUGADOR_IN", parametros, commandType: CommandType.StoredProcedure);
            return Resultado;
        }
    }

    public async Task<List<JugadorDTO>> ListaJugador()
    {
        List<JugadorDTO> Lista = new List<JugadorDTO>();
        try
        {
            using (var conexion = _conexion.ObtieneConexion())
            {

                Lista = (await conexion.QueryAsync<JugadorDTO>("SP_JUGADOR_CT", commandType: CommandType.StoredProcedure)).ToList();
            }

            return Lista;
        }
        catch
        {
            return Lista;
            GC.Collect();
        }
    }

    public async Task<JugadorDTO> ObtieneJugador(int IdJugador)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdJugador", IdJugador, DbType.Int32);

            return await conexion.QueryFirstOrDefaultAsync<JugadorDTO>("SP_JUGADOR_CN", parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
