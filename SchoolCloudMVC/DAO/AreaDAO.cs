using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolCloudMVC.BO;
using System.Web.Mvc;
using System.Data;

namespace SchoolCloudMVC.DAO
{
    public class AreaDAO
    {
        ConexionDAO con = new ConexionDAO();
        public IEnumerable<SelectListItem> ListaCiudad()
        {
            var estado = new List<SelectListItem>();
            String strBuscar = string.Format("SELECT * FROM Area");
            estado = con.ListaArea(strBuscar);
            IEnumerable<SelectListItem> estados = estado;

            return estados;
        }

        public int AgregarPublicacion(UniversidadAccseso bo)
        {

            DateTime fecha = DateTime.Today;
            return con.EjecutarComandoFECHA2("Insert into Publicaciones (Descripcion, IDuniversidad, Foto, IDArea, Nombre, FechaRegistro) Values('" + bo.DescripcionPublicacion + "', '" + bo.idUniversidad + "', @foto, '" + bo.ID + "', '" + bo.NombrePublicacion + "', @fecha)", bo);
         

        }

        public DataTable PUBLICACIONEDS(int ID)
        {
            String strBuscar = string.Format("SELECT dbo.Publicaciones.Foto, dbo.Publicaciones.Nombre, dbo.Universidades.ID, dbo.Publicaciones.Descripcion, dbo.Universidades.nombre AS uni, dbo.Publicaciones.FechaRegistro FROM            dbo.Publicaciones INNER JOIN dbo.Universidades ON dbo.Publicaciones.IDuniversidad = dbo.Universidades.ID WHERE dbo.Universidades.ID =" + ID);
            return con.EjercutarSentenciaBus(strBuscar);

        }
    }
}