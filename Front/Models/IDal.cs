using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Models
{
    public interface IDal : IDisposable
    {
        void CreerPost(string texte, Utilisateur utilisateur_id, DateTime date, int likes, int dislikes);
        List<Post> ObtientTousLesPosts();
        bool PostExiste(string texte);

        int AjouterUtilisateur(string nom, string prenom, string email, string mdp, Promo promo_id);
        Utilisateur Authentifier(string nom, string mdp);
        Utilisateur ObtenirUtilisateur(int id);
        Promo ObtenirPromo(int id);
        Utilisateur ObtenirUtilisateur(string idStr);
        int ObtenirUtilisateurID(string nom, string mdp);

        //A voir pour l'ajout de likes/dislikes
    }
}