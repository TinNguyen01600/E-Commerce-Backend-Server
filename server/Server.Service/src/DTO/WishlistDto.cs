using Server.Core.src.Entity;

namespace Server.Service.src.DTO
{
    public class WishlistReadDto
    {
        public string Name { get; set; }
        public void Transform(Wishlist wishlist)
        {
            Name = wishlist.Name;
        }
    }

    public class WishlistEditDto
    {
        public string Name { get; set; }
        public WishlistEditDto(string name)
        {
            Name = name;
        }

        public Wishlist UpdateWishlist(Wishlist oldWishlist)
        {
            oldWishlist.Name = Name;
            return oldWishlist;
        }
        public Wishlist CreateWishlist(Guid userId)
        {
            return new Wishlist(Name, userId);
        }
    }
}