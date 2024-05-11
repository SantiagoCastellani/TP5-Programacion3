using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP5_GRUPO_5
{
    public class Sucursal
    {
        public string NombreSucursal { get; set; }
        public string DescripcionSucursal { get; set; }
        public int Id_HorarioSucursal { get; set; }
        public int Id_ProvinciaSucursal { get; set; }
        public string DireccionSucursal { get; set; }
        public string URL_Imagen_Sucursal { get; set; }

        // Constructor
        public Sucursal(string nombre, string descripcion, int idHorario, int idProvincia, string direccion, string urlImagen)
        {
            NombreSucursal = nombre;
            DescripcionSucursal = descripcion;
            Id_HorarioSucursal = idHorario;
            Id_ProvinciaSucursal = idProvincia;
            DireccionSucursal = direccion;
            URL_Imagen_Sucursal = urlImagen;
        }
    }
}