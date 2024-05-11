using System.ComponentModel.DataAnnotations;
using Server.Core.src.ValueObject;

namespace Server.Core.src.Entity
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "User name is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public byte[] Salt { get; set; } // random key to hash password
        public Role Role { get; set; }
        public User(
            string username,
            string email,
            string password,
            string avatar,
            string addressLine,
            string city,
            string country,
            string postcode,
            Role role,
            byte[] salt
        )
        {
            Username = username;
            Email = email;
            Password = password;
            Avatar = avatar;
            AddressLine = addressLine;
            City = city;
            Country = country;
            Postcode = postcode;
            Role = role;
            Salt = salt;
        }
    }

}