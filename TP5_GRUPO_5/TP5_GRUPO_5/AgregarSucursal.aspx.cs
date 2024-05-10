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
        private const string servidorLocal = @"DESKTOP-GUUQKR5\SQLEXPRESS
";
        private const string urlBD = @"Data Source=" + servidorLocal + ";Initial Catalog=BDSucursales;Integrated Security=True";
        private string getProvincias = "SELECT * FROM Provincia";
       // private string Consulta;
        private int f;
        private Conexion conexion = new Conexion();


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

        protected void btnCargarSucursal_Click(object sender, EventArgs e)
        {

            //verificar si los textBox estan vacios.
            if(string.IsNullOrEmpty(txtNombreSucursal.Text) || string.IsNullOrEmpty(txtDesc.Text) || string.IsNullOrEmpty(TxtDir.Text))
            {
                //// mostrar mensaje de error
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Por favor, complete todos los campos.');", true);

                return;

            }

            //obtener datos

            //string nombreSucursal = txtNombreSucursal.Text;
            //string descripcion = txtDesc.Text;
            //string provincia = ddlProvincias.SelectedValue;
            //string direccion = TxtDir.Text;

            //crear consulta SQL

            string Consulta = "INSERT INTO Sucursal (NombreSucursal, DescripcionSucursal, Id_ProvinciaSucursal, DireccionSucursal) VALUES ("+txtNombreSucursal.Text+",'"+txtDesc.Text+"','"+ddlProvincias.SelectedItem.Text+"','"+TxtDir.Text+"')";

            //abrir conexion
           // SqlConnection sqlConnection = new SqlConnection(urlBD);

            //crear comando SQL

           // SqlCommand sqlCommand = new SqlCommand(Consulta, sqlConnection);

            // agregar parametros a la consulta

           // sqlCommand.Parameters.AddWithValue("@NombreSucursal", nombreSucursal);
           // sqlCommand.Parameters.AddWithValue("@DescripcionSucursal", descripcion);
           //sqlCommand.Parameters.AddWithValue("@Id_ProvinciaSucursal", provincia);
           // sqlCommand.Parameters.AddWithValue("@DireccionSucursal", direccion);

            //abrimos la conexion

            // sqlConnection.Open();

            // ejecutar comando SQL
            f = conexion.ejecutarTransaccion(Consulta);
           // sqlCommand.ExecuteNonQuery();


            limpiarCampos();
            LblMensaje.Text = "Sucursal cargada exitosamente";
        }

        private void limpiarCampos()
        {
            // Limpiar los campos de entrada después de guardar los datos
            txtNombreSucursal.Text = string.Empty;
            txtDesc.Text = string.Empty;
            TxtDir.Text = string.Empty;
            ddlProvincias.SelectedIndex = 0;
        }
    }
}