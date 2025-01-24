namespace S4.DAC.DataAcces.Catalogos
{
    public class OrigenDAC : IOrigenDAC
    {
        private readonly Conexion _conexion;
        public OrigenDAC(Conexion ConnectionString)
        {
            _conexion = ConnectionString;
        }

        public async Task<bool> ActualizarOrigen(Origen origen)
        {
            using (var conexion = _conexion.ObtieneConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@IdOrigen", origen.IdOrigen, DbType.Int32);
                parametros.Add("@DescripcionOrigen", origen.DescripcionOrigen, DbType.String);
                parametros.Add("@Habilitado", origen.Habilitado, DbType.Boolean);
                var Resultado = await conexion.ExecuteAsync("SP_ORIGEN_ED", parametros, commandType: CommandType.StoredProcedure);
                return Resultado > 0;
            }
        }

        public async Task<int> InsertarOrigen(Origen origen)
        {
            using (var conexion = _conexion.ObtieneConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@DescripcionOrigen", origen.DescripcionOrigen, DbType.String);
                var Resultado = await conexion.ExecuteScalarAsync<int>("SP_ORIGEN_IN", parametros, commandType: CommandType.StoredProcedure);
                return Resultado;
            }
        }

        public async Task<List<Origen>> ListaOrigen()
        {
            List<Origen> Lista = new List<Origen>();
            try
            {
                using (var conexion = _conexion.ObtieneConexion())
                {

                    Lista = (await conexion.QueryAsync<Origen>("SP_ORIGEN_CT", commandType: CommandType.StoredProcedure)).ToList();
                }

                return Lista;
            }
            catch
            {
                return Lista;
                GC.Collect();
            }
        }

        public async Task<Origen> ObtenOrigen(int IdOrigen)
        {
            using (var conexion = _conexion.ObtieneConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@IdOrigen", IdOrigen, DbType.Int32);

                return await conexion.QueryFirstOrDefaultAsync<Origen>("SP_ORIGEN_CN", parametros, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
