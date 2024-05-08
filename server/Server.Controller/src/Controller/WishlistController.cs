using Microsoft.AspNetCore.Mvc;
using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

namespace Server.Controller.src.Controller
{

    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;
        private readonly User _user;

        public WishlistController(IWishlistService wishlistService, User user)
        {
            _wishlistService = wishlistService;
            _user = user;
        }

        [HttpGet("api/v1/wishlists")]
        public async Task<IEnumerable<WishlistReadDto>> GetWishlistByUsersAsync()
        {
            try
            {
                return await _wishlistService.GetWishlistByUsersAsync(_user.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("api/v1/wishlist/{id}")]
        public async Task<WishlistReadDto> GetWishlistByIdAsync([FromRoute] Guid id)
        {
            try
            {
                return await _wishlistService.GetWishlistByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("api/v1/wishlist/")]
        public async Task<WishlistReadDto> CreateWishlistAsync([FromBody] WishlistEditDto wishlist)
        {
            try
            {
                return await _wishlistService.CreateWishlistAsync(wishlist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("api/v1/wishlist/{id}")]
        public async Task<bool> DeleteWishlistByIdAsync([FromRoute] Guid id)
        {
            try
            {
                return await _wishlistService.DeleteWishlistByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPatch("api/v1/wishlist/{id}")]
        public async Task<WishlistReadDto> UpdateWishlistByIdAsync([FromBody] WishlistEditDto wishlist)
        {
            try
            {
                return await _wishlistService.UpdateWishlistByIdAsync(wishlist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("api/v1/wishlists/{id}")]
        public async Task<bool> AddProductToWishlishAsync([FromBody] Guid productId, [FromRoute] Guid wishlistId)
        {
            try
            {
                return await _wishlistService.AddProductToWishlishAsync(productId, wishlistId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("api/v1/wishlists/{id}/{product_id}")]
        public async Task<bool> DeleteProductFromWishlishAsync([FromRoute] Guid wishlistId, [FromRoute] Guid productId)
        {
            try
            {
                return await _wishlistService.DeleteProductFromWishlishAsync(productId, wishlistId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

}