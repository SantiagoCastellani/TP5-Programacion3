using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TP5_GRUPO_5
{
    public class Conexion
    {
        private const string servidorLocal = @"DESKTOP-GUUQKR5\SQLEXPRESS";
        private const string urlBD = @"Data Source=" + servidorLocal + ";Initial Catalog=BDSucursales;Integrated Security=True";
        public int ejecutarTransaccion(string Consulta)
        {
            SqlConnection connection = new SqlConnection(urlBD);

            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(Consulta, connection);

            int filasAfectadas = sqlCommand.ExecuteNonQuery();

            connection.Close();

            return filasAfectadas;
        }
    }
}