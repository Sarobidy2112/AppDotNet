using Microsoft.EntityFrameworkCore;
using firstProject.Models;

namespace firstProject
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Déclarez vos DbSets ici
        public DbSet <Utilisateur> Users {get;set;}
        public DbSet <Produit> Produits {get;set;}
        public DbSet <Categorie> Categories {get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity <Categorie>()
            .HasMany(p => p.Produits)
            .WithOne(e => e.Categorie)
            .HasForeignKey(e => e.id_cat);
        }
    }
}
