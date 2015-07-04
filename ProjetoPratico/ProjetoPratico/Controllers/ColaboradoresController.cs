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
    public class ColaboradoresController : Controller
    {
        private BancoEntities db = new BancoEntities();

        public ActionResult Index()
        {
            if (Session["LoginID"] != null) { return View(db.Colaborador.ToList()); }
            else { return RedirectToAction("Login","Home"); }
            
        }


        public ActionResult Detalhes(int? id)
        {
            if (Session["LoginID"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Colaborador Colaborador = db.Colaborador.Find(id);
                TempData["teste"] = Colaborador.id;
                if (Colaborador == null)
                {
                    return HttpNotFound();
                }
                return View(Colaborador);
            }
            else { return RedirectToAction("Login", "Home"); }
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
        public ActionResult Adicionar([Bind(Include = "id,Nome,cpf,rg,telefone,email,estadoCivil,paginaPessoal,login,senha,ativo,funcao")] Colaborador Colaborador)
        {
            if (ModelState.IsValid)
            {
                db.Colaborador.Add(Colaborador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Colaborador);
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
            Colaborador Colaborador = db.Colaborador.Find(id);
            if (Colaborador == null)
            {
                return HttpNotFound();
            }
            return View(Colaborador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "id,Nome,cpf,rg,telefone,email,estadoCivil,paginaPessoal,login,senha,ativo,funcao")] Colaborador Colaborador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Colaborador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Colaborador);
        }


        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador Colaborador = db.Colaborador.Find(id);
            if (Colaborador == null)
            {
                return HttpNotFound();
            }
            return View(Colaborador);
        }


        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult CorfirmarExclusao(int id)
        {
            Colaborador Colaborador = db.Colaborador.Find(id);
            db.Colaborador.Remove(Colaborador);
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
