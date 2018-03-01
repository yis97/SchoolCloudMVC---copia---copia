using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCloudMVC.BO;
using SchoolCloudMVC.DAO;
using SchoolCloudMVC.Models;
using System.IO;

namespace SchoolCloudMVC.Controllers
{
    public class BackEndController : Controller
    {
        // GET: BackEnd
        UsuarioBO bo = new UsuarioBO();
        UniversidadDAO uniDao = new UniversidadDAO();
        BackendDAO BAC = new BackendDAO();
        UsuarioDAO dao = new UsuarioDAO();
        public ActionResult Index()
        {
            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);
            //dao.ObtenerDatosUsuario(bo.ID);
            //if (bo.IDtipo == 3)
            //{

            //    return Redirect("~/UniAdmin/Index");
            //}
            return View(bo.ID == 0 ? new BackendBO() : BAC.ObtenerDatosUsuarioUni(bo.ID));

        }
        public ActionResult MiPerfil()
        {
            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);
            //dao.ObtenerDatosUsuario(bo.ID);
            //if (bo.IDtipo == 3)
            //{

            //    return Redirect("~/UniAdmin/Index");
            //}
            return View(bo.ID == 0 ? new BackendBO() : BAC.ObtenerDatosUsuarioUni(bo.ID));
        }
        public ActionResult CambiarContraseña(BackendBO bo)
        {

            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);

            return View(bo.ID == 0 ? new BackendBO() : BAC.ObtenerDatosUsuarioUni(bo.ID));
        }
        public JsonResult PostCambiarContraseña(BackendBO bo)
        {
            var pe = new BackendBO();
        if( dao.cambiarpasswordadmin(bo) == 0)
            {
              pe.ok = true;
            }

            return Json(pe);
         
        }
        public ActionResult TablaUsuarios()
        {
            return PartialView(dao.VistasUsuario());
        }
        public ActionResult MensajesAdmin()
        {

            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);

            return View(bo.ID == 0 ? new BackendBO() : BAC.ObtenerDatosUsuarioUni(bo.ID));
        }
        public ActionResult TipoUsuario()
        {
            Modelo_TipoUsuario viewModel = new Modelo_TipoUsuario();
            viewModel.TipoUsuario = dao.listarestado();
            return PartialView(viewModel);
        }
        public ActionResult Panel_Administrativo()
        {
            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);
            //dao.ObtenerDatosUsuario(bo.ID);
            //if (bo.IDtipo == 3)
            //{

            //    return Redirect("~/UniAdmin/Index");
            //}
            return View(bo.ID == 0 ? new BackendBO() : BAC.ObtenerDatosUsuarioUni(bo.ID));
        }
        [HttpPost]
        public ActionResult RegistrarUniversidad ([Bind(Include = "IDUniversidad, Nombreuniversidad,DescripcionUnivesidad,Telefono,Direccion, idtipouni, Latituf, Longitud")] BackendBO bo ,HttpPostedFileBase Fotouniversidad)
        {
           
            if (Fotouniversidad != null && bo.IDUniversidad ==0)
            {
                //var filename = Path.GetFileName(Fotouniversidad.FileName);
                //var path = Path.Combine(Server.MapPath("~/Picture/GaleriaUniversidad/"), filename);
                //Fotouniversidad.SaveAs(path);
                //bo.Fotouniversidad = filename;
                byte[] imagenData = null;
                var binario = new BinaryReader(Fotouniversidad.InputStream);

                imagenData = binario.ReadBytes(Fotouniversidad.ContentLength);
                bo.Fotouniversidad = imagenData;
                if (uniDao.GuardarUniverisdad(bo) == 0)
                {

                    return Content("<script language='javascript' type='text/javascript'>alert('" + bo.Nombreuniversidad + " Registrada con éxito' ); window.location.replace('Universidades_Administrador');  </script>");
                }

            }
            if ((Fotouniversidad != null) && (bo.IDUniversidad !=0))
            {
                //var filename = Path.GetFileName(Fotouniversidad.FileName);
                //var path = Path.Combine(Server.MapPath("~/Picture/GaleriaUniversidad/"), filename);
                //Fotouniversidad.SaveAs(path);
                //bo.Fotouniversidad = filename;
                byte[] imagenData = null;
                var binario = new BinaryReader(Fotouniversidad.InputStream);

                imagenData = binario.ReadBytes(Fotouniversidad.ContentLength);
                bo.Fotouniversidad = imagenData;
                uniDao.EditarDatosUniversidad(bo);
                return Content("<script language='javascript' type='text/javascript'>alert('" + bo.Nombreuniversidad + " ha sido Actualizada con éxito' ); window.location.replace('Universidades_Administrador');  </script>");
            }
            if ((Fotouniversidad == null) && (bo.IDUniversidad != 0))
            {
               
                uniDao.EditarDatosUniversidadSINFOTO(bo);
                return Content("<script language='javascript' type='text/javascript'>alert('" + bo.Nombreuniversidad + " ha sido Actualizada con éxito' ); window.location.replace('Universidades_Administrador');  </script>");
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Error no se pudo actualizar ');</script>");
        }
        public ActionResult EDITARuniversidad (BackendBO bo)/*([Bind(Include = "IDUniversidad, Nombreuniversidad, DescripcionUnivesidad, idtipouni")] BackendBO bo, HttpPostedFileBase Fotouniversidad)*/
        {
            //var filename = Path.GetFileName(Fotouniversidad.FileName);
            //var path = Path.Combine(Server.MapPath("~/Picture/GaleriaUniversidad/"), filename);
            //Fotouniversidad.SaveAs(path);
            //bo.Fotouniversidad = filename;
                uniDao.EditarDatosUniversidad(bo);
         
      return   Content("<script language='javascript' type='text/javascript'>alert('Error no se pudo actualizar ');</script>");
        }
        public ActionResult Usuarios_Administrador()
        {
            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);
            //dao.ObtenerDatosUsuario(bo.ID);
            //if (bo.IDtipo == 3)
            //{

            //    return Redirect("~/UniAdmin/Index");
            //}
            return View(bo.ID == 0 ? new BackendBO() : BAC.ObtenerDatosUsuarioUni(bo.ID));
        }
        public ActionResult ELIMINARUNIVERSIDAD(int ID)
        {
            uniDao.BajaUniversidad(ID);
            return Content("OK");
        }
        public JsonResult EliminarAdministrador(int id)
        {
            var resp = new BackendBO();
         if(dao.EliminarAdministrador(id) == 0)
            {
                resp.ok = true;
            }
            return Json(resp);
         
        }
        public ActionResult _IDuni(int id)
        {
            return View(id);
        }
        public ActionResult ConvertirImagen(int id)
        {
            BackendBO bo = new BackendBO();
            var fotito = dao.BuscarImagen(id);
            return File(fotito, "image/jpg");
        }
        public ActionResult  Telefono ()
        {
            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);
            //dao.ObtenerDatosUsuario(bo.ID);
            //if (bo.IDtipo == 3)
            //{

            //    return Redirect("~/UniAdmin/Index");
            //}
            return View(bo.ID == 0 ? new BackendBO() : BAC.ObtenerDatosUsuarioUni(bo.ID));
        }
        public ActionResult ConvertirImagenUniversidad (int id)
        {
       
            var fotito = dao.BuscarImagenUniversidad(id);
            return File(fotito, "image/jpg");
        }
        public ActionResult AgregarUniversidadAccesoBac ([Bind(Include = "IDuniAcceso, IDusuario, NombreA, ApellidoA, CorreoA, Contra, ID, IDCiudad")]BackendBO bo , HttpPostedFileBase FotoUsuario)
        {
            if (FotoUsuario != null  && bo.IDuniAcceso==0)
            {
                byte[] imagenData = null;
                using(var binario = new BinaryReader(FotoUsuario.InputStream))
                {
                    imagenData = binario.ReadBytes(FotoUsuario.ContentLength);
                    bo.FotoUsuario = imagenData;
                    dao.AgregarUniversidadAcceso(bo);
                }
                //var filename = Path.GetFileName(FotoUsuario.FileName);
                //var path = Path.Combine(Server.MapPath("~/Picture/ImagenesUsuario/"), filename);
                //FotoUsuario.SaveAs(path);
                //bo.FotoUsuario = filename;
              //dao.AgregarUniversidadAcceso(bo);
                return Content("<script language='javascript' type='text/javascript'> alert('" + bo.NombreA + " ha sido Registrado con éxito' ); window.location.href='Usuarios_Administrador';  </script>");

            }
            if(FotoUsuario != null  && bo.IDuniAcceso!=0)
            {
                byte[] imagenData = null;
                var binario = new BinaryReader(FotoUsuario.InputStream);
                
                    imagenData = binario.ReadBytes(FotoUsuario.ContentLength);
                    bo.FotoUsuario = imagenData;
                if (dao.EditarUsuarioAdministradorAcceso(bo) == 0)

                {
                    return Content("<script language='javascript' type='text/javascript' > alert('" + bo.NombreA + " ha sido Actualizada con éxito'); window.location.replace('Usuarios_Administrador');  </script> ");
                }
                

            }
            return Redirect("~/BackEnd/Universidades_Administrador");
        }
        public ActionResult Universidades_Administrador()
        {
            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);
            //dao.ObtenerDatosUsuario(bo.ID);
            //if (bo.IDtipo == 3)
            //{

            //    return Redirect("~/UniAdmin/Index");
            //}
            return View(bo.ID == 0 ? new BackendBO() : BAC.ObtenerDatosUsuarioUni(bo.ID));
        }
        public ActionResult Direcciones()
        {
            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }
            bo.ID = Convert.ToInt32(Session["ID"]);
            return View(bo.ID == 0 ? new BackendBO() : BAC.ObtenerDatosUsuarioUni(bo.ID));
        }
        public ActionResult EnviarMensaje(BackendBO bo)
        {
      
                BAC.EnviarMensaje(bo);
              
 
            return Redirect("~/BackEnd/MensajesAdmin");
        }
        public ActionResult BuscarUni(int id)
        {
          
            return View (uniDao.ObtenerDatosdelaUniver(id));
        }

        public ActionResult EliminarUsuario(int id)
        {
            dao.EliminarUsuario(id);
            return Content("hecho");
        }
        [HttpPost]
        public ActionResult guardar(UsuarioBO mun)
        {

            var r = mun.ID > 0 ?
                 dao.actualizarUsuario(mun) :
                  dao.agregarUsuario(mun);

            return Redirect("~/BackEnd/Index");
        }

    }
}