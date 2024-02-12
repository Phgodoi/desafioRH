using desafioRH.Models;
using Microsoft.EntityFrameworkCore;

namespace desafioRH.Context
{
    public class RecursosHumanosContext : DbContext
    {
        public RecursosHumanosContext(DbContextOptions<RecursosHumanosContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }
   



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()
                .Property(f => f.Salario)
                .HasColumnType("decimal(18,2)");           
        

            // Outras configurações...

            base.OnModelCreating(modelBuilder);
        }



    }
}
