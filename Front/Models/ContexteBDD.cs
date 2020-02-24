using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Front.Models
{
    public class ContexteBDD : DbContext
    {
        public ContexteBDD() : base("DbContext")
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Promo> Promos { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
    }
}