using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TP5_GRUPO_5
{
    public partial class EliminarSucursal : System.Web.UI.Page
    {
        
        private Conexion conexion = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            // obtener el ID de sucursal
            int IdSucursal = int.Parse(txtIdSucursal.Text);
            

            //crear la consulta SQL

            string consulta = "DELETE FROM Sucursal WHERE Id_Sucursal = " + IdSucursal;

            //ejecutamos la consulta desde el metodo EjecutarTransaccion de la clase conexion
            int filasAfectadas = conexion.ejecutarTransaccion(consulta);

            if(filasAfectadas > 0)
            {
                lblMensaje.Text = "La sucursal se ha eliminado con exito";
            }
            else
            {
                lblMensaje.Text = "el ID ingresado no es correcto";
            }
        }

        private void LimpiarCampos()
        {
            txtIdSucursal.Text = string.Empty;
        }
    }
}