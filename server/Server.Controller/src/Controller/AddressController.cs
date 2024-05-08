using Microsoft.AspNetCore.Mvc;
using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

namespace Server.Controller.src.Controller
{

    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly User _user;

        public AddressController(IAddressService addressService, User user)
        {
            _addressService = addressService;
            _user = user;
        }

        [HttpGet("api/v1/addresses")] // define endpoint: /addresses?
        public async Task<IEnumerable<AddressReadDto>> GetAddressesByParamsAsync([FromQuery] QueryOptions options)
        {
            try
            {
                return await _addressService.GetAddressesByParamsAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("api/v1/address/{id}")]
        public async Task<AddressReadDto> GetAddressByIdAsync([FromRoute] Guid id)
        {
            try
            {
                return await _addressService.GetAddressByIdAsync(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("api/v1/address/")]
        public async Task<AddressReadDto> CreateAddressAsync([FromBody] AddressEditDto address)
        {
            try
            {
                return await _addressService.CreateAddressAsync(address);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("api/v1/address/{id}")]
        public async Task<bool> DeleteAddressByIdAsync([FromRoute] Guid id)
        {
            try
            {
                return await _addressService.DeleteAddressByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPatch("api/v1/address/{id}")]
        public async Task<AddressReadDto> UpdateAddressByIdAsync([FromBody] AddressEditDto address)
        {
            try
            {
                return await _addressService.UpdateAddressByIdAsync(address);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch("api/v1/addresses/:id/set_default")]
        public async Task<bool> SetDefaultAddressAsync([FromRoute] Guid addressId)
        {
            try
            {
                return await _addressService.SetDefaultAddressAsync(_user.Id, addressId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("api/v1/addresses/default")]
        public async Task<AddressReadDto> GetDefaultAddressAsync()
        {
            try
            {
                return await _addressService.GetDefaultAddressAsync(_user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

}