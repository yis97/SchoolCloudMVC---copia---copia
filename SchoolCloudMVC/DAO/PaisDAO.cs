using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolCloudMVC.DAO
{
    public class PaisDAO
    {
        ConexionDAO con = new ConexionDAO();

        public IEnumerable<SelectListItem> ListaPaises()
        {
            var estado = new List<SelectListItem>();
            String strBuscar = string.Format("SELECT * FROM Pais");
            estado = con.ListaPais(strBuscar);
            IEnumerable<SelectListItem> estados = estado;

            return estados;
        }
       

        public IEnumerable<SelectListItem> ListaEstado(string Pais)
        {
            var estado = new List<SelectListItem>();
            String strBuscar = string.Format("SELECT * FROM Estado where IDPais='"+Pais+"'");
            estado = con.ListaEstado(strBuscar);
            IEnumerable<SelectListItem> estados = estado;

            return estados;
        }
        public IEnumerable<SelectListItem> ListaCiudad(string Pais)
        {
            var estado = new List<SelectListItem>();
            String strBuscar = string.Format("SELECT * FROM Ciudad where IDEstado='" + Pais + "'");
            estado = con.ListaCiudad(strBuscar);
            IEnumerable<SelectListItem> estados = estado;

            return estados;
        }

    }
}