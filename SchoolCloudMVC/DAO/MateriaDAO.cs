using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolCloudMVC.BO;


namespace SchoolCloudMVC.DAO
{
    public class MateriaDAO
    {
        ConexionDAO con = new ConexionDAO();
    
        public int AgregarMateria(MateriasBO bo)
        {

            String sqlExec = string.Format("INSERT INTO Usuario(Materias, IDcarreras, FechaRegistro, Estatus, IDciclo)values('" + bo.Materia + "', '" + bo.IDcarreras + "', '" + bo.fecharegistro + "', 'True','"+bo.IDciclo+"')");
            return con.ejecutarSentencia(sqlExec);

        }
    }
}