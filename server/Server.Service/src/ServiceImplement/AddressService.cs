using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;
using Server.Core.src.Common;

namespace Server.Service.src.ServiceImplement
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepo _addressRepo;

        public AddressService(IAddressRepo addressRepo)
        {
            _addressRepo = addressRepo;
        }
        public Task<AddressReadDto> CreateAddressAsync(AddressEditDto address)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAddressByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AddressReadDto> GetAddressByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressReadDto>> GetAddressesByParamsAsync(QueryOptions options)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressReadDto>> GetAddressesByUsersAsync(Guid addressId)
        {
            throw new NotImplementedException();
        }

        public Task<AddressReadDto> GetDefaultAddressAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetDefaultAddressAsync(Guid userId, Guid addressId)
        {
            throw new NotImplementedException();
        }

        public Task<AddressReadDto> UpdateAddressByIdAsync(AddressEditDto address)
        {
            throw new NotImplementedException();
        }
    }
}