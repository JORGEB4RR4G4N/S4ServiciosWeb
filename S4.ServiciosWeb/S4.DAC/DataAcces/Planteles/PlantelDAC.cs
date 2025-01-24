namespace S4.DAC.DataAcces.Planteles;

public class PlantelDAC : IPlantelDAC
{
    private readonly Conexion _conexion;
    public PlantelDAC(Conexion ConnectionString)
    {
        _conexion = ConnectionString;
    }

    public async Task<bool> ActualizarPlantel(Plantel plantel)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdPlantel", plantel.IdPlantel, DbType.Int32);
            parametros.Add("@NombreEquipo", plantel.NombreEquipo, DbType.String);
            parametros.Add("@IdOrigen", plantel.IdOrigen, DbType.Int32);
            parametros.Add("@Habilitado", plantel.Habilitado, DbType.Boolean);
            var Resultado = await conexion.ExecuteAsync("SP_PLANTEL_ED", parametros, commandType: CommandType.StoredProcedure);
            return Resultado > 0;
        }
    }

    public async Task<int> InsertarPlantel(Plantel plantel)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdPlantel", plantel.IdPlantel, DbType.Int32);
            parametros.Add("@NombreEquipo", plantel.NombreEquipo, DbType.String);
            parametros.Add("@IdOrigen", plantel.IdOrigen, DbType.Int32);
            var Resultado = await conexion.ExecuteScalarAsync<int>("SP_PLANTEL_IN", parametros, commandType: CommandType.StoredProcedure);
            return Resultado;
        }
    }

    public async Task<List<PlantelDTO>> ListaPlantel()
    {
        List<PlantelDTO> Lista = new List<PlantelDTO>();
        try
        {
            using (var conexion = _conexion.ObtieneConexion())
            {

                Lista = (await conexion.QueryAsync<PlantelDTO>("SP_PLANTEL_CT", commandType: CommandType.StoredProcedure)).ToList();
            }

            return Lista;
        }
        catch
        {
            return Lista;
            GC.Collect();
        }
    }

    public async Task<PlantelDTO> ObtienePlantel(int IdPlantel)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdPlantel", IdPlantel, DbType.Int32);

            return await conexion.QueryFirstOrDefaultAsync<PlantelDTO>("SP_PLANTEL_CN", parametros, commandType: CommandType.StoredProcedure);
        }
    }

}
