using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCloudMVC.BO
{
    public class CarrerasMaterias
    {
        public int IDCarrerateria { get; set; }
        public int IDciclo { get; set; }
        public int IDCarrera { get; set; }
        public int IDMateria { get; set; }
        public DateTime FECHAREGISTROmateria { get; set; }
        public string Materia { get; set; }
        public string Turno { get; set; }

    }
}