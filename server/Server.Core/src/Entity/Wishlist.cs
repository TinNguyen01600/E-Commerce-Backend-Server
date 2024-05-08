namespace Server.Core.src.Entity
{
    public class Wishlist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; private set; }

        public Wishlist(string name, Guid userId)
        {
            Id = Guid.NewGuid();
            Name = name;
            UserId = userId;
        }
    }
}