namespace S4.DAC.DataAcces.Planteles;

public class PlantelJugadorDAC : IPlantelJugadorDAC
{

    private readonly Conexion _conexion;
    public PlantelJugadorDAC(Conexion ConnectionString)
    {
        _conexion = ConnectionString;
    }

    public async Task<bool> ActualizarPlantelJugador(PlantelJugador plantelJugador)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdPlantelJugador", plantelJugador.IdPlantelJugador, DbType.Int32);
            parametros.Add("@IdTorneo", plantelJugador.IdTorneo, DbType.Int32);
            parametros.Add("@IdPlantel", plantelJugador.IdPlantel, DbType.Int32);
            parametros.Add("@IdJugador", plantelJugador.IdJugador, DbType.Int32);
            parametros.Add("@Habilitado", plantelJugador.Habilitado, DbType.Boolean);
            var Resultado = await conexion.ExecuteAsync("SP_PLANTEL_JUGADOR_ED", parametros, commandType: CommandType.StoredProcedure);
            return Resultado > 0;
        }
    }

    public async Task<int> InsertarPlantelJugador(PlantelJugador plantelJugador)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdTorneo", plantelJugador.IdTorneo, DbType.Int32);
            parametros.Add("@IdPlantel", plantelJugador.IdPlantel, DbType.Int32);
            parametros.Add("@IdJugador", plantelJugador.IdJugador, DbType.Int32);
            var Resultado = await conexion.ExecuteScalarAsync<int>("SP_PLANTEL_JUGADOR_IN", parametros, commandType: CommandType.StoredProcedure);
            return Resultado;
        }
    }

    public async Task<List<PlantelJugadorDTO>> ListaPlantelJugador()
    {
        List<PlantelJugadorDTO> Lista = new List<PlantelJugadorDTO>();
        try
        {
            using (var conexion = _conexion.ObtieneConexion())
            {

                Lista = (await conexion.QueryAsync<PlantelJugadorDTO>("SP_PLANTEL_JUGADOR_CT", commandType: CommandType.StoredProcedure)).ToList();
            }

            return Lista;
        }
        catch
        {
            return Lista;
            GC.Collect();
        }
    }

    public async Task<PlantelJugadorDTO> ObtienePlantelJugador(int IdPlantelJuagdor)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdPlantelJuagdor", IdPlantelJuagdor, DbType.Int32);

            return await conexion.QueryFirstOrDefaultAsync<PlantelJugadorDTO>("SP_PLANTEL_JUGADOR_CN", parametros, commandType: CommandType.StoredProcedure);
        }
    }

}
