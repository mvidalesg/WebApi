using Microsoft .AspNetCore.SignalR;
using ShoppingApi.DAL.Entities;

namespace ShoppingApi.Domain.Interfaces
{
    public interface ICountryService
    {
        // una de las tantas firmas de un metodo 
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task<Country> GetCountryByIdAsync(Guid id);
        Task<Country> CreateCountryAsync(Country country);
        Task<Country> EditCountryAsync(Country country);
        Task<Country> DeleteCountryAsync(Guid id);

    }
}
