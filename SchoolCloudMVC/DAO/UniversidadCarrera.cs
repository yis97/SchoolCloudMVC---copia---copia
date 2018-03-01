using System;
using System.Collections.Generic;
using System.Linq;
using SchoolCloudMVC.BO;
using System.Data;
using System.Web;

namespace SchoolCloudMVC.DAO
{
    public class UniversidadCarrera
    {
        ConexionDAO con = new ConexionDAO();
        public UniversidadAccseso ObtenerDatosUniversidadCarrera(int iduser)
        {
            var alumno = new UniversidadAccseso();
            String strBuscar = string.Format("SELECT * FROM DatosCarreraUniversidad where ID='" + iduser + "'");
            DataTable datos = con.EjercutarSentenciaBus(strBuscar);
            DataRow row = datos.Rows[0];
            alumno.idUsuario = Convert.ToInt32(row["idUsurio"]);
            alumno.IDcarrera = Convert.ToInt32(row["ID"]);
            alumno.IDCarreras = Convert.ToInt32(row["idcarrera"]);
            alumno.Nombre = row["Nombre"].ToString();
            alumno.Foto = row["Foto"].ToString();
            alumno.NombreCarrera = row["NombreCarrera"].ToString();
            alumno.idUniversidad = int.Parse(row["idUniversidad"].ToString());
            alumno.Universidad = row["Universidad"].ToString();
      
            return alumno;
        }
        public UniversidadCarreraBO ObtenerDatosUniversidadCarrera2(int iduser)
        {
            var alumno = new UniversidadCarreraBO();
            String strBuscar = string.Format("SELECT * FROM UniversidadCarreraView where IDCarreraUni='" + iduser + "'");
            DataTable datos = con.EjercutarSentenciaBus(strBuscar);
            DataRow row = datos.Rows[0];
            alumno.ID = Convert.ToInt32(row["IDCarreraUni"]);
            alumno.foto =row["FotoCarreras"].ToString();
            alumno.NombreUniversidad = row["Nombre"].ToString();

            return alumno;
        }


    }
}