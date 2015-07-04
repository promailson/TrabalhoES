using ProjetoPratico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoPratico.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["LoginID"] != null) { return View(); }
            else { return RedirectToAction("Login"); }


        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Colaborador user)
        {
            if (ModelState.IsValid)
            {
                using (BancoEntities db = new BancoEntities())
                {
                    var v = db.Colaborador.Where(a => a.login.Equals(user.login) && a.senha.Equals(user.senha)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LoginID"] = v.id.ToString();
                        Session["NomeLogado"] = v.Nome.ToString();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(user);
        }

        public ActionResult Sair()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

    }
}