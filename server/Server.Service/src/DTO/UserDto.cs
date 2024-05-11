using Server.Core.src.Entity;
using Server.Core.src.ValueObject;

namespace Server.Service.src.DTO
{
    public class UserReadDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public Role Role { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
    }

    public class UserUpdateDTO
    {
        public string Username { get; set; }
        public string Password { get; private set; }
        public string Avatar { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
    }

    public class UserCreateDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public UserCreateDTO(string username, string email, string password, string avatar)
        {
            Username = username;
            Email = email;
            Password = password;
            Avatar = avatar;
        }
    }
}