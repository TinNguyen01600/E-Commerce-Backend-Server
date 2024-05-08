using Server.Core.src.Entity;
using Server.Service.src.DTO;

namespace Server.Service.src.ServiceAbstract
{
    public interface IWishlistService
    {
        Task<WishlistReadDto> GetWishlistByIdAsync(Guid id);
        Task<IEnumerable<WishlistReadDto>> GetWishlistByUsersAsync(Guid userId);
        Task<bool> DeleteWishlistByIdAsync(Guid id);
        Task<WishlistReadDto> CreateWishlistAsync(WishlistEditDto wishlist);
        Task<WishlistReadDto> UpdateWishlistByIdAsync(WishlistEditDto wishlist);
        Task<bool> AddProductToWishlishAsync(Guid productId, Guid wishlistId);
        Task<bool> DeleteProductFromWishlishAsync(Guid productId, Guid wishlistId);
    }
}