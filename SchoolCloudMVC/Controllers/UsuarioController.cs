using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCloudMVC.DAO;
using SchoolCloudMVC.BO;
using System.Web.UI.WebControls;
using System.IO;

namespace SchoolCloudMVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        AuthenticateEventArgs e = new AuthenticateEventArgs();
        UsuarioBO userBO = new UsuarioBO();
        UniversidadBO uniBO = new UniversidadBO();
        DireccionBO direcBO = new DireccionBO();
        int iduni;
        UsuarioDAO userDAO = new UsuarioDAO();
        UniversidadDAO uniDAO = new UniversidadDAO();
        public AuthenticateEventArgs E
        {
            get
            {
                return e;
            }

            set
            {
                e = value;
            }
        }
        //PARCIALES DEL USUARIO
        public ActionResult _ParcialEscuelas()
        {
            return View(uniDAO.VistaUniversidad());
        }
  
        public ActionResult ActuzalizarDatos(UsuarioBO bo, HttpPostedFileBase fotousuario)
        {
            if (fotousuario != null)
            {
                var filename = Path.GetFileName(fotousuario.FileName);
                var path = Path.Combine(Server.MapPath("~/Picture/ImagenesUsuario/"), filename);
                fotousuario.SaveAs(path);
                bo.fotousuario = filename;
                userDAO.actualizarUsuario2(bo);
                return Redirect("~/Usuario/Perfil");

            }
            return Redirect("~/Usuario/Index");
        }
        // GET: GUI
        public ActionResult Index()
        {
            if(Session["IDusuario"]==null)
            {
           return    Redirect("~/GUI/Index");
            }
            userBO.ID = Convert.ToInt32(Session["IDusuario"]);
            return View(userBO.ID == 0 ? new UsuarioBO() : userDAO.ObtenerDatosUsuario(userBO.ID));
         
        }
        public ActionResult Perfil ()
        {
            if (Session["IDusuario"] == null)
            {
             return   Redirect("~/GUI/Index");
            }
            userBO.ID = Convert.ToInt32(Session["IDusuario"]);
            return View(userBO.ID == 0 ? new UsuarioBO() : userDAO.ObtenerDatosUsuario(userBO.ID));
        }

        public ActionResult _BuscarAvanzada()
        {
            return View();
        }
        public ActionResult Buscar(UniversidadBO bo)
        {

            return Redirect("~/GUI/BusquedaAvanzada/" + bo.Nombre);
        }
        public ActionResult BusquedaAvanzada(string ID)
        {
            return View(uniDAO.BusquedaAvanzada(ID));
        }
        public ActionResult Quienesomos()
        {
            return View();
        }
        public ActionResult _IDuni(int id)
        {
            iduni = id;
            return View(id);
        }
        public ActionResult MapaUniversidades()
        {
            return View();
        }
        public ActionResult _ListaMaterias(int id)
        {
            return View(uniDAO.MateriasCarrera2(id));
        }
        public ActionResult UniversidadCarreraMateria(int id)

        {
            try
            {
                //Session["ID"] = id;
                return View(id == 0 ? new Carreras() : uniDAO.ObtenerInformacionCarrera(id));
            }
            catch
            {
                return Redirect("~/GUI/Error404");
            }
        }
        public ActionResult _Filtrocarreras(int ID)
        {
            int IDuni = Convert.ToInt32(Session["ID"]);
            int IDgrados = Convert.ToInt32(Session["IDgrado"]);
            return View(uniDAO.FiltrosCarreras(IDuni, IDgrados, ID));
        }
        public ActionResult Error404()
        {
            return View();
        }
        public ActionResult _InformacionUni(int id)
        {
            return View(uniDAO.ObetnerInformacionUniversidad(id));
        }
        public ActionResult _ListaCarreras(int id)
        {
            int IDVERGAS = Convert.ToInt32(Session["ID"]);
            return View(uniDAO.MostrarLasMateriasCarrera(IDVERGAS, id));
        }
        public ActionResult _ListasCarrerasUni(int ID)
        {
            int IDuni = Convert.ToInt32(Session["id"]);
            return View(uniDAO.ObtenerDatosCarreras(IDuni, ID));
        }
        public ActionResult Carreras(int ID)
        {

            int IDuni = Convert.ToInt32(Session["id"]);
            Session["IDgrado"] = ID;
            return View(ID == 0 ? new UniversidadBO() : uniDAO.ObtenerDatosCarreras2(IDuni, ID));
        }
        public ActionResult _ParcialinfoEscuela(int id)
        {
            return View(id == 0 ? new UsuarioBO() : uniDAO.ObtenerDatosUniversidadparaUSUARIO(id));
        }

        public ActionResult InformacionEscuela(int ID)
        {

            _ParcialinfoEscuela(ID);

            if (Session["IDusuario"] == null)
            {
                return Redirect("~/GUI/Index");
            }
            userBO.ID = Convert.ToInt32(Session["IDusuario"]);
            return View(userBO.ID == 0 ? new UsuarioBO() : userDAO.ObtenerDatosUsuarioPARACONSULTARUSUARIO(userBO.ID, ID));
            

        }
        public ActionResult _UniPopulares()
        {
            return View(uniDAO.VistaUniPopulares());
        }
        public ActionResult PaginaMaestra()
        {
            userBO.ID = Convert.ToInt32(Session["ID"]);
            userDAO.ObtenerDatosUsuario(userBO.ID);
            return View();
        }

        public ActionResult GaleriaUniversidad(int ID)
        {
            return View(uniDAO.ObtenerDatosGaleriaUniversidad(ID));
        }
        [HttpPost]
        public ActionResult resgitrarme(UsuarioBO bo)
        {

            userDAO.agregarUsuarioMortal(bo);


            return Redirect("~/GUI/Index");


        }
        public ActionResult Registrate()
        {

            return View();
        }
        public ActionResult GPSparcial()
        {
            return View();
        }
        public ActionResult Iniciar(UsuarioBO dato)
        {
            try
            {

                int id;
                int IDtipo;
                bool validado = false;
                id = userDAO.verificar(dato);
                IDtipo = userDAO.verificarTipousuario(id);

                if (id != 0)
                {
                    validado = true;

                }
                E.Authenticated = validado;
                if (validado)

                    Session["ID"] = id;

                if (IDtipo == 3)
                {
                    return Redirect("~/UniAdmin/Panel_Admin_Universidad");
                }

                return Redirect("~/BackEnd/Panel_Administrativo");

            }
            catch
            {

            }
            return Redirect("~/GUI/Login");

        }

        public ActionResult Login(UsuarioBO bo)
        {


            return View();
        }
    }
}