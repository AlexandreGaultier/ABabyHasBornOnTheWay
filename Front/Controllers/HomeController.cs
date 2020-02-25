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
            // L'utilisateur doit être connecté pour acccéder aux pages
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

        //Depuis le form d'authentification, on vient authentifier un user, et le stocker en session.
        [HttpPost, ValidateInput(false)]
        public ActionResult Authentification(string nom, string mdp)
        {
            using (IDal dal = new Dal())
            {
                try
                {
                    Utilisateur user = dal.Authentifier(nom, mdp);
                    using (var context = new ContexteBDD())
                    {
                        user = context.Utilisateurs.First(u => u.Nom == nom && u.MotDePasse == mdp);
                        ViewBag.user = user;
                        int temp = (int)user.ID;
                        Session["user"] = temp;
                        utilisateur_co_ID = (int)user.ID;
                    }
                    return View("~/Views/Home/Index.cshtml");
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Error : '{e}'");
                }
                return View("~/Views/Home/Login.cshtml");
            }
        }

        public ActionResult ListerPost()
        {
            using (IDal dal = new Dal()) {
                try {
                    //On récupère tout les posts en base + l'utilisateur pour les afficher
                    List<Post> posts = dal.ObtientTousLesPosts();
                    //ViewBag.posts = posts;
                    //Utilisateur auteur = dal.ObtenirUtilisateur((int)Session["user"]); //posts ne retrouve pas l'utilisateur lors de l'affichage
                    //ViewBag.Utilisateur = auteur;
                    //Promo promo = auteur.Promo_ID;
                    //ViewBag.Promo = promo;

                    List<Post> postsTD = new List<Post>();
                    foreach ( Post post in posts)
                    {
                        Post postTD = post;
                        Utilisateur utilisateurTD = post.Utilisateur_ID;
                        Promo promoTD = utilisateurTD.Promo_ID;
                        postTD.Utilisateur_ID = utilisateurTD;
                        postsTD.Add(postTD);
                    }
                    ViewBag.postsTD = postsTD;
                    return View("~/Views/Home/ListerPost.cshtml", posts);
                } catch (IOException e) {
                    Console.WriteLine($"Error : '{e}'");
                    return View("~/Views/Home/ListerPost.cshtml");
                } 
            }
        }

        public ActionResult ListerPostPromo()
        {
            using (IDal dal = new Dal())
            {
                try
                {
                    //On récupère tout les posts en base + l'utilisateur pour les afficher
                    using (var context = new ContexteBDD())
                    {
                        var b1_posts = context.Posts.Where(p => p.Utilisateur_ID.Promo_ID.Libelle == "B1")/*.OrderBy(p => p.Likes)*/;
                        IQueryable<Post> postsb1 = b1_posts;
                        
                        List<Post> postsTDb1 = new List<Post>(); //liste à afficher
                        foreach (Post post in postsb1) //On va rentrer dans chaque post ll'utilisateur et la promo
                        {
                            Post postTD = post;
                            Utilisateur utilisateurTD = post.Utilisateur_ID;
                            Promo promoTD = utilisateurTD.Promo_ID;
                            postTD.Utilisateur_ID = utilisateurTD;
                            postsTDb1.Add(postTD);
                        }
                        ViewBag.postsTDB1 = postsTDb1;

                        var b2_posts = context.Posts.Where(p => p.Utilisateur_ID.Promo_ID.Libelle == "B2");
                        IQueryable<Post> postsb2 = b2_posts;

                        List<Post> postsTDb2 = new List<Post>(); //liste à afficher
                        foreach (Post post in postsb2) //On va rentrer dans chaque post ll'utilisateur et la promo
                        {
                            Post postTD = post;
                            Utilisateur utilisateurTD = post.Utilisateur_ID;
                            Promo promoTD = utilisateurTD.Promo_ID;
                            postTD.Utilisateur_ID = utilisateurTD;
                            postsTDb2.Add(postTD);
                        }
                        ViewBag.postsTDB2 = postsTDb2;

                        var b3_posts = context.Posts.Where(p => p.Utilisateur_ID.Promo_ID.Libelle == "B3");
                        IQueryable<Post> postsb3 = b3_posts;

                        List<Post> postsTDb3 = new List<Post>(); //liste à afficher
                        foreach (Post post in postsb3) //On va rentrer dans chaque post ll'utilisateur et la promo
                        {
                            Post postTD = post;
                            Utilisateur utilisateurTD = post.Utilisateur_ID;
                            Promo promoTD = utilisateurTD.Promo_ID;
                            postTD.Utilisateur_ID = utilisateurTD;
                            postsTDb3.Add(postTD);
                        }
                        ViewBag.postsTDB3 = postsTDb3;

                        var i4_posts = context.Posts.Where(p => p.Utilisateur_ID.Promo_ID.Libelle == "I4");
                        IQueryable<Post> postsi4 = i4_posts;

                        List<Post> postsTDi4 = new List<Post>(); //liste à afficher
                        foreach (Post post in postsi4) //On va rentrer dans chaque post ll'utilisateur et la promo
                        {
                            Post postTD = post;
                            Utilisateur utilisateurTD = post.Utilisateur_ID;
                            Promo promoTD = utilisateurTD.Promo_ID;
                            postTD.Utilisateur_ID = utilisateurTD;
                            postsTDi4.Add(postTD);
                        }
                        ViewBag.postsTDI4 = postsTDi4;

                        var i5_posts = context.Posts.Where(p => p.Utilisateur_ID.Promo_ID.Libelle == "I5");
                        IQueryable<Post> postsi5 = i5_posts;

                        List<Post> postsTDi5 = new List<Post>(); //liste à afficher
                        foreach (Post post in postsi5) //On va rentrer dans chaque post ll'utilisateur et la promo
                        {
                            Post postTD = post;
                            Utilisateur utilisateurTD = post.Utilisateur_ID;
                            Promo promoTD = utilisateurTD.Promo_ID;
                            postTD.Utilisateur_ID = utilisateurTD;
                            postsTDi5.Add(postTD);
                        }
                        ViewBag.postsTDI5 = postsTDi5;


                    }
                    return View("~/Views/Home/ListerPostPromo.cshtml");
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Error : '{e}'");
                    return View("~/Views/Home/ListerPost.cshtml");
                }
            }
        }

        //Depuis le form d'inscription, on vient créer un user
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


        //Depuis le form "justifier un retard", on vient créer un post et return sur la view pour voirs tout les justificatiifs.
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
                    return View("~/Views/Home/Index.cshtml");

                }  catch (IOException e) {
                    Console.WriteLine($"Error : '{e}'");
                }
                    return View("~/Views/Home/CreerPost.cshtml");
            }
        }
    }
}