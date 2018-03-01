using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolCloudMVC.BO;
using SchoolCloudMVC.DAO;
using System.Web.Mvc;

namespace SchoolCloudMVC.Controllers
{
    public class UsuarioAlumnoController : Controller
    {
        // GET: UsuarioAlumno
        UsuarioBO userBO = new UsuarioBO();
        UsuarioDAO userDAO = new UsuarioDAO();
        public ActionResult Index()
        {
            if (Session["IDusuario"] == null)
            {
                return Redirect("~/GUI/Index");
            }
            userBO.ID = Convert.ToInt32(Session["IDusuario"]);
            return View(userBO.ID == 0 ? new UsuarioBO() : userDAO.ObtenerDatosUsuario(userBO.ID));
          
        }
        public ActionResult CambiarContraseña()
        {
            if (Session["IDusuario"] == null)
            {
                return Redirect("~/GUI/Index");
            }
            userBO.ID = Convert.ToInt32(Session["IDusuario"]);
            return View(userBO.ID == 0 ? new UsuarioBO() : userDAO.ObtenerDatosUsuario(userBO.ID));
        }
        public ActionResult Noticias()
        {
            if (Session["IDusuario"] == null)
            {
                return Redirect("~/GUI/Index");
            }
            userBO.ID = Convert.ToInt32(Session["IDusuario"]);
            return View(userBO.ID == 0 ? new UsuarioBO() : userDAO.ObtenerDatosUsuario(userBO.ID));
        }

        public ActionResult CambiarMiContraseña(UsuarioBO bo)
        {
            if (bo.confirmarcontraseña == bo.Contraseña)
            {
                bo.ID = Convert.ToInt32(Session["IDusuario"]);
                userDAO.cambiarpassword(bo);
                return Redirect("~/UsuarioAlumno/Noticias");

            }
            else
            {
                return Content("<script language='javascript'type='text/javascript'>alert('La contraseña no coinciden');</script>");

            }
        }
    }
}