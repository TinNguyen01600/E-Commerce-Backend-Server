using Server.Core.src.Entity;

namespace Server.Core.src.RepoAbstract
{
    public interface IWishlistRepo
    {
        Task<Wishlist> GetWishlistByIdAsync(Guid id);
        Task<IEnumerable<Wishlist>> GetWishlistByUsersAsync(Guid userId);
        Task<bool> DeleteWishlistByIdAsync(Guid id);
        Task<Wishlist> CreateWishlistAsync(Wishlist wishlist);
        Task<bool> UpdateWishlistByIdAsync(Wishlist wishlist);
        Task<bool> AddProductToWishlishAsync(Guid productId, Wishlist wishlist);
        Task<bool> DeleteProductFromWishlishAsync(Guid productId, Guid wishlistId);
    }
}