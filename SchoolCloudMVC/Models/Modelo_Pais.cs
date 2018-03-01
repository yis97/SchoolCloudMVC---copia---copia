using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolCloudMVC.Models
{
    public class Modelo_Pais
    {
        public IEnumerable<SelectListItem> Pais { get; set; }
             public IEnumerable<SelectListItem> Estado { get; set; }
        public IEnumerable<SelectListItem> ciudad { get; set; }
    }
}