using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TP5_GRUPO_5
{
    public class Conexion
    {
        private const string servidorLocal = "localhost";
        private const string urlBD = "Data Source=" + servidorLocal + @"\SQLEXPRESS;Initial Catalog=BDSucursales;Integrated Security=True";

        public int ejecutarTransaccion(string consulta)
        {
            SqlConnection connection = new SqlConnection(urlBD);

            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(consulta, connection);

            int filasAfectadas = sqlCommand.ExecuteNonQuery();

            connection.Close();

            return filasAfectadas;
        }

        public SqlDataReader listaItems(string consulta){
            SqlConnection connection = new SqlConnection(urlBD);
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(consulta, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();            

            connection.Close();

            return sqlDataReader;
        }

        public List<Sucursal> ObtenerListaSucursales(string consultaSQL)
        {
            List<Sucursal> listaSucursales = new List<Sucursal>();

            // Crear una conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(urlBD))
            {
                // Abrir la conexión
                connection.Open();

                // Crear un SqlCommand para ejecutar la consulta SQL
                using (SqlCommand command = new SqlCommand(consultaSQL, connection))
                {
                    // Ejecutar la consulta y obtener un SqlDataReader para leer los resultados
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay filas de resultados
                        if (reader.HasRows)
                        {
                            // Iterar sobre cada fila de resultados
                            while (reader.Read())
                            {
                                // Obtener los valores de cada columna
                                string nombre = reader["NombreSucursal"].ToString();
                                string descripcion = reader["DescripcionSucursal"].ToString();
                                int idHorario = Convert.ToInt32(reader["Id_HorarioSucursal"]);
                                int idProvincia = Convert.ToInt32(reader["Id_ProvinciaSucursal"]);
                                string direccion = reader["DireccionSucursal"].ToString();
                                string urlImagen = reader["URL_Imagen_Sucursal"].ToString();

                                // Crear una nueva instancia de Sucursal y agregarla a la lista
                                Sucursal sucursal = new Sucursal(nombre, descripcion, idHorario, idProvincia, direccion, urlImagen);
                                listaSucursales.Add(sucursal);
                            }
                        }
                    }
                }
            }

            return listaSucursales;
        }
    }
}