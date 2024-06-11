using Microsoft.EntityFrameworkCore;
using Pryaniky.Data;
using Pryaniky.Domain;

namespace Pryaniky.Business;

public class OrderService(PryanikyDbContext dbContext) : IOrderService
{
    private readonly PryanikyDbContext _dbContext = dbContext;

    public async Task<OrderGetDto> GetById(Guid id)
    {
        var result = await _dbContext.Orders
            .GetById(id, o => new OrderGetDto(
                o.Id,
                o.Products.Select(p => new ProductGetDto(p.Id, p.Title)).ToArray()));

        return result;
    }

    public async Task<OrderGetDto[]> GetList()
    {
        var result = await _dbContext.Orders
            .Select(o => new OrderGetDto(
                o.Id,
                o.Products.Select(p => new ProductGetDto(p.Id, p.Title)).ToArray()))
            .ToArrayAsync();

        return result;
    }

    public async Task Delete(Guid id)
    {
        var result = await _dbContext.Orders
            .GetById(id);

        _dbContext.Remove(result);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<Guid> Create(Guid[] productIds)
    {
        var products = await _dbContext.Products
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync();

        var entity = new Order
        {
            Products = products
        };

        await _dbContext.AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        return entity.Id;
    }
}