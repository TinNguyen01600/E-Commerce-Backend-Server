using Server.Core.src.Entity;
using Server.Service.src.DTO;
using Server.Core.src.Common;

namespace Server.Service.src.ServiceAbstract
{
    public interface IAddressService
    {
        Task<AddressReadDto> GetAddressByIdAsync(Guid id);
        Task<IEnumerable<AddressReadDto>> GetAddressesByUsersAsync(Guid addressId);
        Task<IEnumerable<AddressReadDto>> GetAddressesByParamsAsync(QueryOptions options);

        Task<AddressReadDto> UpdateAddressByIdAsync(AddressEditDto address);
        Task<bool> DeleteAddressByIdAsync(Guid id);
        Task<AddressReadDto> CreateAddressAsync(AddressEditDto address);
        Task<bool> SetDefaultAddressAsync(Guid userId, Guid addressId);
        Task<AddressReadDto> GetDefaultAddressAsync(User user);
    }
}