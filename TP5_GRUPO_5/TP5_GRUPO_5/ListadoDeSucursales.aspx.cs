using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TP5_GRUPO_5
{
    public partial class ListadoDeSucursales : System.Web.UI.Page
    {
        private const string servidorLocal = "SANTIDEV";
        private const string urlBD = "Data Source=" + servidorLocal + @"\SQLEXPRESS;Initial Catalog=BDSucursales;Integrated Security=True";

        string getSucursales = "SELECT * FROM Sucursal";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rellenarGrilla(0);
            }
        }

        private void rellenarGrilla(int id)
        {
            SqlConnection connection = new SqlConnection(urlBD);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand();

            if (id == 0)
            {
                sqlCommand = new SqlCommand(getSucursales, connection);
                
            } else
            {
               getSucursales += " WHERE Id_Sucursal = @IdSucursal";
               sqlCommand = new SqlCommand(getSucursales, connection);
               sqlCommand.Parameters.AddWithValue("@IdSucursal", id);
            }

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            gvSucursales.DataSource = sqlDataReader;
            gvSucursales.DataBind();

            connection.Close();
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            rellenarGrilla(0);
        }

        protected void btnFiltrarById_Click(object sender, EventArgs e)
        {
            string id = txtIdSucursal.Text;
            if (id == "")
            {
                id = "0";
            }
            rellenarGrilla(int.Parse(id));
        }
    }
}