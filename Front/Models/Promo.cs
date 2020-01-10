using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Front.Models
{
    public class Promo
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Libelle { get; set; }
    }
}