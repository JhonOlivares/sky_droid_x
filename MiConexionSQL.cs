using System.Data.SqlClient;
namespace AndroidAerolinea
{
    public class MiConexionSQL
    {
        static SqlConnection conexion;
        public static SqlConnection getConexion()
        {
            conexion = new SqlConnection("Data Source=192.168.43.140;Initial Catalog=DBAerolinea;Persist Security Info=True;User ID=redlocalmaster;Password=redlocal0");
            return conexion;
        }
    }
}