using Server.Core.Entity;
using Server.Core.src.Entity;
using Server.Core.src.ValueObject;
using Server.Service.src.Shared;

namespace Server.Infrastructure.src.Database;

public class SeedingData
{
    private static Random random = new Random();

    private static Category category1 = new Category("Electronics", $"https://picsum.photos/200/?random={random.Next(10)}");
    private static Category category2 = new Category("Clothing", $"https://picsum.photos/200/?random={random.Next(10)}");
    private static Category category3 = new Category("Home and Furnitures", $"https://picsum.photos/200/?random={random.Next(10)}");
    private static Category category4 = new Category("Books", $"https://picsum.photos/200/?random={random.Next(10)}");
    private static Category category5 = new Category("Toys and Games", $"https://picsum.photos/200/?random={random.Next(10)}");
    private static Category category6 = new Category("Sports", $"https://picsum.photos/200/?random={random.Next(10)}");


    public static List<Category> GetCategories()
    {
        return new List<Category>
        {
            category1, category2, category3, category4, category5, category6
        };
    }

    private static List<Product> GenerateProductsForCategory(Category category, int count)
    {
        var products = new List<Product>();
        for (int i = 1; i <= count; i++)
        {
            var product = new Product(
                $"{category.Name} product {i}",
                random.Next(1000),      // price
                $"Description of {category.Name} product {i}",
                random.Next(10),        // inventory
                random.Next(1, 10) / 10M,               // weight
                category.Id
            );

            products.Add(product);
        }
        return products;
    }

    public static List<Product> GetProducts()
    {
        var products = new List<Product>();
        products.AddRange(GenerateProductsForCategory(category1, 20));
        products.AddRange(GenerateProductsForCategory(category2, 20));
        products.AddRange(GenerateProductsForCategory(category3, 20));
        products.AddRange(GenerateProductsForCategory(category4, 20));
        products.AddRange(GenerateProductsForCategory(category5, 20));
        products.AddRange(GenerateProductsForCategory(category6, 20));
        return products;
    }

    public static List<Product> Products = GetProducts();

    public static List<ProductImage> GetProductImages()
    {
        var productImages = new List<ProductImage>();
        foreach (var product in Products)
        {
            for (int i = 0; i < 3; i++)
            {
                var productImage = new ProductImage
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Url = $"https://picsum.photos/200/?random={random.Next(100, 1000)}",
                    ProductId = product.Id
                };
                productImages.Add(productImage);
            }
        }
        return productImages;
    }

    public static List<User> GetUsers()
    {
        PasswordService.HashPassword("SuperAdmin1234", out string hashedPassword, out byte[] salt);
        PasswordService.HashPassword("letmein", out string hashedPassword1, out byte[] salt1);
        PasswordService.HashPassword("securepassword", out string hashedPassword2, out byte[] salt2);
        PasswordService.HashPassword("SunnyDay2024!", out string hashedPassword3, out byte[] salt3);
        PasswordService.HashPassword("PurpleRain#75", out string hashedPassword4, out byte[] salt4);
        PasswordService.HashPassword("CoffeeLover$19", out string hashedPassword5, out byte[] salt5);

        return new List<User>
        {
            new User(
                "John_Doe",
                "john.doe@mail.com",
                hashedPassword,
                $"https://picsum.photos/200/?random={random.Next(100, 1000)}",
                "Address line 1",
                "Helsinki",
                "Finland",
                "00100",
                Role.Admin,
                salt
            ),
            new User(
                "Jane_Smith",
                "jane.smith@mail.com",
                hashedPassword1,
                $"https://picsum.photos/200/?random={random.Next(100, 1000)}",
                "Address line 2",
                "Helsinki",
                "Finland",
                "00100",
                Role.Customer,
                salt1
            ),
            new User(
                "bob_jones",
                "bob.jones@example.com",
                hashedPassword2,
                $"https://picsum.photos/200/?random={random.Next(100, 1000)}",
                "Address line 3",
                "Helsinki",
                "Finland",
                "00100",
                Role.Customer,
                salt2
            ),
            new User(
                "sarah_lee",
                "sarah.lee@example.com",
                hashedPassword3,
                $"https://picsum.photos/200/?random={random.Next(100, 1000)}",
                "Address line 4",
                "Helsinki",
                "Finland",
                "00100",
                Role.Customer,
                salt3
            ),
            new User(
                "michael_jones",
                "michael_jones@example.com",
                hashedPassword4,
                $"https://picsum.photos/200/?random={random.Next(100, 1000)}",
                "Address line 5",
                "Helsinki",
                "Finland",
                "00100",
                Role.Customer,
                salt4
            ),
            new User(
                "david_cooler",
                "david.cooler@example.com",
                hashedPassword5,
                $"https://picsum.photos/200/?random={random.Next(100, 1000)}",
                "Address line 6",
                "Helsinki",
                "Finland",
                "00100",
                Role.Customer,
                salt5
            )
        };
    }
    public static List<User> Users = GetUsers();

    // ------------------------------------------------------------------------------------------------------------------
    public static List<Order> GetOrders()
    {
        return new List<Order>{
            new Order(Users[1].Id, Status.completed),
            new Order(Users[1].Id, Status.cancelled),
            new Order(Users[2].Id, Status.pending),
            new Order(Users[2].Id, Status.cancelled),
            new Order(Users[3].Id, Status.delivered),
            new Order(Users[3].Id, Status.processing),
            new Order(Users[4].Id, Status.shipped),
            new Order(Users[4].Id, Status.completed),
            new Order(Users[5].Id, Status.delivered),
            new Order(Users[5].Id, Status.delivered)
        };
    }
    public static List<Order> Orders = GetOrders();
    public static List<OrderProduct> GetOrderProducts()
    {
        var OrderProducts = new List<OrderProduct>();
        for (int i = 0; i < Orders.Count(); i++)
        {
            for (int j = 0; j < 2; j++)
            {
                var orderProduct = new OrderProduct {Product = Products[i+j], Quantity = random.Next(15)};
                OrderProducts.Add(orderProduct);
            }
        }
        return OrderProducts;
    }
    // public static List<Review> GetReviews()
    // {
    //     throw new NotImplementedException();
    // }

}