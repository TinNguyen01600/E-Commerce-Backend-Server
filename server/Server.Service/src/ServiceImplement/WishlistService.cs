using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

namespace Server.Service.src.ServiceImplement
{

    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepo _wishlistRepo;

        public WishlistService(IWishlistRepo wishlistRepo)
        {
            _wishlistRepo = wishlistRepo;
        }
        public Task<bool> AddProductToWishlishAsync(Guid productId, Guid wishlistId)
        {
            throw new NotImplementedException();
        }

        public Task<WishlistReadDto> CreateWishlistAsync(WishlistEditDto wishlist)
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

        public Task<WishlistReadDto> GetWishlistByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WishlistReadDto>> GetWishlistByUsersAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<WishlistReadDto> UpdateWishlistByIdAsync(WishlistEditDto wishlist)
        {
            throw new NotImplementedException();
        }
    }
}