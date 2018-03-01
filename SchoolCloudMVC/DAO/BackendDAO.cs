using System;
using System.Collections.Generic;
using System.Linq;
using SchoolCloudMVC.BO;
using SchoolCloudMVC.DAO;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace SchoolCloudMVC.DAO
{
    public class BackendDAO
    {
        ConexionDAO con = new ConexionDAO();
        BackendBO bo = new BackendBO();
        public BackendBO ObtenerDatosUsuarioUni(int iduser)
        {
            var alumno = new BackendBO();
            String strBuscar = string.Format("SELECT * FROM VistaUsuario where ID='" + iduser + "'");
            DataTable datos = con.EjercutarSentenciaBus(strBuscar);
            DataRow row = datos.Rows[0];
            alumno.IDtipousuario = Convert.ToInt32(row["IDtipo"]);
            alumno.IDusuario = Convert.ToInt32(row["ID"]);
            alumno.Apellidos = row["Apellidos"].ToString();
            alumno.NombreUsaurio = row["Nombre"].ToString();
            alumno.Correo = row["Correo"].ToString();
            alumno.Contraseña = row["Contraseña"].ToString();


            return alumno;
        }
        public IEnumerable<SelectListItem> listatipogrado()
        {
            var estado = new List<SelectListItem>();
            String strBuscar = string.Format("SELECT * FROM tipoUni");
            estado = con.EjecutarSetencialistaTipoUniversidad(strBuscar);
            IEnumerable<SelectListItem> estados = estado;

            return estados;
        }

        public DataTable MensajesContacto(int id)
        {
          
            String strBuscar = string.Format("select distinct NombreUsuarioEnvia, IDusuarioEnvia from VistaMensajes where  IDusuarioRecibe=" + id);
            return con.EjercutarSentenciaBus(strBuscar);
        
        }
        public DataTable chat(int misbolas, int IDenvia)
        {
           
            String strBuscar = string.Format("select * from VistaMensajes where IDusuarioEnvia ='"+IDenvia+ "' and IDusuarioRecibe='" + misbolas+"' or IDusuarioRecibe='"+IDenvia+ "' and IDusuarioEnvia='" + misbolas+ "' order by ID desc");
            return con.EjercutarSentenciaBus(strBuscar);
            
        }
        public int EnviarMensaje(BackendBO bo)
        {
            DateTime fecha = DateTime.Today;
            return con.EjecutarComando("INSERT INTO Mensaje(IDUsuarioEnvia, IDUsuarioRecibe, Mensaje, Fecha,Estatus)values('" + bo.IDusuario + "', '" + bo.IDusuarioEnvia + "', '" + bo.Mensaje + "','" + fecha.ToString("dd/MM/yyyy") + "','True')");

        }
    }
  
}