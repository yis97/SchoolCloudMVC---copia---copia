using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;

namespace SchoolCloudMVC.DAO
{
    public class GradoDAO
    {
        ConexionDAO con = new ConexionDAO();

        public IEnumerable<SelectListItem> listatipogrado()
        {
            var estado = new List<SelectListItem>();
            String strBuscar = string.Format("SELECT * FROM Grado");
            estado = con.EjecutarSetencialistaTiposGrado(strBuscar);
            IEnumerable<SelectListItem> estados = estado;

            return estados;
        }

    }
}