using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TP5_GRUPO_5
{
    public partial class ListadoDeSucursales : System.Web.UI.Page
    {
        private const string servidorLocal = @"DESKTOP-GUUQKR5\SQLEXPRESS";
        private const string urlBD = @"Data Source=" + servidorLocal + ";Initial Catalog=BDSucursales;Integrated Security=True";
        private string consultaSql = "SELECT Sucursal.Id_Sucursal, Sucursal.NombreSucursal, Sucursal.DescripcionSucursal,Provincia.DescripcionProvincia AS Provincia, Sucursal.DireccionSucursal FROM Sucursal INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /// Conexion a Base de Datos

                SqlConnection connection = new SqlConnection(urlBD);
                connection.Open();

                /// Consulta Provincias Inicial

                SqlCommand sqlCommand = new SqlCommand(consultaSql, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                gvSucursales.DataSource = sqlDataReader;
                gvSucursales.DataBind();
                connection.Close();
            }
        }

        protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarSucursal();
        }
        private void FiltrarSucursal()
        {
            string filtroId = TxtBuscarId.Text;
            string consultaFiltro = "";
            SqlConnection conexion = new SqlConnection(urlBD);
            conexion.Open();
            if (!string.IsNullOrEmpty(TxtBuscarId.Text))
            {
                consultaFiltro =  consultaSql += "WHERE Sucursal.Id_Sucursal = ";

            }
            if (!string.IsNullOrEmpty(TxtBuscarId.Text))
            {
                consultaFiltro += filtroId;

            }
            SqlCommand sqlCommand = new SqlCommand(consultaFiltro, conexion);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            gvSucursales.DataSource = dataTable;
            gvSucursales.DataBind();

            conexion.Close();
        }
    }
}