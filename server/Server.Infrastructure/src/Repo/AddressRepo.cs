using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;

namespace Server.Infrastructure.src.Repo
{
    public class AddressRepo : IAddressRepo
    {
        public Task<Address> CreateAddressAsync(Address address)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAddressByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetAddressByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> GetAddressesByParamsAsync(QueryOptions options)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> GetAddressesByUsersAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetDefaultAddressAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetDefaultAddressAsync(User user, Address address)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAddressByIdAsync(Address address)
        {
            throw new NotImplementedException();
        }
    }
}