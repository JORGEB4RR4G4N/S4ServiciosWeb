namespace S4.DAC
{
    public class Conexion
    {
        private readonly string _connectionString;
        public Conexion(string valor)
        {
            _connectionString = valor;
        }

        public SqlConnection ObtieneConexion()
        {
            var conexion = new SqlConnection(_connectionString);
            conexion.Open();
            return conexion;
        }
    }
}
