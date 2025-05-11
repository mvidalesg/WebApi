using Microsoft.EntityFrameworkCore;
using ShoppingApi.DAL.Entities;

namespace ShoppingApi.DAL
{
    public class DataBaseContext : DbContext
    {
        // asi me conecto a la base de datos por medio de este constructor
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        //este es el emtodo que es propio de EF Core me sirve para configurar unos indices de cada campo de una tabla en BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); // aqui creo un indice del campo Name de la tabla Country
        }
        #region DbSets
        public DbSet<Country> Countries { get; set; } // esta sera la tabla de paises

        #endregion
    }
}
