namespace Front.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Texte = c.String(nullable: false),
                        DateCréation = c.DateTime(nullable: false),
                        Likes = c.Int(nullable: false),
                        Dislikes = c.Int(nullable: false),
                        Utilisateur_ID_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_ID_ID, cascadeDelete: true)
                .Index(t => t.Utilisateur_ID_ID);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Prenom = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30),
                        MotDePasse = c.String(nullable: false, maxLength: 30),
                        Promo_ID_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Promoes", t => t.Promo_ID_ID, cascadeDelete: true)
                .Index(t => t.Promo_ID_ID);
            
            CreateTable(
                "dbo.Promoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Utilisateur_ID_ID", "dbo.Utilisateurs");
            DropForeignKey("dbo.Utilisateurs", "Promo_ID_ID", "dbo.Promoes");
            DropIndex("dbo.Utilisateurs", new[] { "Promo_ID_ID" });
            DropIndex("dbo.Posts", new[] { "Utilisateur_ID_ID" });
            DropTable("dbo.Promoes");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Posts");
        }
    }
}
