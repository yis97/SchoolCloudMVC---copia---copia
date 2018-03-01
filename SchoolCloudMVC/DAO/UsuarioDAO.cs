using System;
using System.Collections.Generic;
using System.Linq;
using SchoolCloudMVC.BO;
using System.Data;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web;
using System.Text;

namespace SchoolCloudMVC.DAO
{
    public class UsuarioDAO
    {
        UsuarioBO BO = new UsuarioBO();
        ConexionDAO con = new ConexionDAO();
        public int verificarusuario(UsuarioBO a)
        {

            SqlCommand cmd = new SqlCommand("Select ID from Usuario where Correo=@Correo and Contraseña=@Contraseña");
            cmd.Parameters.AddWithValue("@Correo", BO.Correo);
            cmd.Parameters.AddWithValue("@Contraseña", BO.Contraseña);
            cmd.CommandType = CommandType.Text;
            DataSet datos = con.EjecutarSentencia(cmd);
            int id = 0;
            if (datos.Tables[0].Rows.Count > 0)
            {
                id = Convert.ToInt32(datos.Tables[0].Rows[0]["ID"]);
            }

            return id;


        }
        public int verificarTipousuario(int a)
        {

            SqlCommand cmd = new SqlCommand("Select IDTipoUsuairo from Usuario where ID='" + a + "'");
            cmd.CommandType = CommandType.Text;
            DataSet datos = con.EjecutarSentencia(cmd);
            int id = 0;
            if (datos.Tables[0].Rows.Count > 0)
            {
                id = Convert.ToInt32(datos.Tables[0].Rows[0]["IDTipoUsuairo"]);
            }

            return id;


        }
        public UsuarioBO ObtenerDatosUsuario(int id)
        {
            var alumno = new UsuarioBO();
            String strBuscar = string.Format("SELECT * FROM Usuario where ID=" + id);
            DataTable datos = con.EjercutarSentenciaBus(strBuscar);
            DataRow row = datos.Rows[0];
            alumno.ID = Convert.ToInt32(row["ID"]);
            alumno.Nombre = row["Nombre"].ToString();
            alumno.Correo = row["Correo"].ToString();
            alumno.Apellidos = row["Apellidos"].ToString();
            alumno.fotousuario = row["FotoUsuario"].ToString();
            alumno.Contraseña = row["Contraseña"].ToString();
            alumno.IDtipo = Convert.ToInt32(row["IDTipoUsuairo"]);


            return alumno;
        }
        public UsuarioBO ObtenerDatosUsuarioPARACONSULTARUSUARIO(int id, int IDincognito)
        {
            var alumno = new UsuarioBO();
            String strBuscar = string.Format("SELECT * FROM Usuario where ID=" + id);
            DataTable datos = con.EjercutarSentenciaBus(strBuscar);
            DataRow row = datos.Rows[0];
            alumno.ID = Convert.ToInt32(row["ID"]);
            alumno.Nombre = row["Nombre"].ToString();
            alumno.Correo = row["Correo"].ToString();
            alumno.Apellidos = row["Apellidos"].ToString();
            alumno.fotousuario = row["FotoUsuario"].ToString();
            alumno.Contraseña = row["Contraseña"].ToString();
            alumno.IDtipo = Convert.ToInt32(row["IDTipoUsuairo"]);
            alumno.idicongnito = IDincognito;


            return alumno;
        }

        public int cambiarpassword(UsuarioBO bo)
        {
            return con.EjecutarComando("update  Usuario SET Contraseña = '" + bo.Contraseña + "' where ID='" + bo.ID + "'");
        }
        public int cambiarpasswordadmin(BackendBO bo)
        {
            int ID = con.EjecutarComando("update  Usuario SET Contraseña = '" + bo.contrasenia + "' where ID='" + bo.IDusuario + "'");
            return ID;
        }
        public int verificar(UsuarioBO dates)
        {
            ConexionDAO con = new ConexionDAO();
            var usuario = new UsuarioBO();
            string bus = string.Format("Select ID from Usuario where Correo='" + dates.Correo + "' and Contraseña='" + dates.Contraseña + "'");
            DataTable date = con.EjercutarSentenciaBus(bus);
            DataRow row = date.Rows[0];
            BO.ID = int.Parse(row["ID"].ToString());
            return BO.ID;

        }
        public DataTable VistasUsuario()
        {
            String strBuscar = string.Format("SELECT * FROM VistaUsuario");
            return con.EjercutarSentenciaBus(strBuscar);
        }
        public int agregarUsuario(UsuarioBO dato)
        {

            String sqlExec = string.Format("INSERT INTO Usuario(Nombre, Apellidos, Contraseña, Correo, NombreCiudad, IDTipoUsuario, FechaRegistro)values('" + dato.Nombre + "', '" + dato.Apellidos + "', '" + dato.Contraseña + "', '" + dato.Correo + "','Mérida' ,1, '2017-10-10' )");
            return con.ejecutarSentencia(sqlExec);

        }
        public byte[] BuscarImagen(int id)
        {
            BackendBO bo = new BackendBO();

            var ima = new BackendBO();
            string bus = string.Format("select * from VistaAccesoUniversidad where idUsurio='" + id + "'");
            DataTable date = con.EjercutarSentenciaBus(bus);
            DataRow row = date.Rows[0];

            bo.FotoUsuario = (byte[])row["FotoUsuario"];
            return bo.FotoUsuario;

        }
        public byte[] BuscarImagenUniversidad(int id)
        {
            BackendBO bo = new BackendBO();

            var ima = new BackendBO();
            string bus = string.Format("select * from Universidades where ID='" + id + "'");
            DataTable date = con.EjercutarSentenciaBus(bus);
            DataRow row = date.Rows[0];

            bo.FotoUsuario = (byte[])row["Foto"];
            return bo.FotoUsuario;

        }
        public int AgregarUniversidadAcceso(BackendBO bo)
        {

            DateTime fecha = DateTime.Today;
            int IDusuario = con.EjecutarComandofoto("INSERT INTO Usuario(Nombre, Apellidos, Contraseña, Correo, NombreCiudad, IDTipoUsuairo, FechaRegistro,FotoUsuario, Estatus) output INSERTED.ID values('" + bo.NombreA + "', '" + bo.ApellidoA + "', '" + bo.contra + "', '" + bo.CorreoA + "','"+bo.IDCiudad+"' ,3, '" + fecha.ToString("dd/MM/yyyy") + "', @foto, 'True' )", bo);
            return con.EjecutarComando("Insert into UsuarioUniversidadAcceso (idUsurio,idUniversidad)values('" + IDusuario + "', '" + bo.ID + "')");

        }
        public int EditarUsuarioAdministradorAcceso(BackendBO bo)
        {
            int IDusuario = con.EjecutarComandofoto("Update Usuario  set Nombre='" + bo.NombreA + "', Apellidos='"+bo.ApellidoA+"', Correo='"+bo.CorreoA+ "', FotoUsuario=@foto  output INSERTED.ID where ID='" + bo.IDusuario+"'", bo);
            return con.EjecutarComando("Update UsuarioUniversidadAcceso set idUsurio='" + IDusuario + "', idUniversidad='" + bo.ID + "' Where ID='" + bo.IDuniAcceso + "'");
        }
        public int AgregarUniversidadAcceso2(BackendBO bo)
        {
            ConexionFOTO conexion = new ConexionFOTO();
            DateTime fecha = DateTime.Now;
            SqlCommand com = new SqlCommand("INSERT INTO Usuario(Nombre, Apellidos, Contraseña, Correo, NombreCiudad, IDTipoUsuairo, FechaRegistro, FotoUsuario, Estatus) output INSERTED.ID values(@Nombre, @Apellido, @Contra, @Correo, @Ciudad, @IDtipo, @Fecha, @Foto, @Estatus)");
            com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = bo.NombreA;
            com.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = bo.ApellidoA;
            com.Parameters.Add("@Contra", SqlDbType.VarChar).Value = bo.contra;
            com.Parameters.Add("@Correo", SqlDbType.VarChar).Value = bo.CorreoA;
            com.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = "'Mérida'";
            com.Parameters.Add("@IDtipo", SqlDbType.Int).Value = '3';
            com.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            com.Parameters.Add("@Foto", SqlDbType.VarBinary).Value = bo.FotoUsuario;
            com.Parameters.Add("@Estatus", SqlDbType.Bit).Value = "True";
            com.CommandType = CommandType.Text;
         int IDUser= conexion.EjecutarComando(com);

            return con.EjecutarComando("Insert into UsuarioUniversidadAcceso (idUsurio,idUniversidad)values('" + IDUser + "', '" + bo.ID + "')");

        }
        public int agregarUsuarioMortal(UsuarioBO dato)
        {

            String sqlExec = string.Format("INSERT INTO Usuario(Nombre, Apellidos, Contraseña, Correo, NombreCiudad, IDTipoUsuairo, FechaRegistro)values('" + dato.Nombre + "', '" + dato.Apellidos + "', '" + dato.Contraseña + "', '" + dato.Correo + "','Mérida' ,2, '2017-10-10' )");
            return con.ejecutarSentencia(sqlExec);

        }
        public DataTable VistaTablaUsuario()
        {
            String strBuscar = string.Format("SELECT *  from VistaAccesoUniversidad where EstatusUsuario=1 order by FechaRegistro desc");
            return con.EjercutarSentenciaBus(strBuscar);
        }
        public DataTable VistaTablaDirecciones()
        {
            String strBuscar = string.Format("SELECT *  from VistaDirecciones");
            return con.EjercutarSentenciaBus(strBuscar);
        }
        public int EliminarAdministrador(int id)
        {
            return con.EjecutarComando("Update Usuario set Estatus=0 where ID='"+id+"'");
        }
        public int ActualizarDatosUsuario(UsuarioBO bo)
        {
            return con.EjecutarComando("update set Usuario (Nombre, Apellido, Correo, Contraseña, FotoUsuario) values ('" + bo.Nombre + "', '" + bo.Apellidos + "', '" + bo.Correo + "', '" + bo.Contraseña + "', '" + bo.fotousuario + "') where ID='" + bo.ID + "'");
        }
        public int EliminarUsuario(int id)
        {

            String sqlExec = string.Format("Delete from Usuario where ID='" + id + "'");
            return con.ejecutarSentencia(sqlExec);

        }
        public int actualizarUsuario2(UsuarioBO dato)
        {

            return con.EjecutarComando ("update Usuario set Nombre='" + dato.Nombre + "', Apellidos='" + dato.Apellidos + "', Contraseña='" + dato.Contraseña + "', Correo='" + dato.Correo + "', FotoUsuario='"+dato.fotousuario+"' where ID='" + dato.ID + "'");


        }
        public int actualizarUsuario(UsuarioBO dato)
        {

            String sqlExec = string.Format("update Usuario set Nombre='"+dato.Nombre+"', Apellidos='"+dato.Apellidos+"', Contraseña='"+dato.Contraseña+"', Correo='"+dato.Correo+"', NombreCiudad='Mérida', IDTipoUsuario='"+dato.tipoUsuario+ "', FechaRegistro='2017-10-10' where ID='"+dato.ID+"'");
            return con.ejecutarSentencia(sqlExec);

        }
        public IEnumerable<SelectListItem> listarestado()
        {
            var estado = new List<SelectListItem>();
            String strBuscar = string.Format("SELECT * FROM TipoUsuario");
            estado = con.EjecutarSetencialistaTiposUsuarios(strBuscar);
            IEnumerable<SelectListItem> estados = estado;

            return estados;
        }
    }
}