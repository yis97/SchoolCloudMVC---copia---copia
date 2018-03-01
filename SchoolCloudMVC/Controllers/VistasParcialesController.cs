using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCloudMVC.Models;
using SchoolCloudMVC.BO;
using System.Drawing;
using System.Collections;
using System.Drawing.Imaging;
using System.IO;
using SchoolCloudMVC.DAO;

namespace SchoolCloudMVC.Controllers
{
    public class VistasParcialesController : Controller
    {
        // GET: VistasParciales
        UniversidadCarrera daoCARRERAUniversidad = new UniversidadCarrera();
        UsuarioBO bo = new UsuarioBO();
        BackendDAO adminDAO = new BackendDAO();
        BackendBO adminBO = new BackendBO();
        PaisDAO paisDAO = new PaisDAO();
        CicloEscolar ciclo = new CicloEscolar();
        UsuarioDAO userDAO = new UsuarioDAO();
        UniversidadAccseso boa = new UniversidadAccseso();
        UniversidadDAO unidao = new UniversidadDAO();
        CarrerasDAO CarreraDAO = new CarrerasDAO();
        CarreraMateriaDAO carreraMaterida = new CarreraMateriaDAO();
        GradoDAO dao = new GradoDAO();
        public ActionResult TipoGradoEstudios()
        {
            Modelo_TipoGrado viewModel = new Modelo_TipoGrado();
            viewModel.TipoGrado = dao.listatipogrado();
            return PartialView(viewModel);
        }
        public ActionResult GradoEstudios(int ID)
        {
            Session["id"] = ID;
            return View(unidao.ObtenerDatosGradoEstudios(ID));
        }
        public ActionResult _ListaUniversidades()
        {
            Modelo_ListaUniversidad viewModel = new Modelo_ListaUniversidad();
            viewModel.NombreUniversidad = unidao.ListaUniversidades();
            return PartialView(viewModel);
        }
        public ActionResult _ListaCicloEscolar()
        {
            ModeloTipoCicloEscolar obj = new ModeloTipoCicloEscolar();
            obj.TipoCilcoEscolar = ciclo.listaCicloEscolar();
            return PartialView(obj);
        }
        public ActionResult NombreCarrera()
        {
            bo.ID = Convert.ToInt32(Session["ID"]);
            return View(bo.ID == 0 ? new UniversidadAccseso() : unidao.ObtenerDatosUsuarioUni(bo.ID));
        }
        public ActionResult EliminarMaterias(int id)
        {
            carreraMaterida.BorrarMateria(id);
            return Content("hecho");
        }
        public ActionResult _TablaUniversidades()
        {
            return View(unidao.VistaTablaUniversidad());
        }
        public ActionResult _TablaDirecciones()
        {
            return View(userDAO.VistaTablaDirecciones());
        }
        public ActionResult _TablaUsuariosAdmin()
        {
           
            return View(userDAO.VistaTablaUsuario());
        }
        public ActionResult _TablasMateriasCarreras(int ID)
        {
            return View(carreraMaterida.TablaMATERIAS(ID));
        }
        public ActionResult _CarreasUniversidades(int ID = 0)
        {
            return View(ID == 0 ? new UniversidadCarreraBO() : daoCARRERAUniversidad.ObtenerDatosUniversidadCarrera2(ID));

        }
        public ActionResult _GaleriaUniversidadUniAdmin(int ID)
        {
            return PartialView(unidao.ObtenerDatosGaleriaUniversidad(ID));
        }
        [HttpPost]
        public ActionResult Guardar(Carreras boCarrera)
        {
            var r = boCarrera.ID > 0 ?
              CarreraDAO.ModificarCarrera(boCarrera) :
              CarreraDAO.AgregarCarrera(boCarrera);

            return Redirect("~/UniAdmin/Index");
        }

        //public ActionResult GuardarCarreraMateri ()
        //{
        //    CarrerasMaterias bo = new CarrerasMaterias();

        //     var r = bo.IDCarrerateria >0?

        //    return
        //}
        public ActionResult _Fotocarrera(int ID)
        {

            return View(ID == 0 ? new UniversidadCarreraBO() : daoCARRERAUniversidad.ObtenerDatosUniversidadCarrera2(ID));



        }
        public ActionResult GuardarFoto([Bind(Include = "idUniversidad,idgrado,NombreUni,Descripcion")]UniversidadAccseso VO, HttpPostedFileBase FotoCarrera)
        {
            if (FotoCarrera != null)
            {
                var filename = Path.GetFileName(FotoCarrera.FileName);
                var path = Path.Combine(Server.MapPath("~/Picture/ImagenesCarrera/"), filename);
                FotoCarrera.SaveAs(path);
                VO.FotoCarrera = filename;
                CarreraDAO.agrergarrrr(VO);
                return Redirect("~/UniAdmin/Index");
                //if (FotoCarrera != null && FotoCarrera.ContentLength > 0)
                //{
                //    byte[] imageData = null;
                //    using (var binaryReader = new BinaryReader(FotoCarrera.InputStream))
                //    {
                //        imageData = binaryReader.ReadBytes(FotoCarrera.ContentLength);
                //    }
                //    VO.FotoCarrera = imageData;
                //}
                //if (ModelState.IsValid)
                //{
                //    CarreraDAO.agrergarrrr(VO);
                //    return Redirect("~/UniAdmin/Index");
                //}
                //return View(VO);
            }
            return Redirect("~/UniAdmin/Index");
        }


        public ActionResult _TablaUniversidadCarreras(int ID)
        {
            return View(CarreraDAO.TablaCarreras(ID));
        }
        public ActionResult Publicaciones(int ID)
        {
            AreaDAO ddsao=  new AreaDAO();
            return View(ddsao.PUBLICACIONEDS(ID));
        }
        public ActionResult _ListaCarreras(int ID)
        {
            return PartialView(CarreraDAO.TablaCarreras(ID));
        }
        public ActionResult _ListaPaises()
            
        {
            Modelo_Pais obj = new Modelo_Pais();
            obj.Pais = paisDAO.ListaPaises();
            return PartialView(obj);
        }
        public ActionResult _ListaEstados(string id)
        {
            Modelo_Pais obj = new Modelo_Pais();
            obj.Estado = paisDAO.ListaEstado(id);
            return PartialView(obj);
        }
        public ActionResult _ListaCiudad(string id)
        {
            Modelo_Pais obj = new Modelo_Pais();
            obj.ciudad = paisDAO.ListaCiudad(id);
            return PartialView(obj);
        }
        public ActionResult _TipoArea()
        {
            AreaDAO dao = new AreaDAO();
            Modelo_TipoArea obj = new Modelo_TipoArea();
            obj.Area = dao.ListaCiudad();
            return PartialView(obj);
        }
        public ActionResult _MensajesAdministrador(int ID)
        {
            return View(adminDAO.MensajesContacto(ID));
        }
        public ActionResult _ChatBackend(int ID)
        {
            int misbolas = Convert.ToInt32(Session["ID"]);
            return View(adminDAO.chat(misbolas, ID));
        }
        public ActionResult _TipoUniversidad()
        {
            Modelo_TipoUniverisdad viewModel = new Modelo_TipoUniverisdad();
            viewModel.TipoUniversidad = adminDAO.listatipogrado();
            return PartialView(viewModel);
   
        }
    }


    }
