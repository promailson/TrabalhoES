using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoPratico.Models;

namespace ProjetoPratico.Controllers
{
    public class UsuariosController : Controller
    {
        private BancoEntities db = new BancoEntities();

        public ActionResult Index()
        {
            return View(db.Usuario.ToList());
        }


        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }


        public ActionResult Adicionar()
        {
            var funcao = new List<SelectListItem> {
              new SelectListItem { Text = "Administrador", Value = "0" },
              new SelectListItem { Text = "Gerente", Value ="1"},
              new SelectListItem { Text = "Moderador", Value ="2"},
              new SelectListItem { Text = "Colaborador", Value ="3"}};
            ViewBag.funcao = funcao;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar([Bind(Include = "id,Nome,cpf,rg,telefone,email,estadoCivil,paginaPessoal,login,senha,ativo,funcao")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }


        public ActionResult Editar(int? id)
        {
            var funcao = new List<SelectListItem> {
              new SelectListItem { Text = "Administrador", Value = "0" },
              new SelectListItem { Text = "Gerente", Value ="1"},
              new SelectListItem { Text = "Moderador", Value ="2"},
              new SelectListItem { Text = "Colaborador", Value ="3"}};
            ViewBag.funcao = funcao;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "id,Nome,cpf,rg,telefone,email,estadoCivil,paginaPessoal,login,senha,ativo,funcao")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }


        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }


        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult CorfirmarExclusao(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
