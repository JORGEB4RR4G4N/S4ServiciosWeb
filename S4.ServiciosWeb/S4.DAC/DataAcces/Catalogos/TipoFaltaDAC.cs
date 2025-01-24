namespace S4.DAC.DataAcces.Catalogos;

public class TipoFaltaDAC : ITipoFaltaDAC
{
    private readonly Conexion _conexion;
    public TipoFaltaDAC(Conexion ConnectionString)
    {
        _conexion = ConnectionString;
    }

    public async Task<bool> ActualizarTipoFalta(TipoFalta tipoFalta)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdTipoFalta", tipoFalta.IdTipoFalta, DbType.Int32);
            parametros.Add("@DescripcionFalta", tipoFalta.DescripcionFalta, DbType.String);
            parametros.Add("@Habilitado", tipoFalta.Habilitado, DbType.Boolean);
            var Resultado = await conexion.ExecuteAsync("SP_TIPO_FALTA_ED", parametros, commandType: CommandType.StoredProcedure);
            return Resultado > 0;
        }
    }

    public async Task<int> InsertarTipoFalta(TipoFalta tipoFalta)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@DescripcionFalta", tipoFalta.DescripcionFalta, DbType.String);
            var Resultado = await conexion.ExecuteScalarAsync<int>("SP_TIPO_FALTA_IN", parametros, commandType: CommandType.StoredProcedure);
            return Resultado;
        }
    }

    public async Task<List<TipoFalta>> ListaTipoFaltas()
    {
        List<TipoFalta> Lista = new List<TipoFalta>();
        try
        {
            using (var conexion = _conexion.ObtieneConexion())
            {

                Lista = (await conexion.QueryAsync<TipoFalta>("SP_TIPO_FALTA_CT", commandType: CommandType.StoredProcedure)).ToList();
            }

            return Lista;
        }
        catch
        {
            return Lista;
            GC.Collect();
        }
    }

    public async Task<TipoFalta> obtieneTipoFaltas(int IdTipoFalta)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdTipoFalta", IdTipoFalta, DbType.Int32);

            return await conexion.QueryFirstOrDefaultAsync<TipoFalta>("SP_TIPO_FALTA_CN", parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
