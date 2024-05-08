namespace Server.Core.src.Entity
{
    public class WishlistItem
    {
        public Guid ProductId { get; set; }
        public Guid WishlistId { get; set; }
        public WishlistItem(Guid productId, Guid wishlistId)
        {
            ProductId = productId;
            WishlistId = wishlistId;
        }
    }
}