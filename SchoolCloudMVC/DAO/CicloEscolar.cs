using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SchoolCloudMVC.DAO
{
    public class CicloEscolar
    {
        ConexionDAO con = new ConexionDAO();
        public IEnumerable<SelectListItem> listaCicloEscolar()
        {
            var estado = new List<SelectListItem>();
            String strBuscar = string.Format("SELECT * FROM CicloEscolar");
            estado = con.EjecutarSetencialistaTipoCicloEscolar(strBuscar);
            IEnumerable<SelectListItem> estados = estado;

            return estados;
        }
     

    }
}