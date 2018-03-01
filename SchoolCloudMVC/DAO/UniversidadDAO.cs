using System;
using SchoolCloudMVC.BO;
using System.Collections.Generic;
using System.Linq;
using System.Data;

using System.Web;
using System.Web.Mvc;

namespace SchoolCloudMVC.DAO
{
    public class UniversidadDAO
    {

        ConexionDAO con = new ConexionDAO();
        UniversidadBO bo = new UniversidadBO();
       

        //Notificaciones de universidadAcceso
        public DataTable NumeroCarrerasAccesoUniversidad(int ID)
       {
            String strBuscar = string.Format("SELECT COUNT(*) AS NumeroDeCarreras FROM UniversidadCarreraView WHERE(Estatus = 1) and ID = '"+ID+"'");
            return con.EjercutarSentenciaBus(strBuscar);
        }
        //Aqui Acaba
        public DataTable VistaUniversidad()
        {
            String strBuscar = string.Format("SELECT * FROM VistaUni where Estatus=1 order by ID DESC ");
            return con.EjercutarSentenciaBus(strBuscar);
        }
        public DataTable VistaTablaUniversidad()
        {
            String strBuscar = string.Format("SELECT *  from VistaUniversidad where Estatus=1 order by FechaRegistro desc");
            return con.EjercutarSentenciaBus(strBuscar);
        }
        public DataTable VistaUniPopulares ()
        {
            String strBuscar = string.Format("SELECT Top 5 *FROM VistaUni where Estatus=1 order by Visitas desc");
            return con.EjercutarSentenciaBus(strBuscar);
        }
        public UniversidadBO ObtenerDatosUniversidad(int id)
        {
            var uni = new UniversidadBO();
            String strBuscar = string.Format("SELECT * FROM VistaUni where ID=" + id);
            DataTable datos = con.EjercutarSentenciaBus(strBuscar);
            DataRow row = datos.Rows[0];
            uni.ID = Convert.ToInt32(row["ID"]);
            uni.Nombre = row["nombre"].ToString();
            uni.descripcion = row["descripcion"].ToString();
            uni.Foto = row["Foto"].ToString();
            uni.Latitud = row["Latitud"].ToString();
            uni.Visitas = Convert.ToInt32( row["Visitas"]);
            uni.Longitud = row["Longitud"].ToString();
            int num = uni.Visitas + 1;
            con.EjecutarComando("Update Universidades set Visitas ='" + num+ "' where ID='" + uni.ID + "'");
            return uni;
        }
        public UsuarioBO ObtenerDatosUniversidadparaUSUARIO(int id)
        {
            var uni = new UsuarioBO();
            String strBuscar = string.Format("SELECT * FROM VistaUni where ID=" + id);
            DataTable datos = con.EjercutarSentenciaBus(strBuscar);
            DataRow row = datos.Rows[0];
            uni.IDuni = Convert.ToInt32(row["ID"]);
            uni.NombreUni = row["nombre"].ToString();
            uni.DescripcionUni = row["descripcion"].ToString();
            uni.FotoUni = row["Foto"].ToString();
            uni.LatitudUni = row["Latitud"].ToString();
            uni.Visitasuni = Convert.ToInt32(row["Visitas"]);
            uni.LongitudUni = row["Longitud"].ToString();
            int num = uni.Visitasuni + 1;
            con.EjecutarComando("Update Universidades set Visitas ='" + num + "' where ID='" + uni.IDuni + "'");
            return uni;
        }
        public DataTable ObetnerInformacionUniversidad (int id)
        {

            String strBuscar = string.Format("SELECT * FROM VistaUni where ID=" + id);
            return con.EjercutarSentenciaBus(strBuscar);
        }
        public int EnviarMensaje(UniversidadAccseso bo)
        {
            DateTime fecha = DateTime.Today;
            return con.EjecutarComando("INSERT INTO Mensaje(IDUsuarioEnvia, IDUsuarioRecibe, Mensaje, Fecha,Estatus)values('" + bo.idUsuario + "', '" + bo.IDusuarioEnvia + "', '" + bo.Mensaje + "','" + fecha.ToString("dd/MM/yyyy") + "','True')");

        }
        public UniversidadAccseso ObtenerDatosUsuarioUni(int iduser)
        {
            var alumno = new UniversidadAccseso();
            String strBuscar = string.Format("SELECT * FROM VistaAccesoUniversidad where idUsurio='" + iduser + "'");
            DataTable datos = con.EjercutarSentenciaBus(strBuscar);
            DataRow row = datos.Rows[0];
            alumno.idUsuario = Convert.ToInt32(row["idUsurio"]);
            alumno.Nombre = row["Nombre"].ToString();
            alumno.Foto = row["Foto"].ToString();
            alumno.Universidad = row["Universidad"].ToString();
            alumno.idUniversidad = Convert.ToInt32(row["idUniversidad"]);
            alumno.Contraseña = row["Contraseña"].ToString();
            alumno.tipo = row["tipo"].ToString();
            alumno.visitas = Convert.ToInt32(row["Visitas"]);


            return alumno;
        }

        public BackendBO ObtenerDatosdelaUniver(int iduser)
        {
            var alumno = new BackendBO();
            String strBuscar = string.Format("SELECT *  from VistaUniversidad where Estatus=1 and ID='" + iduser + "'");
            DataTable datos = con.EjercutarSentenciaBus(strBuscar);
            DataRow row = datos.Rows[0];
          alumno.DescripcionUnivesidad = row["descripcion"].ToString();


            return alumno;
        }
        public int EditarDatosUniversidad(BackendBO bo)

        {
            int ejec = con.EjecutarComandofotoUni("update Universidades set nombre='"+bo.Nombreuniversidad+"', tipo='"+bo.idtipouni+"', descripcion='"+bo.DescripcionUnivesidad+"', Foto=@foto where ID='"+bo.IDUniversidad+"' ", bo);
            //int ejecDireccion = con.EjecutarComando("update Telefono set NumeroTelefono='" + bo.Telefono + "' where ID='" + bo.IDtel + "'");
            return ejec;


    }
        public int EditarDatosUniversidadSINFOTO(BackendBO bo)

        {
            int ejec = con.EjecutarComando("update Universidades set nombre='" + bo.Nombreuniversidad + "', tipo='" + bo.idtipouni + "', descripcion='" + bo.DescripcionUnivesidad + "' where ID='" + bo.IDUniversidad + "' ");
            //int ejecDireccion = con.EjecutarComando("update Telefono set NumeroTelefono='" + bo.Telefono + "' where ID='" + bo.IDtel + "'");
            return ejec;


        }
        public int BajaUniversidad(int id)

        {
            int DELETE = con.EjecutarComando("Update Universidades set Estatus=0 where ID='" + id + "'");
            return DELETE;


        }
        public DataTable ObtenerDatosGaleriaUniversidad(int id)
        {
            var uni = new UniversidadBO();
            String strBuscar = string.Format("SELECT * FROM Galeria where ID=" + id);
            return con.EjercutarSentenciaBus(strBuscar);

        }
        public DataTable ObtenerDatosGradoEstudios(int id)
        {
            var uni = new UniversidadBO();
            String strBuscar = string.Format("SELECT distinct ID, tipogrado, IDgrado FROM UniversidadCarreraView where ID=" + id);
            return con.EjercutarSentenciaBus(strBuscar);

        }
        public DataTable FiltrosCarreras(int IDuni, int IDgrado,  int id)
        {
        
            String strBuscar = string.Format("SELECT * FROM UniversidadCarreraView where ID='"+IDuni+"' and IDgrado='"+IDgrado+"' and IDCarrera <>'"+id+"'");
            return con.EjercutarSentenciaBus(strBuscar);

        }
        public DataTable MateriasCarrera(int id)
        {
           
         String strBuscar = string.Format("select distinct GradoEscolar, IDcarreras, IDCiclo, Nombre, Descripcion from MateriasCarrerasUniversidad where  IDcarreras = '" + id+"' and Estatus = 'True' order by GradoEscolar desc");
            return con.EjercutarSentenciaBus(strBuscar);
        }
        public DataTable MateriasCarrera2(int id)
        {

            String strBuscar = string.Format("select distinct GradoEscolar, IDcarreras, IDCiclo, Nombre, Descripcion from MateriasCarrerasUniversidad where  IDcarreras = '" + id + "' and Estatus = 'True' order by GradoEscolar desc");
            return con.EjercutarSentenciaBus(strBuscar);
        }
        public DataTable MostrarLasMateriasCarrera (int id, int IDCiclo )
        {
            String strBuscar = string.Format("select Materias, Turno from MateriasCarrerasUniversidad where  IDcarreras='"+id+ "' and Estatus= 'True' and  IDciclo='"+IDCiclo+"'  order by GradoEscolar desc");
            return con.EjercutarSentenciaBus(strBuscar);
        }
        public DataTable BusquedaAvanzada(string Bus)
        {
       
            String strBuscar = string.Format("SELECT  distinct NombreUniversidad, Foto, descripcion, ID FROM InformacionTodasUniversidades where  NombreUniversidad like '%"+Bus+"%' or descripcion like '%"+Bus+"%'or Carrera like '%" + Bus+"%' or Turno like '%"+Bus+"%' or Materias like '%"+Bus+ "%' or tipo like '%"+Bus+"%'");
            return con.EjercutarSentenciaBus(strBuscar);

        }
        public DataTable ObtenerDatosCarreras(int iduni, int id)
        {

            String strBuscar = string.Format("SELECT * FROM UniversidadCarreraView where ID='"+iduni+"' and IDgrado='" + id + "'");
            return con.EjercutarSentenciaBus(strBuscar);

        }
        public UniversidadBO ObtenerDatosCarreras2(int iduni, int id)
        {
            var alumno = new UniversidadBO();
            String strBuscar = string.Format("SELECT * FROM UniversidadCarreraView where ID='" + iduni + "' and IDgrado='" + id + "'");
            DataTable datos = con.EjercutarSentenciaBus(strBuscar);
            DataRow row = datos.Rows[0];
            alumno.ID= Convert.ToInt32(row["ID"]);
            alumno.Nombre = row["Universidad"].ToString();
            alumno.Foto = row["Foto"].ToString();
            alumno.IDGRADO = Convert.ToInt32(row["IDgrado"]);
    
            return alumno;
        }

       
        public Carreras ObtenerInformacionCarrera(int id)
        {
            var alumno = new Carreras();
            String strBuscar = string.Format("select * from MateriasCarrerasUniversidad where  IDcarreras = '" + id + "' and Estatus = 'True'");
            DataTable datos = con.EjercutarSentenciaBus(strBuscar);
            DataRow row = datos.Rows[0];
            alumno.ID = Convert.ToInt32(row["IDcarreras"]);
            alumno.Nombre = row["Nombre"].ToString();
            alumno.Foto = row["Foto"].ToString();
            alumno.NombreUniversidad = row["Univerisdad"].ToString();
            alumno.Descripcion = row["Descripcion"].ToString();
            alumno.IDgrados = Convert.ToInt32(row["IDgrado"]);

            return alumno;
        }
        public IEnumerable<SelectListItem> ListaUniversidades()
        {
            var estado = new List<SelectListItem>();
            String strBuscar = string.Format("SELECT * FROM Universidades");
            estado = con.EjecutarSetencialistauniversidades(strBuscar);
            IEnumerable<SelectListItem> estados = estado;

            return estados;
        }
        public int GuardarUnGaleriaUniverdad(UniversidadAccseso ui)
        {
            DateTime fecha = DateTime.Today;
            return con.EjecutarComando("Insert Into Imagenes(Foto, IDUniversidad, Descripción, FechaRegistro, Estatus)Values('"+ui.FotoUniversiad+"', '"+ui.idUniversidad+"', '"+ui.Descripcion+"', '"+ fecha.ToString("dd/MM/yyyy") + "', 'True')");

           
        }
        public int Visitas(int ID, int bo)
        {
          int num=      bo + 1;
       return     con.EjecutarComando("Update Universidades set Visitas ='"+num+"' where ID='"+ID+"'");
        }
        public int GuardarUniverisdad (BackendBO bo)
        {
            DateTime fecha = DateTime.Now;
     int IDuni=       con.EjecutarComandoFECHA("Insert Into Universidades(nombre, tipo, descripcion, IDtelefono, IDdireccion, Estatus, Foto, Visitas, FechaRegistro) output INSERTED.ID values('" + bo.Nombreuniversidad + "', '" + bo.idtipouni + "', '" + bo.DescripcionUnivesidad + "', '0', '0', 'True',  @foto, '0', @fecha)", bo);
            int IDtelefono = con.EjecutarComando("Insert Into Telefono (NumeroTelefono, IDUniversidad) values('" + bo.Telefono+"', '"+IDuni+"') ");
            int IDdireccion = con.EjecutarComando("Insert Into Dirección (Longitud, Latitud, Dirección, IDUniversidad)  values ('" + bo.Longitud+"', '"+bo.Latituf+"', '"+bo.Direccion+"', '"+IDuni+"')");
            return IDdireccion;
        }
    }
    }