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
        private const string servidorLocal = @"localhost";
        private const string urlBD = "Data Source=" + servidorLocal + @"\SQLEXPRESS;Initial Catalog=BDSucursales;Integrated Security=True";

        private string getProvincias = "SELECT * FROM Provincia";
        private int result;
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
            // Validación de Campos NO vacios
            if(string.IsNullOrEmpty(txtNombreSucursal.Text) || string.IsNullOrEmpty(txtDesc.Text) || string.IsNullOrEmpty(TxtDir.Text))
            {
                // Alert:Mensaje de Error
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Por favor, complete todos los campos.');", true);
                return;
            }
            string nombreSucursal = txtNombreSucursal.Text;
            string descripcion = txtDesc.Text;
            string idProvincia = ddlProvincias.SelectedValue;
            string direccion = TxtDir.Text;
            string url = "www.imagen.com";

            string insert = "INSERT INTO Sucursal (NombreSucursal, DescripcionSucursal, Id_HorarioSucursal, Id_ProvinciaSucursal, DireccionSucursal, URL_Imagen_Sucursal) VALUES ('" + nombreSucursal + "','" + descripcion + "'," + 1 + "," + idProvincia + ",'" + direccion + "','" + url + "')";

            result = conexion.ejecutarTransaccion(insert);
            
            if (result == 1)
            {
                limpiarCampos();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('La Sucursal fue agregada a la lista de sucursales.');", true);
            }

        }

        private void limpiarCampos()
        {
            // Limpiar los campos de entrada después de guardar los datos
            txtNombreSucursal.Text = string.Empty;
            txtDesc.Text = string.Empty;
            TxtDir.Text = string.Empty;
        }
    }
}