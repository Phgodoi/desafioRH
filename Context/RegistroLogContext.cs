using desafioRH.Models;
using Microsoft.EntityFrameworkCore;

namespace desafioRH.Context
{
    public class RegistroLogContext : DbContext   
    {
        public RegistroLogContext(DbContextOptions<RegistroLogContext> options) : base(options) { }

        public DbSet<FuncionarioLog> FuncionarioLogs { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

            modelBuilder.Entity<FuncionarioLog>()
                .Property(f => f.Salario)
                .HasColumnType("decimal(18,2)");



            // Outras configurações...

            base.OnModelCreating(modelBuilder);
        }


    }



}
