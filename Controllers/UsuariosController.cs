using CRUD_MVC_PARCIAL2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CRUD_MVC_PARCIAL2.Controllers
{
    public class UsuariosController : Controller
    {
        UsuariosDAL _UsuariosDalc = new UsuariosDAL();
        // GET: Usuarios
        public ActionResult Index()
        {

            List<Usuarios> usuarioslst = new List<Usuarios>() {
            new Usuarios(){ ESTADO_CIVIL = "SOLTERO", Text = "SOLTERO" },
            new Usuarios(){ ESTADO_CIVIL = "CASADO", Text = "CASADO" }
            };

            StringBuilder sb = new StringBuilder();

            foreach (var type in usuarioslst)
            {
                sb.Append("<option value='" + type.ESTADO_CIVIL + "'>" + type.Text + "</option>");
            }

            ViewBag.usuario = sb.ToString();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuarios oUsuarios)
        {

            if (ModelState.IsValid)
            {
                _UsuariosDalc.AgregarUsuarios(oUsuarios);
                return RedirectToAction("Index");
            }
            else
            {
                return View();

            }
        }
        public ActionResult Create()
        {
            List<Usuarios> Usuarioslst = new List<Usuarios>();
            Usuarios usuarios = new Usuarios();
            usuarios.Text = "SOLTERO";
            usuarios.Value = "SOLTERO";
            Usuarioslst.Add(usuarios);
            Usuarios usuarios2 = new Usuarios();
            usuarios2.Text = "CASADO";
            usuarios2.Value = "CASADO";
            Usuarioslst.Add(usuarios2);

            ViewBag.Usuarioslst = new SelectList(Usuarioslst, "Text", "Value");

            return View();

        }

        public ActionResult Registros()
        {
            List<Usuarios> lstUsuarios = new List<Usuarios>();
            lstUsuarios = _UsuariosDalc.ListarUsuarios().ToList();

            return View(lstUsuarios);
        }

        public ActionResult Delete(int id)
        {
            Usuarios _usuarios = _UsuariosDalc.ObtenerDatosUsuario(id);
            return View(_usuarios);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                _UsuariosDalc.BorrarUsuarios(id);
                return RedirectToAction("Registros");
            }
            catch (Exception)
            {

                return View();
            }

        }

        public ActionResult Edit(int? id)
        {
          


         
            Usuarios oUsuarios = _UsuariosDalc.ObtenerDatosUsuario(id);
            List<Usuarios> usuarioslst = new List<Usuarios>() {
            new Usuarios(){ ESTADO_CIVIL = "SOLTERO", Text = "SOLTERO" },
            new Usuarios(){ ESTADO_CIVIL = "CASADO", Text = "CASADO" }
            };


            StringBuilder sb = new StringBuilder();

            string _strSelected = "";

            foreach (var type in usuarioslst)
            {


                if (oUsuarios.ESTADO_CIVIL == type.ESTADO_CIVIL)
                {
                    _strSelected = "selected";
                }
                else
                {
                    _strSelected = "";
                }

                sb.Append("<option value='" + type.ESTADO_CIVIL + "' " + _strSelected + " >" + type.Text + "</option>");
            }




            ViewBag.usuario = sb.ToString();
            return View(oUsuarios);
        }

        [HttpPost]
        public ActionResult Edit(int id, Usuarios oUsuarios)
        {

            if (ModelState.IsValid)
            {
                _UsuariosDalc.ModificarUsuarios(oUsuarios);
                return RedirectToAction("Registros");
            }
            else
            {
               return View(oUsuarios);
            }

        }

    }
}