using Microsoft.EntityFrameworkCore;
using WebApp0.Model;

namespace WebApp0.Data
{
    public class ProduitContext : DbContext 
    {
        public ProduitContext(DbContextOptions<ProduitContext> options) 
            :base(options)
        {

        }

        public DbSet<Produit> Produits { get; set; } 
        public DbSet<ProduitQl> ProduitQls { get; set; } 

        public DbSet<Command> Commands { get; set; } 


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog=WebApp0;Integrated Security=True");

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Produit>().ToTable("Produit");
            modelBuilder.Entity<ProduitQl>().HasOne<Produit>(q => q.Produit);
            //.WithMany(b => b.ProduitQls)
            //.OnDelate(DeleteBehavior.Cascade);

            //.HasForeignKey(b => b.ProduitId)
            //.HasIndex(b => b.ProduitId);
            modelBuilder.Entity<Command>().HasMany<ProduitQl>(e => e.ProduitQl);
            //.WithMany(p => p.Command);

            //modelBuilder.Entity<Produit>().HasMany<ProduitQl>(e => e.ProduitQl);
        }
    }
}
