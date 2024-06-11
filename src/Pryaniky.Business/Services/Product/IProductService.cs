namespace Pryaniky.Business;

public interface IProductService
{
    Task<ProductGetDto[]> GetList();

    Task<ProductGetDto> GetById(Guid id);

    Task<Guid> Create(ProductDto dto);

    Task Delete(Guid id);
}

