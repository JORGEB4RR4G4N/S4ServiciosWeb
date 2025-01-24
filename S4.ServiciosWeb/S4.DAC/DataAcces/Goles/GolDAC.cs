namespace S4.DAC.DataAcces.Goles;

public class GolDAC : IGolDAC
{
    private readonly Conexion _conexion;
    public GolDAC(Conexion ConnectionString)
    {
        _conexion = ConnectionString;
    }

    public async Task<bool> ActualizarGol(Gol gol)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdGol", gol.IdGol, DbType.Int32);
            parametros.Add("@IdPartido", gol.IdPartido, DbType.Int32);
            parametros.Add("@IdPlantel", gol.IdPlantel, DbType.Int32);
            parametros.Add("@IdJugador", gol.IdJugador, DbType.Int32);
            parametros.Add("@IdTipoGol", gol.IdTipoGol, DbType.Int32);
            parametros.Add("@Habilitado", gol.Habilitado, DbType.Boolean);
            var Resultado = await conexion.ExecuteAsync("SP_GOL_ED", parametros, commandType: CommandType.StoredProcedure);
            return Resultado > 0;
        }
    }

    public async Task<int> InsertarGol(Gol gol)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdPartido", gol.IdPartido, DbType.Int32);
            parametros.Add("@IdPlantel", gol.IdPlantel, DbType.Int32);
            parametros.Add("@IdJugador", gol.IdJugador, DbType.Int32);
            parametros.Add("@IdTipoGol", gol.IdTipoGol, DbType.Int32);
            var Resultado = await conexion.ExecuteScalarAsync<int>("SP_GOL_IN", parametros, commandType: CommandType.StoredProcedure);
            return Resultado;
        }
    }

    public async Task<List<Gol>> ListaGol()
    {
        List<Gol> Lista = new List<Gol>();
        try
        {
            using (var conexion = _conexion.ObtieneConexion())
            {

                Lista = (await conexion.QueryAsync<Gol>("SP_GOL_CT", commandType: CommandType.StoredProcedure)).ToList();
            }

            return Lista;
        }
        catch
        {
            return Lista;
            GC.Collect();
        }
    }

    public async Task<Gol> ObtieneGol(int IdGol)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdGol", IdGol, DbType.Int32);

            return await conexion.QueryFirstOrDefaultAsync<Gol>("SP_GOL_CN", parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
