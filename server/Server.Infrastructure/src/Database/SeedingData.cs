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
                random.Next(1, 10)/10M,               // weight
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
        return new List<User>
        {
            new User(
                "John",
                "Doe",
                "john.doe@mail.com",
                hashedPassword,
                "Address line 1",
                "Helsinki",
                "Finland",
                "00100",
                Role.Admin,
                salt
            ),
            new User(
                "Jane",
                "Smith",
                "jane.smith@mail.com",
                "P@ssword1",
                "Address line 2",
                "Helsinki",
                "Finland",
                "00100",
                Role.Customer,
                salt
            )
        };
    }
}