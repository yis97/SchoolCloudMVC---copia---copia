using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SchoolCloudMVC.BO;
using System.Data.SqlClient;

namespace SchoolCloudMVC.DAO
{
    public class CarrerasDAO
    {
        ConexionDAO con = new ConexionDAO();

        public int AgregarCarrera(Carreras bo)
        {

            int sqlExec = con.ejecutarSentencia("INSERT INTO Carreras(Nombre, idgrado, FechaRegistro, Estatus)output INSERTED.ID values('" + bo.Nombre + "', '" + bo.idgrado + "', '17-11-2017', 'True')");

            return AgregarUniversidadCarrera(41);

        }
        public DataTable TablaCarreras(int ID)
        {
            String strBuscar = string.Format("SELECT * FROM UniversidadCarreraView where ID="+ID);
            return con.EjercutarSentenciaBus(strBuscar);

        }
        public int AgregarUniversidadCarrera(int id)
        
        {
            String sqlExec = string.Format("INSERT INTO UniversidadCarreras(IDuniversidad, IDcarreras, FechaRegistro, Estatus)values('2', '"+id+"', '17-11-2017', 'True')");
            return con.ejecutarSentencia(sqlExec);
        }
        public int ModificarCarrera(Carreras bo)
        {

            String sqlExec = string.Format("INSERT INTO Carreras(Nombre, idgrado, FechaRegistro, Estatus)values('" + bo.Nombre + "', '16', '17-11-2017', 'True')");
            return con.ejecutarSentencia(sqlExec);

        }
        public int agrergarrrr(UniversidadAccseso ui)
        {
            DateTime fecha = DateTime.Today;
            int hui = con.EjecutarComando("INSERT INTO Carreras(Nombre, idgrado, FechaRegistro, Estatus, Foto, Descripcion)output INSERTED.ID values('" + ui.NombreUni + "', '" + ui.idgrado + "', '"+fecha.ToString("dd/MM/yyyy") +"', 'True', '" + ui.FotoCarrera + "', '"+ui.Descripcion+"')");
            con.ejecutarSentencia("INSERT INTO UniversidadCarreras(IDUniversidad, IDCarreras, FechaRegistro, Estatus)values('"+ui.idUniversidad+"', '"+hui+"', '17-11-2017', 'True')");
            return hui;

        }
        public SqlDataAdapter reports()
        {

            string sentencia = "select * from Carreras";
            SqlDataAdapter inf = new SqlDataAdapter(sentencia, con.con);
            return inf;

        }

    }
}