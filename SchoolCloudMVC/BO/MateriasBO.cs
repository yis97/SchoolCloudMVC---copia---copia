using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCloudMVC.BO
{
    public class MateriasBO
    {
        public int ID { get; set; }
        public string Materia { get; set; }
        public int IDcarreras { get; set; }
        public DateTime fecharegistro { get; set; }
        public int IDciclo { get; set; }
    }
}