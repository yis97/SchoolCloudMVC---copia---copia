using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCloudMVC.BO
{
    public class UniversidadAccseso
    {

        public int IDusuarioEnvia { get; set; }

        public string Mensaje { get; set; }

        //mendsajeds
        public int idUsuario { get; set; }
        public DateTime fecharegistro { get; set; }
        public int idUniversidad { get; set; }
        public int idgrado { get; set; }
        public string Nombre { get; set; }
        public string Universidad { get; set; }
        public string Contraseña { get; set; }
        public int IDcarrera { get; set; }
        public string FotoCarrera { get; set; }
        public string Foto { get; set; }
        public string Estatus { get; set; }
        public string tipo { get; set; }
        public string NombreUni { get; set; }




        public int visitas { get; set; }

        //___________________________________________
        public string NombreCarrera { get; set; }
       
        public string NombreMateria { get; set; }
        //_______________________________________GaleriaUniversidad
        public string Descripcion { get; set; }
        public string FotoUniversiad { get; set; }
        //______________________________________________AgregarCarreraMateria
        public int IDCarreras { get; set; }
        public int IDciclo { get; set; }
        public string Materia { get; set; }
        public string Turno { get; set; }
        public int IDunicarrera { get; set; }
        // Desempeño
        public string NombreDesempeño { get; set; }
        public string DescripcionDesempeño { get; set; }
        public string Fotodesempeño { get; set; }


        //-------------------
        public string NombrePublicacion { get; set; }
        public string DescripcionPublicacion { get; set; }
        public int ID { get; set; }
        
        public byte[] fotopublicacion { get; set; }

    }
}