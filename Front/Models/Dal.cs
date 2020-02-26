using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Models
{
    public class Dal : IDal
    {
        private ContexteBDD bdd;

        public Dal()
        {
            bdd = new ContexteBDD();
        }

        /* Partie UTILISATEUR */
        #region UTILISATEUR
        public int AjouterUtilisateur(string nom, string prenom, string email, string mdp, Promo promo_id)
        {
            //string motDePasseEncode = EncodeMD5(mdp); to-do : Chercher pour ENcodeMD5
            Utilisateur utilisateur = new Utilisateur { Nom = nom, Prenom = prenom, Email = email, MotDePasse = mdp, Promo_ID = promo_id };
            bdd.Utilisateurs.Add(utilisateur);
            bdd.SaveChanges();
            return utilisateur.ID;
        }

        public Utilisateur Authentifier(string nom, string mdp)
        {
            //string motDePasseEncode = EncodeMD5(mdp);
            return bdd.Utilisateurs.FirstOrDefault(u => u.Prenom == nom && u.MotDePasse == mdp);
        }

        public int ObtenirUtilisateurID(string nom, string mdp)
        {
            Utilisateur utilisateur = bdd.Utilisateurs.FirstOrDefault(u => u.Prenom == nom && u.MotDePasse == mdp);
            return utilisateur.ID;
        }

        public Utilisateur ObtenirUtilisateur(int id)
        {
            return bdd.Utilisateurs.FirstOrDefault(u => u.ID == id);
        }

        public Promo ObtenirPromo(int id)
        {
            return bdd.Promos.FirstOrDefault(p => p.ID == id);
        }

        public Utilisateur ObtenirUtilisateur(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id)) {
                return ObtenirUtilisateur(id);
            }
            return null;
        }

        public List<Utilisateur> ObtientTousLesUtilisateurs()
        {
            return bdd.Utilisateurs.ToList();
        }
        #endregion

        /* Partie POST */
        #region POST

        //public int AjouterUtilisateur(string nom, string prenom, string email, string mdp, Promo promo_id)
        //{
        //    //string motDePasseEncode = EncodeMD5(mdp); to-do : Chercher pour ENcodeMD5
        //    Utilisateur utilisateur = new Utilisateur { Nom = nom, Prenom = prenom, Email = email, MotDePasse = mdp, Promo_ID = promo_id };
        //    bdd.Utilisateurs.Add(utilisateur);
        //    bdd.SaveChanges();
        //    return utilisateur.ID;
        //}


        public void CreerPost(string texte, Utilisateur utilisateur_id, DateTime date, int likes, int dislikes)
        {
            Post post = new Post { Texte = texte, Utilisateur_ID = utilisateur_id, Date = date, Likes = likes, Dislikes = dislikes };
            bdd.Posts.Add(post);
            bdd.SaveChanges();
        }

        public List<Post> ObtientTousLesPosts()
        {
            return bdd.Posts.ToList();
        }

        public bool PostExiste(string texte)
        {
            return bdd.Posts.Any(p => string.Compare(p.Texte, texte, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        public void AddLike(Post postToFind)
        {
            Post post = bdd.Posts.First(p => p.ID == postToFind.ID);
            post.Likes = post.Likes + 1;
            bdd.SaveChanges();
        }

        public void AddDislike(Post postToFind)
        {
            Post post = bdd.Posts.First(p => p.ID == postToFind.ID);
            post.Dislikes = post.Dislikes + 1;
            bdd.SaveChanges();
        }
        #endregion


        public void Dispose()
        {
            bdd.Dispose();
        }
    }
}