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

        public ActionResult Index()
        {
            if(Session["userId"] == null) {
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
            return View();
        }

        public ActionResult ListerPost()
        {
            try {

            } catch (IOException e) {
                Console.WriteLine($"Error : '{e}'");
            }
            using (IDal dal = new Dal()) {
                List<Post> posts = dal.ObtientTousLesPosts();
                return View("~/Views/Home/ListerPost.cshtml", posts);
            }
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AjoutUtilisateur(string nom, string prenom, string email, string mdp, Promo promo_id)
        {
            using (IDal dal = new Dal())
            {
                try {
                    dal.AjouterUtilisateur(nom, prenom, email, mdp, promo_id);
                    return View("~/Views/Home/Login.cshtml");
                }catch (IOException e)
                {
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
                    ViewBag.User = user;
                    return View("~/Views/Home/Index.cshtml");
                } catch (IOException e) {
                    Console.WriteLine($"Error : '{e}'");
                }
                    return View("~/Views/Home/Login.cshtml");
            }
        }

        string dateNow = DateTime.Today.ToString("yyyy-MM-dd H:mm:ss");

        [HttpPost, ValidateInput(false)]
        public ActionResult AjoutPost(string texte, Utilisateur utilisateur_id, DateTime dateNow, int likes, int dislikes)
        {
            using (IDal dal = new Dal())
            {
                try {
                    Utilisateur user_id = (Utilisateur)Session["userId"];
                    utilisateur_id = user_id;
                    dal.CreerPost(texte, utilisateur_id, dateNow, likes, dislikes);
                    return View("~/Views/Home/ListerPost.cshtml");
                }  catch (IOException e) {
                    Console.WriteLine($"Error : '{e}'");
                }
                    return View("~/Views/Home/CreerPost.cshtml");
            }
        }
    }
}