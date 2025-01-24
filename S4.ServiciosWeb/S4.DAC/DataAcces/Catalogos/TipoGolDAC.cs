namespace S4.DAC.DataAcces.Catalogos;

public class TipoGolDAC : ITipoGolDAC
{

    private readonly Conexion _conexion;
    public TipoGolDAC(Conexion ConnectionString)
    {
        _conexion = ConnectionString;
    }

    public async Task<bool> ActualizarTipoGol(TipoGol TipoGol)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdTipoGol", TipoGol.IdTipoGol, DbType.Int32);
            parametros.Add("@DescripcionGol", TipoGol.DescripcionGol, DbType.String);
            parametros.Add("@Habilitado", TipoGol.Habilitado, DbType.Boolean);
            var Resultado = await conexion.ExecuteAsync("SP_TIPO_GOL_ED", parametros, commandType: CommandType.StoredProcedure);
            return Resultado > 0;
        }
    }

    public async Task<int> InsertarTipoGol(TipoGol TipoGol)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@DescripcionGol", TipoGol.DescripcionGol, DbType.String);
            var Resultado = await conexion.ExecuteScalarAsync<int>("SP_TIPO_GOL_IN", parametros, commandType: CommandType.StoredProcedure);
            return Resultado;
        }
    }

    public async Task<List<TipoGol>> ListaTipoGol()
    {
        List<TipoGol> Lista = new List<TipoGol>();
        try
        {
            using (var conexion = _conexion.ObtieneConexion())
            {

                Lista = (await conexion.QueryAsync<TipoGol>("SP_TIPO_GOL_CT", commandType: CommandType.StoredProcedure)).ToList();
            }

            return Lista;
        }
        catch
        {
            return Lista;
            GC.Collect();
        }
    }

    public async Task<TipoGol> obtieneTipoGol(int IdTipoGol)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdTipoGol", IdTipoGol, DbType.Int32);

            return await conexion.QueryFirstOrDefaultAsync<TipoGol>("SP_TIPO_GOL_CN", parametros, commandType: CommandType.StoredProcedure);
        }
    }


}
