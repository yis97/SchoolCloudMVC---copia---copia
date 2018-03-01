using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCloudMVC.BO
{
    public class UsuarioBO
    {
        public int ID { get; set; }
        public int IDtipo { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime fecharegistro { get; set; }
        public int tipoUsuario { get; set; }
        public string fotousuario { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }

        public string confirmarcontraseña { get; set; }


        //Datos para Universidad 
        public int IDuni { get; set; }
        public string NombreUni { get; set; }
        public string DescripcionUni { get; set; }
        public string FotoUni { get; set; }
        public string LatitudUni {get; set;}
        public int Visitasuni { get; set; }
        public string LongitudUni { get; set; }

        public int idicongnito { get; set; }

    }
}