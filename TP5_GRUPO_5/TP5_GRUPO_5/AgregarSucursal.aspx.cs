using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Data.SqlClient;

namespace TP5_GRUPO_5
{
    public partial class AgregarSucursal : System.Web.UI.Page
    {
        private const string servidorLocal = @"SANTIDEV\SQLEXPRESS";
        private const string urlBD = @"Data Source=" + servidorLocal + ";Initial Catalog=BDSucursales;Integrated Security=True";
        private string getProvincias = "SELECT * FROM Provincia";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /// Conexion a Base de Datos

                SqlConnection connection = new SqlConnection(urlBD);
                connection.Open();

                /// Consulta Provincias Inicial

                SqlCommand sqlCommand = new SqlCommand(getProvincias, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                /// Cargar el DropDownList Inicial

                ddlProvincias.DataSource = sqlDataReader;
                ddlProvincias.DataTextField = "DescripcionProvincia";
                ddlProvincias.DataValueField = "Id_Provincia";
                ddlProvincias.DataBind();

                connection.Close();
            }

        }
    }
}