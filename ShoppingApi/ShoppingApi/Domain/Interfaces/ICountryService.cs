using ShoppingApi.DAL.Entities;

namespace ShoppingApi.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync(); // una de las tantas firmas de un metodo 
        Task<Country> CreateCountryAsync(Country country);
        Task<Country> GetCountryById(Guid id);
        Task<Country> EditCountryAsync(Country country);
        Task<Country> DeleteCountryAsync(Guid id);

    }
}
