namespace S4.DAC.DataAcces.Faltas;

public class FaltasDAC : IFaltasDAC
{
    private readonly Conexion _conexion;
    public FaltasDAC(Conexion ConnectionString)
    {
        _conexion = ConnectionString;
    }

    public async Task<bool> ActualizarFalta(Falta falta)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdPartido", falta.IdPartido, DbType.Int32);
            parametros.Add("@IdPlantel", falta.IdPlantel, DbType.Int32);
            parametros.Add("@IdJugador", falta.IdJugador, DbType.Int32);
            parametros.Add("@IdTipoFalta", falta.IdTipoFalta, DbType.Int32);
            parametros.Add("@Habilitado", falta.Habilitado, DbType.Boolean);
            var Resultado = await conexion.ExecuteAsync("SP_FALTA_ED", parametros, commandType: CommandType.StoredProcedure);
            return Resultado > 0;
        }
    }

    public async Task<int> InsertarFalta(Falta falta)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdPartido", falta.IdPartido, DbType.Int32);
            parametros.Add("@IdPlantel", falta.IdPlantel, DbType.Int32);
            parametros.Add("@IdJugador", falta.IdJugador, DbType.Int32);
            parametros.Add("@IdTipoFalta", falta.IdTipoFalta, DbType.Int32);
            var Resultado = await conexion.ExecuteScalarAsync<int>("SP_FALTA_IN", parametros, commandType: CommandType.StoredProcedure);
            return Resultado;
        }
    }

    public async Task<List<FaltaDTO>> ListaFalta()
    {
        List<FaltaDTO> Lista = new List<FaltaDTO>();
        try
        {
            using (var conexion = _conexion.ObtieneConexion())
            {

                Lista = (await conexion.QueryAsync<FaltaDTO>("SP_FALTA_CT", commandType: CommandType.StoredProcedure)).ToList();
            }

            return Lista;
        }
        catch
        {
            return Lista;
            GC.Collect();
        }
    }

    public async Task<FaltaDTO> ObtieneFalta(int Idfalta)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@Idfalta", Idfalta, DbType.Int32);

            return await conexion.QueryFirstOrDefaultAsync<FaltaDTO>("SP_FALTA_CN", parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
