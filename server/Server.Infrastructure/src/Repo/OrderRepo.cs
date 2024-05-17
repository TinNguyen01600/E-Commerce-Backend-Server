using Microsoft.EntityFrameworkCore;
using Server.Core.Entity;
using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Infrastructure.src.Database;
using Server.Infrastructure.src.Repository;
using Server.Service.src.Shared;

namespace Server.Infrastructure.src.Repo;

public class OrderRepo : BaseRepo<Order>, IOrderRepo
{
    private DbSet<Product> _products;
    public OrderRepo(AppDbContext databaseContext) : base(databaseContext)
    {
        _products = databaseContext.Products;
    }

    public override async Task<Order> CreateOneAsync(Order order)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                foreach (var orderProduct in order.OrderProducts)
                {
                    var foundProduct = _products.First(product => product == orderProduct.Product);
                    if (foundProduct.Inventory >= orderProduct.Quantity)
                    {
                        Console.WriteLine($"BEFORE ____ {foundProduct.Inventory}");
                        foundProduct.Inventory -= orderProduct.Quantity;
                        Console.WriteLine($"AFTER ____ {foundProduct.Inventory}");
                        _products.Update(foundProduct);
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw CustomException.BadRequestException("Product out of inventory");
                    }
                }
                _data.Add(order);
                _context.SaveChanges();
                transaction.Commit();
                return order;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                transaction.Rollback();
                throw;
            }
        }
    }

    public override async Task<IEnumerable<Order>> GetAllAsync(QueryOptions options)
    {
        return _data.Include("User").Include(o => o.OrderProducts).ThenInclude(o => o.Product).Skip(options.PageNo).Take(options.PageSize).ToArray();
    }

    public override async Task<Order> GetOneByIdAsync(Guid id)
    {
        var allData = _data.Include("User").Include(o => o.OrderProducts).ThenInclude(o => o.Product);
        return allData.FirstOrDefault(order => order.Id == id);
    }

    public async Task<IEnumerable<Order>> GetByUser(Guid userId)
    {
        return _data.Include("User").Include(o => o.OrderProducts).ThenInclude(o => o.Product).Where(orders => orders.User.Id == userId).ToArray();
    }
}