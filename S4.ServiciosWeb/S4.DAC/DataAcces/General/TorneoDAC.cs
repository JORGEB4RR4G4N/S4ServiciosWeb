namespace S4.DAC.DataAcces.General;

public class TorneoDAC : ITorneoDAC
{
    private readonly Conexion _conexion;
    public TorneoDAC(Conexion ConnectionString)
    {
        _conexion = ConnectionString;
    }
    public async Task<bool> ActualizaTorneo(Torneo torneo)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdTorneo", torneo.IdTorneo, DbType.Int32);
            parametros.Add("@DescripcionTorneo", torneo.DescripcionTorneo, DbType.String);
            parametros.Add("@Temporada", torneo.Temporada, DbType.String);
            parametros.Add("@InicioTorneo", torneo.InicioTorneo, DbType.Date);
            parametros.Add("@FinTorneo", torneo.FinTorneo, DbType.Date);
            parametros.Add("@Habilitado", torneo.Habilitado, DbType.Boolean);
            var Resultado = await conexion.ExecuteAsync("SP_TORNEO_ED", parametros, commandType: CommandType.StoredProcedure);
            return Resultado > 0;
        }
    }

    public async Task<int> InsertaTorneo(Torneo torneo)
    {

        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@DescripcionTorneo", torneo.DescripcionTorneo, DbType.String);
            parametros.Add("@Temporada", torneo.Temporada, DbType.String);
            parametros.Add("@InicioTorneo", torneo.InicioTorneo, DbType.Date);
            parametros.Add("@FinTorneo", torneo.FinTorneo, DbType.Date);
            var Resultado = await conexion.ExecuteScalarAsync<int>("SP_TORNEO_IN", parametros, commandType: CommandType.StoredProcedure);
            return Resultado;
        }
    }

    public async Task<Torneo> ObtieneTorneo(int IdTorneo)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdTorneo", IdTorneo, DbType.Int32);

            return await conexion.QueryFirstOrDefaultAsync<Torneo>("SP_TORNEO_CN", parametros, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<List<Torneo>> ObtieneTorneos()
    {
        List<Torneo> ListaTorneo = new List<Torneo>();
        try
        {
            using (var conexion = _conexion.ObtieneConexion())
            {

                ListaTorneo = (await conexion.QueryAsync<Torneo>("SP_TORNEO_CT", commandType: CommandType.StoredProcedure)).ToList();
            }

            return ListaTorneo;
        }
        catch
        {
            return ListaTorneo;
            GC.Collect();
        }
    }
}
