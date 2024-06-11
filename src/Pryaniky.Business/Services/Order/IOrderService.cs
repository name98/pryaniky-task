namespace Pryaniky.Business;

public interface IOrderService
{
    Task<OrderGetDto[]> GetList();

    Task<OrderGetDto> GetById(Guid id);

    Task<Guid> Create(Guid[] productIds);

    Task Delete(Guid id);
}
