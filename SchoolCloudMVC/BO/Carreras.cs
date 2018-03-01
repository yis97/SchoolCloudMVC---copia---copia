using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCloudMVC.BO
{
    public class Carreras
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int IDgrados { get; set; }
      public string Foto { get; set; }
        public string Descripcion { get; set; }
        public string NombreUniversidad { get; set; }
        public int idgrado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int iduni { get; set; }
    }
}