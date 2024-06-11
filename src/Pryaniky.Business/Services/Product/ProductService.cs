using Microsoft.EntityFrameworkCore;
using Pryaniky.Data;
using Pryaniky.Domain;

namespace Pryaniky.Business;

public class ProductService(PryanikyDbContext dbContext) : IProductService
{
    private readonly PryanikyDbContext _dbContext = dbContext;

    public async Task<ProductGetDto> GetById(Guid id)
    {
        var result = await _dbContext.Products
            .GetById(id, p => new ProductGetDto(p.Id, p.Title));

        return result;
    }

    public async Task<ProductGetDto[]> GetList()
    {
        var result = await _dbContext.Products
            .Select(p => new ProductGetDto(p.Id, p.Title))
            .ToArrayAsync();

        return result;
    }

    public async Task<Guid> Create(ProductDto dto)
    {
        var entity = new Product
        {
            Title = dto.Title
        };

        await _dbContext.AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task Delete(Guid id)
    {
        var result = await _dbContext.Products
            .GetById(id);

        _dbContext.Remove(result);

        await _dbContext.SaveChangesAsync();
    }
}

