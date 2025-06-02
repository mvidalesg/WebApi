using ShoppingApi.DAL;
using ShoppingApi.DAL.Entities;
using System.Runtime.Serialization;
using WebApi.DAL.Entities;
namespace WebApi.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;
       

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }
        // crearemos un metodo llamado SeedrAsync 
        // este metodo es una especie de MAIN()
        // este metodo tendra la resposbilidad de propoblar mis diferentes tablas de la base de datos

        public async Task SeedAsync()
        {
            // primero agregare un metodo propio de EF que hace las veces de comando update-database
            // en otras palabras: un metodo que crea la BD inmeditamente ponga en ejecucion mi API
            await _context.Database.EnsureCreatedAsync();

            // a partir de aqui vamos a ir creando metodod que me sirvan para prepoblar mi BD
            await PopulateCountriesAsync();

            await _context.SaveChangesAsync(); // este metodo es propio de EF Core y me permite guardar los cambios en la BD

        }
        #region Private Methos
        private async Task PopulateCountriesAsync()
        {
            // el metodo Any () me indica si a tabla countries tiene el menos un registro
            // ele metodo Any negada (!) me indica que no hay absolutamente nada en la tabla Countries
            
            if (!_context.Countries.Any())
            {
                // asi creo yo un objeto pais con sus respectivos estados 
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Antioquia"

                        },

                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Cundinamarca"

                        }

                    }

                });

                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Argentina",
                    States = new List<State>()
                    {
                        new State
                    {
                        CreatedDate = DateTime.Now,
                        Name = "Buenos Aires"
                    }


                    }

                });

            }
        }
    }
    #endregion
}