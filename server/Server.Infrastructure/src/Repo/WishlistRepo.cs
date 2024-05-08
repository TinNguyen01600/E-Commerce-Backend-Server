using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;

namespace Server.Infrastructure.src.Repo
{
    public class WishlistRepo : IWishlistRepo
    {
        public Task<bool> AddProductToWishlishAsync(Guid productId, Wishlist wishlist)
        {
            throw new NotImplementedException();
        }

        public Task<Wishlist> CreateWishlistAsync(Wishlist wishlist)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductFromWishlishAsync(Guid productId, Guid wishlistId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteWishlistByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Wishlist> GetWishlistByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Wishlist>> GetWishlistByUsersAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateWishlistByIdAsync(Wishlist wishlist)
        {
            throw new NotImplementedException();
        }
    }
}