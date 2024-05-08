namespace Server.Core.src.Entity
{
    public class Address
    {
        public Guid Id { get; set; }
        public string AddressLine { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Landmark { get; set; }
        public Guid UserId { get; set; }  //???
        public Address(string addressLine, string street, string city, string country, string postcode, string phoneNumber, string firstName, string lastName, string landmark, Guid userId)
        {
            Id = Guid.NewGuid();
            AddressLine = addressLine;
            Street = street;
            City = city;
            Country = country;
            Postcode = postcode;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Landmark = landmark;
            UserId = userId;
        }
    }
}