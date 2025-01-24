namespace S4.DAC.DataAcces.Catalogos;

public class PosicionDAC : IPosicionDAC
{
    private readonly Conexion _conexion;
    public PosicionDAC(Conexion ConnectionString)
    {
        _conexion = ConnectionString;
    }

    public async Task<bool> ActualizarPosicion(Posicion posicion)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdPosicion", posicion.IdPosicion, DbType.Int32);
            parametros.Add("@DescripcionPosicion", posicion.DescripcionPosicion, DbType.String);
            parametros.Add("@Habilitado", posicion.Habilitado, DbType.Boolean);
            var Resultado = await conexion.ExecuteAsync("SP_TIPO_FALTA_ED", parametros, commandType: CommandType.StoredProcedure);
            return Resultado > 0;
        }
    }

    public async Task<int> InsertarPosicion(Posicion posicion)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@DescripcionPosicion", posicion.DescripcionPosicion, DbType.String);
            var Resultado = await conexion.ExecuteScalarAsync<int>("SP_POSICION_IN", parametros, commandType: CommandType.StoredProcedure);
            return Resultado;
        }
    }

    public async Task<List<Posicion>> ListaPosicion()
    {
        List<Posicion> Lista = new List<Posicion>();
        try
        {
            using (var conexion = _conexion.ObtieneConexion())
            {

                Lista = (await conexion.QueryAsync<Posicion>("SP_POSICION_CT", commandType: CommandType.StoredProcedure)).ToList();
            }

            return Lista;
        }
        catch
        {
            return Lista;
            GC.Collect();
        }
    }

    public async Task<Posicion> ObtienePosicion(int IdPosicion)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdPosicion", IdPosicion, DbType.Int32);

            return await conexion.QueryFirstOrDefaultAsync<Posicion>("SP_POSICION_CN", parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
