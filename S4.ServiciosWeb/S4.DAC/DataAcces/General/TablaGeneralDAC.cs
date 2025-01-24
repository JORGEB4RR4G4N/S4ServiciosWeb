namespace S4.DAC.DataAcces.General;

public class TablaGeneralDAC : ITablaGeneralDAC
{
    private readonly Conexion _conexion;
    public TablaGeneralDAC(Conexion ConnectionString)
    {
        _conexion = ConnectionString;
    }
    public async Task<bool> ActualizaTablaGeneralGolesPuntos(TablaGeneral tablaGeneral)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdTorneo", tablaGeneral.IdTorneo, DbType.Int32);
            parametros.Add("@IdPlantel", tablaGeneral.IdPlantel, DbType.Int32);
            parametros.Add("@GolesAfavor", tablaGeneral.GolesAfavor, DbType.Int32);
            parametros.Add("@GolesEnContra", tablaGeneral.GolesEnContra, DbType.Int32);
            parametros.Add("@Puntos", tablaGeneral.Puntos, DbType.Int32);
            var Resultado = await conexion.ExecuteAsync("SP_TABLA_GENERAL_GOLES_PUNTOS_ED", parametros, commandType: CommandType.StoredProcedure);
            return Resultado > 0;
        }
    }
    public async Task<bool> ActualizaTablaGeneralResultados(TablaGeneral tablaGeneral)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdTorneo", tablaGeneral.IdTorneo, DbType.Int32);
            parametros.Add("@IdPlantel", tablaGeneral.IdPlantel, DbType.Int32);
            parametros.Add("@Jugados", tablaGeneral.Jugados, DbType.Int32);
            parametros.Add("@Ganados", tablaGeneral.Ganados, DbType.Int32);
            parametros.Add("@Empatados", tablaGeneral.Empatados, DbType.Int32);
            parametros.Add("@Perdidos", tablaGeneral.Perdidos, DbType.Int32);
            var Resultado = await conexion.ExecuteAsync("SP_TABLA_GENERAL_RESULTADOS_ED", parametros, commandType: CommandType.StoredProcedure);
            return Resultado > 0;
        }
    }

    public async Task<int> InsertaTablaGeneral(TablaGeneral tablaGeneral)
    {

        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdTorneo", tablaGeneral.IdTorneo, DbType.Int32);
            parametros.Add("@IdPlantel", tablaGeneral.IdPlantel, DbType.Int32);
            var Resultado = await conexion.ExecuteScalarAsync<int>("SP_TABLA_GENERAL_IN", parametros, commandType: CommandType.StoredProcedure);
            return Resultado;
        }
    }

    public async Task<TablaGeneralDTO> ObtieneTablaGeneral(int IdTablaGeneral)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdTablaGeneral", IdTablaGeneral, DbType.Int32);

            return await conexion.QueryFirstOrDefaultAsync<TablaGeneralDTO>("SP_TABLA_GENERAL_CN", parametros, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<List<TablaGeneralDTO>> ListaTablaGeneral()
    {
        List<TablaGeneralDTO> ListaTorneo = new List<TablaGeneralDTO>();
        try
        {
            using (var conexion = _conexion.ObtieneConexion())
            {

                ListaTorneo = (await conexion.QueryAsync<TablaGeneralDTO>("SP_TABLA_GENERAL_CT", commandType: CommandType.StoredProcedure)).ToList();
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
