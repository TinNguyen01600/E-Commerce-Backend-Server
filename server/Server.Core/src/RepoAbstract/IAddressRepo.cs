using Server.Core.src.Entity;
using Server.Core.src.Common;

namespace Server.Core.src.RepoAbstract
{
    public interface IAddressRepo
    {
        Task<Address> GetAddressByIdAsync(Guid id);
        Task<IEnumerable<Address>> GetAddressesByUsersAsync(Guid userId);
        Task<IEnumerable<Address>> GetAddressesByParamsAsync(QueryOptions options);
        Task<bool> UpdateAddressByIdAsync(Address address);
        Task<bool> DeleteAddressByIdAsync(Guid id);
        Task<Address> CreateAddressAsync(Address address);
        Task<bool> SetDefaultAddressAsync(User user, Address address);
        Task<Address> GetDefaultAddressAsync(User user);
    }
}