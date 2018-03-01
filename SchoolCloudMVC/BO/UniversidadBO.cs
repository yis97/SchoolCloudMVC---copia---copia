using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCloudMVC.BO
{
    public class UniversidadBO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public string descripcion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int Visitas { get; set; }
        public int IDGRADO { get; set; }
    }
}