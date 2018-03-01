using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolCloudMVC.Reportes;
using SchoolCloudMVC.DAO;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using SchoolCloudMVC.BO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web.Mvc;


namespace SchoolCloudMVC.Controllers
{
    public class UniAdminController : Controller
    {
        UsuarioDAO dao = new UsuarioDAO();
        UsuarioBO bo = new UsuarioBO();
        UniversidadAccseso uniac = new UniversidadAccseso();
        UniversidadDAO unidao = new UniversidadDAO();
        UniversidadCarrera daoUniCarrera = new UniversidadCarrera();
        CarrerasDAO CarreraDAO = new CarrerasDAO();
        CarreraMateriaDAO elite = new CarreraMateriaDAO();

        // GET: UniAdmin
        public ActionResult Index()
        {
            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);
            return View(bo.ID == 0 ? new UniversidadAccseso() : unidao.ObtenerDatosUsuarioUni(bo.ID));
        }
        public ActionResult Mensajes()
        {
            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);
            return View(bo.ID == 0 ? new UniversidadAccseso() : unidao.ObtenerDatosUsuarioUni(bo.ID));
        }
        public ActionResult EnviarMensaje(UniversidadAccseso bo)
        {

            unidao.EnviarMensaje(bo);


            return Redirect("~/BackEnd/MensajesAdmin");
        }
        public ActionResult EliminarMaterias(int id)
        {
            elite.BorrarMateria(id);
            return Content("hecho");
        }
        public ActionResult AgregarCarreraMateriaVergas(UniversidadAccseso bo)
        {
            var r = bo.IDunicarrera > 0 ?
                elite.EditarCarreraMateria(bo):
                elite.AgregarCarreraMateria(bo);
                return Redirect("~/UniAdmin/InfoCarrera_UniAdmin/"+bo.IDcarrera);
    
        }
        public ActionResult AgregarDesempeño(UniversidadAccseso bo)
        {

            if(bo.NombreDesempeño != null)
            {
                elite.AgregarDesempeño(bo);
                return Redirect("~/UniAdmin/InfoCarrera_UniAdmin/" + bo.IDcarrera);
            }
            return Redirect("~/UniAdmin/InfoCarrera_UniAdmin/"+ bo.IDcarrera);
        }
        public ActionResult InfoCarrera_UniAdmin(int ID)
        {

            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);

            return PartialView(ID == 0 ? new UniversidadAccseso() : daoUniCarrera.ObtenerDatosUniversidadCarrera(ID));

            //return View(ID == 0 ? new UniversidadAccseso() : daoUniCarrera.ObtenerDatosUniversidadCarrera(ID));


        }
        public ActionResult Galeria_UniAdmin ()
        {
               if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);
            return View(bo.ID == 0 ? new UniversidadAccseso() : unidao.ObtenerDatosUsuarioUni(bo.ID));
        }
     public ActionResult Blog()
        {
            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);
            return View(bo.ID == 0 ? new UniversidadAccseso() : unidao.ObtenerDatosUsuarioUni(bo.ID));
        }
        public ActionResult agregarpublicacion([Bind(Include = "ID, NombrePublicacion,DescripcionPublicacion, idUniversidad")]UniversidadAccseso bo, HttpPostedFileBase fotopublicacion)
        {
            AreaDAO dao = new AreaDAO();
            if(fotopublicacion != null)
            {
                byte[] imagenData = null;
                var binario = new BinaryReader(fotopublicacion.InputStream);
                
                    imagenData = binario.ReadBytes(fotopublicacion.ContentLength);
                    bo.fotopublicacion = imagenData;
            if(dao.AgregarPublicacion(bo)==0)
                {
                    return Content("<script language='javascript' type='text/javascript'> alert('Publicación exitosa' ); window.location.href='blog';  </script>");
                }
          
            }
            return Content("<script language='javascript' type='text/javascript'> alert('Error' ); window.location.href='blog';  </script>");
        }
        public ActionResult GuardarFotoUniversidad([Bind(Include = "idUniversidad,Descripcion")]UniversidadAccseso VO, HttpPostedFileBase FotoUniversiad)
        {
            if (FotoUniversiad != null || VO.idUniversidad!=0)
            {
                var filename = Path.GetFileName(FotoUniversiad.FileName);
                var path = Path.Combine(Server.MapPath("~/Picture/GaleriaUniversidad/"), filename);
                FotoUniversiad.SaveAs(path);
                VO.FotoUniversiad = filename;
                unidao.GuardarUnGaleriaUniverdad(VO);
              
                   
                    return Redirect("~/UniAdmin/Index");
                
            }
            return Redirect("~/UniAdmin/Index");
        }
        public ActionResult Panel_Admin_Universidad()
        {
            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);
            return View(bo.ID == 0 ? new UniversidadAccseso() : unidao.ObtenerDatosUsuarioUni(bo.ID));
        }
        public ActionResult _NumeroCarreras(int id)
        {
            return View(unidao.NumeroCarrerasAccesoUniversidad(id));
        }

        public ActionResult Carreras_UniAdmin()
        {
            if (Session["ID"] == null)
            {
                return Redirect("~/GUI/Index");
            }

            bo.ID = Convert.ToInt32(Session["ID"]);
            return View(bo.ID == 0 ? new UniversidadAccseso() : unidao.ObtenerDatosUsuarioUni(bo.ID));
        }


        //protected void reportes()
        //{
        //    string ruta = Server.MapPath("~/Reportes/reporte.rpt");
        //    ReportDocument doc = new ReportDocument();
        //    doc.Load(ruta);
        //    Reportes.DataReportes a = new Reportes.DataReportes();
        //    SqlDataAdapter adapter = new SqlDataAdapter();
        //    adapter = CarreraDAO.reports();
        //    adapter.Fill(a, "VistaEventosBack");


        //    doc.SetDataSource(a);
        //    Response.Buffer = false;
        //    Response.ClearContent();
        //    Response.ClearHeaders();

        //    doc.ExportToHttpResponse(ExportOptions.CreatePdfFormatOptions , Response, false, "UTM");
        //}
  
        //public ActionResult Guardar([Bind(Include = "idUniversidad,idgrado,NombreUni")]UniversidadAccseso VO, HttpPostedFileBase FotoCarrera)
        //{
        //    if(FotoCarrera != null && FotoCarrera.ContentLength > 0)
        //    {
        //        byte[]imageData = null;
        //        using (var binaryReader = new BinaryReader(FotoCarrera.InputStream))
        //        {
        //            imageData = binaryReader.ReadBytes(FotoCarrera.ContentLength);
        //        }
        //        VO.FotoCarrera = imageData;
        //    }
        //    if(ModelState.IsValid)
        //    {
        //        CarreraDAO.agrergarrrr( VO);
        //        return Redirect("~/UniAdmin/Index");
        //    }
        //    return View(VO);


        //    //if(boCarrera.ID!=0)
        //    //{

        //    //    CarreraDAO.agrergarrrr(boCarrera);

        //    //    return Redirect("~/UniAdmin/Index");
        //    //}
        //    //if(boCarrera.ID==0)
        //    //{
        //    //    CarreraDAO.agrergarrrr(boCarrera);
        //    //}



        //}


    }
}
