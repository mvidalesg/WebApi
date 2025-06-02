using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ShoppingApi.DAL;
using ShoppingApi.DAL.Entities;
using ShoppingApi.Domain.Interfaces;
namespace ShoppingApi.Domain.Services
{
    public class countryService : ICountryService
    {
        private readonly DataBaseContext _context;

        public countryService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            try
            {
                var countries = await _context.Countries.Include(c=> c.States) .ToListAsync();
                
                
                return countries;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
       
        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
                // otras dos formas de traerme un objeto desde la BD
                var country1 = await _context.Countries.FindAsync(id);
                var country2 = await _context.Countries.FirstAsync(c => c.Id == id);

                return country;
            }
            catch (DbUpdateException dbUpdateException)

            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;
                _context.Countries.Add(country); // el metodo add() me permite crear el objeto en el contexto de mi bBD 

                await _context.SaveChangesAsync(); // este metodo me permiye guardar el pais en mi tabla COUNTRY

                return country;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;

                _context.Countries.Update(country); // virtualizo mi objeto 
                await _context.SaveChangesAsync();

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await GetCountryByIdAsync(id);

                if (country == null)
                {
                    return null;
                }

                _context.Countries.Remove(country); // creacion del query #delete from Countries where Id = id
                await _context.SaveChangesAsync(); // la ejecucion del query

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}