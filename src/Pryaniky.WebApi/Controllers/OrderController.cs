using Microsoft.AspNetCore.Mvc;
using Pryaniky.Business;

namespace Pryaniky.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService service) : ControllerBase
{
    private readonly IOrderService _service = service;

    [HttpGet()]
    public async Task<OrderGetDto[]> GetList()
    {
        var result = await _service.GetList();

        return result;
    }

    [HttpGet("{id}")]
    public async Task<OrderGetDto> GetById(Guid id)
    {
        var result = await _service.GetById(id);

        return result;
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<Guid> Create([FromBody] Guid[] productIds)
    {
        var result = await _service.Create(productIds);

        return result;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.Delete(id);

        return NoContent();
    }
}
