namespace S4.DAC.DataAcces.General;

public class PartidoDAC : IPartidoDAC
{
    private readonly Conexion _conexion;
    public PartidoDAC(Conexion ConnectionString)
    {
        _conexion = ConnectionString;
    }
    public async Task<bool> ActualizaPartido(Partido partido)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdPartido", partido.IdPartido, DbType.Int32);
            parametros.Add("@IdTorneo", partido.IdTorneo, DbType.Int32);
            parametros.Add("@IdPlantelLocal", partido.IdPlantelLocal, DbType.Int32);
            parametros.Add("@IdPlantelVisitante", partido.IdPlantelVisitante, DbType.Int32);
            parametros.Add("@MarcadorLocal", partido.MarcadorLocal, DbType.Int32);
            parametros.Add("@MarcadorVisitante", partido.MarcadorVisitante, DbType.Int32);
            parametros.Add("@FechaPartido", partido.FechaPartido, DbType.Date);
            parametros.Add("@Habilitado", partido.Habilitado, DbType.Boolean);
            var Resultado = await conexion.ExecuteAsync("SP_PARTIDO_ED", parametros, commandType: CommandType.StoredProcedure);
            return Resultado > 0;
        }
    }

    public async Task<int> InsertaPartido(Partido partido)
    {

        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdTorneo", partido.IdTorneo, DbType.Int32);
            parametros.Add("@IdPlantelLocal", partido.IdPlantelLocal, DbType.Int32);
            parametros.Add("@IdPlantelVisitante", partido.IdPlantelVisitante, DbType.Int32);
            parametros.Add("@FechaPartido", partido.FechaPartido, DbType.Date);
            var Resultado = await conexion.ExecuteScalarAsync<int>("SP_PARTIDO_IN", parametros, commandType: CommandType.StoredProcedure);
            return Resultado;
        }
    }

    public async Task<PartidoDTO> ObtienePartido(int IdPartido)
    {
        using (var conexion = _conexion.ObtieneConexion())
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdTorneo", IdPartido, DbType.Int32);

            return await conexion.QueryFirstOrDefaultAsync<PartidoDTO>("SP_PARTIDO_CN", parametros, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<List<PartidoDTO>> ListaPartidos()
    {
        List<PartidoDTO> ListaTorneo = new List<PartidoDTO>();
        try
        {
            using (var conexion = _conexion.ObtieneConexion())
            {

                ListaTorneo = (await conexion.QueryAsync<PartidoDTO>("SP_PARTIDO_CT", commandType: CommandType.StoredProcedure)).ToList();
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
