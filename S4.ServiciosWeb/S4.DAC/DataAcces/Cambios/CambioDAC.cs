namespace S4.DAC.DataAcces.Cambios
{
    public class CambioDAC : ICambioDAC
    {
        private readonly Conexion _conexion;
        public CambioDAC(Conexion ConnectionString)
        {
            _conexion = ConnectionString;
        }

        public async Task<bool> ActualizarCambio(Cambio cambio)
        {
            using (var conexion = _conexion.ObtieneConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@IdCambio", cambio.IdCambio, DbType.Int32);
                parametros.Add("@IdPartido", cambio.IdPartido, DbType.Int32);
                parametros.Add("@IdPlantel", cambio.IdPlantel, DbType.Int32);
                parametros.Add("@IdJugadorSale", cambio.IdJugadorSale, DbType.Int32);
                parametros.Add("@IdJugadorEntra", cambio.IdJugadorEntra, DbType.Int32);
                parametros.Add("@IdTipoMotivo", cambio.IdTipoMotivo, DbType.Int32);
                parametros.Add("@Habilitado", cambio.Habilitado, DbType.Boolean);
                var Resultado = await conexion.ExecuteAsync("SP_CAMBIO_ED", parametros, commandType: CommandType.StoredProcedure);
                return Resultado > 0;
            }
        }

        public async Task<int> InsertarCambio(Cambio cambio)
        {
            using (var conexion = _conexion.ObtieneConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@IdPartido", cambio.IdPartido, DbType.Int32);
                parametros.Add("@IdPlantel", cambio.IdPlantel, DbType.Int32);
                parametros.Add("@IdJugadorSale", cambio.IdJugadorSale, DbType.Int32);
                parametros.Add("@IdJugadorEntra", cambio.IdJugadorEntra, DbType.Int32);
                parametros.Add("@IdTipoMotivo", cambio.IdTipoMotivo, DbType.Int32);
                var Resultado = await conexion.ExecuteScalarAsync<int>("SP_CAMBIO_IN", parametros, commandType: CommandType.StoredProcedure);
                return Resultado;
            }
        }

        public async Task<List<CambioDTO>> ListaCambio()
        {
            List<CambioDTO> Lista = new List<CambioDTO>();
            try
            {
                using (var conexion = _conexion.ObtieneConexion())
                {

                    Lista = (await conexion.QueryAsync<CambioDTO>("SP_CAMBIO_CT", commandType: CommandType.StoredProcedure)).ToList();
                }

                return Lista;
            }
            catch
            {
                return Lista;
                GC.Collect();
            }
        }

        public async Task<CambioDTO> ObtenCambio(int IdCambio)
        {
            using (var conexion = _conexion.ObtieneConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@IdCambio", IdCambio, DbType.Int32);

                return await conexion.QueryFirstOrDefaultAsync<CambioDTO>("SP_CAMBIO_CN", parametros, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
