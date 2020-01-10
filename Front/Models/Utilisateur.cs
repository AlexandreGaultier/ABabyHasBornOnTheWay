using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Front.Models
{
    public class Utilisateur
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nom { get; set; }

        [Required]
        [MaxLength(30)]
        public string Prenom { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string MotDePasse { get; set; }

        [Required]
        public virtual Promo Promo_ID { get; set; }
    }
}
