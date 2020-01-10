using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Front.Models
{
    public class Post
    {
        [Column("ID")]
        [Key]
        public int ID { get; set; }

        [Column("Texte")]
        [Required]
        public string Texte { get; set; }

        [Column("Auteur")]
        [Required]
        public virtual Utilisateur Utilisateur_ID { get; set; }

        [Column("DateCréation")]
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required]
        public int Likes { get; set; }

        [Required]
        public int Dislikes { get; set; }
    }
}