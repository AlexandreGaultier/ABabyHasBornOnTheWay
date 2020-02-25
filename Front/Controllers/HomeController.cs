using Front.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front.Controllers
{
    public class HomeController : Controller
    {
        public int utilisateur_co_ID;

        public ActionResult Index()
        {
            if(Session["user"] == null) {
                return View("~/Views/Home/Login.cshtml");
            } else {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Inscription()
        {
            return View();
        }

        public ActionResult CreerPost()
        {
            if (Session["user"] == null) {
                return View("~/Views/Home/Login.cshtml");
            } else {
                return View();
            }
        }

        public ActionResult ListerPost()
        {
            using (IDal dal = new Dal()) {
                try {
                        List<Post> posts = dal.ObtientTousLesPosts();
                    ViewBag.posts = posts;
                        return View("~/Views/Home/ListerPost.cshtml", posts);
                } catch (IOException e) {
                    Console.WriteLine($"Error : '{e}'");
                    return View("~/Views/Home/ListerPost.cshtml");
                } 
            }
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AjoutUtilisateur(string nom, string prenom, string email, string mdp, int INTpromo_id) {
            using (IDal dal = new Dal()) {
                    try {
                    using (var context = new ContexteBDD()) {
                        Promo promo_id = context.Promos.First(p => p.ID == INTpromo_id);
                        dal.AjouterUtilisateur(nom, prenom, email, mdp, promo_id);
                        return View("~/Views/Home/Login.cshtml");
                    }
                    } catch (IOException e) {
                        Console.WriteLine($"Error : '{e}'");
                    }
                    return View("~/Views/Home/Inscription.cshtml");
            }
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Authentification(string nom, string mdp)
        {
            using (IDal dal = new Dal())
            {
                try {
                    Utilisateur user =  dal.Authentifier(nom, mdp);
                    using (var context = new ContexteBDD())
                    {
                        user = context.Utilisateurs.First(u => u.Nom == nom && u.MotDePasse == mdp);
                        ViewBag.user = user;
                        int temp = (int)user.ID;
                        Session["user"] = temp;
                        utilisateur_co_ID = (int)user.ID;
                    }
                    return View("~/Views/Home/Index.cshtml");
                } catch (IOException e) {
                    Console.WriteLine($"Error : '{e}'");
                }
                    return View("~/Views/Home/Login.cshtml");
            }
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AjoutPost(string texte)
        {
            using (IDal dal = new Dal())
            {
                try {
                    using (var context = new ContexteBDD())
                    {
                    Utilisateur utilisateur_id = dal.ObtenirUtilisateur((int)Session["user"]);
                    DateTime dateNow = DateTime.Now;
                    int likes = 0;
                    int dislikes = 0;
                    dal.CreerPost(texte, utilisateur_id, dateNow, likes, dislikes);
                    ViewBag.texte = texte;
                    ViewBag.utilisateur_id = utilisateur_id;
                    ViewBag.dateNow = dateNow;
                    ViewBag.likes = likes;
                    ViewBag.dislikes = dislikes;
                    }
                    return View("~/Views/Home/ListerPost.cshtml");

                }  catch (IOException e) {
                    Console.WriteLine($"Error : '{e}'");
                }
                    return View("~/Views/Home/CreerPost.cshtml");
            }
        }
    }
}