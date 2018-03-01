using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SchoolCloudMVC.BO;
namespace SchoolCloudMVC.DAO
{
    public class CarreraMateriaDAO
    {
        ConexionDAO con = new ConexionDAO();
        public int AgregarCarreraMateria(UniversidadAccseso bo)
        {
            DateTime fecha = DateTime.Today;
            int IDCARRERA = con.EjecutarComando("INSERT INTO Materias(Materias, FechaResgistro, Estatus, IDciclo)output INSERTED.ID values('" + bo.Materia + "', '"+fecha.ToString("dd/MM/yyyy") +"', 'True', '" + bo.IDciclo+ "')");
            con.EjecutarComando("INSERT INTO CarrerasMateria(idCarrea, idMateria, FechaRegistro, Estatus) values('" + bo.IDCarreras + "', '" + IDCARRERA + "', '" + fecha.ToString("dd/MM/yyyy") + "', 'True')");
            int Retorna = con.EjecutarComando("INSERT INTO UniversidadCarreraMateria(IDmateria, Turno,IDuniversidadCarrera, FechaRegistro, Estatus) values('" + IDCARRERA + "', '" + bo.Turno + "', '" + bo.IDcarrera + "', '" + fecha.ToString("dd/MM/yyyy") + "','True')");
            return IDCARRERA;
            
        }
        public int EditarCarreraMateria(UniversidadAccseso bo)

        {

       int IDCARRERA=  con.EjecutarComando("update Materias set Materias='" + bo.Materia + "',IDciclo='" + bo.IDciclo + "'  where ID='" + bo.IDCarreras+"'");
            int RETOR = con.EjecutarComando("update  UniversidadCarreraMateria set Turno='"+bo.Turno+ "' where ID='"+bo.IDunicarrera+"'");
            return RETOR;
        }


        public int AgregarDesempeño (UniversidadAccseso bo)
        {
            return con.EjecutarComando("Insert into Desempeñar (Nombre, Descripción, IDcarrera) values ('"+bo.NombreDesempeño+"', '"+bo.DescripcionDesempeño+"', '"+bo.IDCarreras+"')"); 
        }
        public DataTable TablaMATERIAS(int ID)
        {
            String strBuscar = string.Format("SELECT * FROM MateriasCarrerasUniversidad where ID='"+ID+"' and Estatus='True'");
            return con.EjercutarSentenciaBus(strBuscar);

        }
        public DataTable TablaDesempeño(int ID)
        {
            String strBuscar = string.Format("SELECT * FROM Desempeñar where IDcarrera='" + ID + "'");
            return con.EjercutarSentenciaBus(strBuscar);

        }
        public int BorrarMateria(int id)
        {

            return con.EjecutarComando("update Materias set Estatus='False' where ID='" + id + "'");
        }
    }
}