namespace S4.DAC.DataAcces.Catalogos;

public class TipoMotivoDAC : ITipoMotivoDAC
{
    private readonly Conexion _conexion;
    public TipoMotivoDAC(Conexion ConnectionString)
    {
        _conexion = ConnectionString;
    }

    public async Task<bool> ActualizarTipoMotivo(TipoMotivo TipoMotivo)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdTipoMotivo", TipoMotivo.IdTipoMotivo, DbType.Int32);
            parametros.Add("@DescripcionMotivo", TipoMotivo.DescripcionMotivo, DbType.String);
            parametros.Add("@Habilitado", TipoMotivo.Habilitado, DbType.Boolean);
            var Resultado = await conexion.ExecuteAsync("SP_TIPO_MOTIVO_ED", parametros, commandType: CommandType.StoredProcedure);
            return Resultado > 0;
        }
    }

    public async Task<int> InsertarTipoMotivo(TipoMotivo TipoMotivo)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@DescripcionMotivo", TipoMotivo.DescripcionMotivo, DbType.String);
            var Resultado = await conexion.ExecuteScalarAsync<int>("SP_TIPO_MOTIVO_IN", parametros, commandType: CommandType.StoredProcedure);
            return Resultado;
        }
    }

    public async Task<List<TipoMotivo>> ListaTipoMotivo()
    {
        List<TipoMotivo> Lista = new List<TipoMotivo>();
        try
        {
            using (var conexion = _conexion.ObtieneConexion())
            {

                Lista = (await conexion.QueryAsync<TipoMotivo>("SP_TIPO_MOTIVO_CT", commandType: CommandType.StoredProcedure)).ToList();
            }

            return Lista;
        }
        catch
        {
            return Lista;
            GC.Collect();
        }
    }

    public async Task<TipoMotivo> obtieneTipoMotivo(int IdTipoMotivo)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdTipoMotivo", IdTipoMotivo, DbType.Int32);

            return await conexion.QueryFirstOrDefaultAsync<TipoMotivo>("SP_TIPO_MOTIVO_CN", parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
