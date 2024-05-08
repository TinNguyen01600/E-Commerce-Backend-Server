using Server.Core.src.ValueObject;

namespace Server.Core.src.Entity
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public byte[] Salt { get; set; } // random key to hash password
        public Role Role { get; set; }
        // public Guid DefaultAddressId { get; set; }
        public User(
            string firstName,
            string lastName,
            string email,
            string password,
            string addressLine,
            string city,
            string country,
            string postcode,
            Role role,
            byte[] salt
        )
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            AddressLine = addressLine;
            City = city;
            Country = country;
            Postcode = postcode;
            Role = role;
            Salt = salt;
        }
    }

}