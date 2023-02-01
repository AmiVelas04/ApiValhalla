namespace ApiValhalla.Conexion
{
    public class ConexionBd
    {
        private string connectionString = string.Empty;
        public ConexionBd()
        {
            var constructor = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionString = constructor.GetSection("ConnectionStrings:ConexionMaste").Value;
        }
        public string CadenaSql()
        {
            return connectionString;
        }
    }
}
