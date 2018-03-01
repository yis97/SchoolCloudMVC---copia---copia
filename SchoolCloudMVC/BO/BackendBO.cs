using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCloudMVC.BO
{
    public class BackendBO
    {
        public int IDCiudad { get; set; }
        public int IDuniAcceso { get; set; }
        //para agreggar
        public string NombreA { get; set; }
        public string ApellidoA { get; set; }
        public string CorreoA { get; set; }
        public string contra { get; set; }
        public bool ok { get; set; }
        //Usuario
        public string NombreUsaurio { get; set; }
        public int IDusuario { get; set; }
        public string Apellidos { get; set; }
        public byte [] FotoUsuario { get; set; }
        public int ID { get; set; }// esta ID es para agregar IDuniversidad
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string contrasenia { get; set; }
        //Tipo usuairio
        public int IDtipousuario { get; set; }
        //TipoUniversidad
        public int idtipouni { get; set; }
        public string NombreTipo { get; set; }

        //Mensajes 
        public int IDusuarioEnvia { get; set; }

        public string Mensaje { get; set; }
        //Universidades 
        public int IDUniversidad { get; set; }
        public string Nombreuniversidad { get; set; }
        public string DescripcionUnivesidad { get; set; }
        public byte [] Fotouniversidad { get; set; }
        //Telefono
        public int IDtel { get; set; }
        public string Telefono { get; set; }

        //Direccion
        public int IDdireccion { get; set; }
        public string Longitud { get; set; }
        public string Latituf { get; set; }
        public string Direccion { get; set; }
        public string Lugar { get; set; }
       //Estado
       public string NombreEstado { get; set; }
        //Pais
        public string pais { get; set; }
        //Ciudad 
        public string  ciudad { get; set; }




    }
}