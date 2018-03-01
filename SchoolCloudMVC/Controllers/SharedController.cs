using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCloudMVC.DAO;
using SchoolCloudMVC.BO;

namespace SchoolCloudMVC.Controllers
{
    public class SharedController : Controller
    {
        UsuarioBO bo= new UsuarioBO();
        UsuarioDAO dao = new UsuarioDAO();
        // GET: Shared
        public ActionResult MasterPageBE()
        {
            bo.ID = Convert.ToInt32(Session["ID"]);
            return View(bo.ID == 0 ? new UsuarioBO() : dao.ObtenerDatosUsuario(bo.ID));
        }
        public ActionResult MasterPageUni()
        {
            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);
            return View(bo.ID == 0 ? new UsuarioBO() : dao.ObtenerDatosUsuario(bo.ID));
        }
        public ActionResult MasterPageUsuario ()
        {
            if (Session["IDusuario"] == null)
            {
                Redirect("~/GUI/Index");
            }
            bo.ID = Convert.ToInt32(Session["IDusuario"]);
            return View(bo.ID == 0 ? new UsuarioBO() : dao.ObtenerDatosUsuario(bo.ID));
        }
        public ActionResult MasterPageUsuarioAlumno()
        {
            if (Session["IDusuario"] == null)
            {
                Redirect("~/GUI/Index");
            }
            bo.ID = Convert.ToInt32(Session["IDusuario"]);
            return View(bo.ID == 0 ? new UsuarioBO() : dao.ObtenerDatosUsuario(bo.ID));
        }
    }
}