using Microsoft.AspNetCore.Mvc;
using Pryaniky.Business;

namespace Pryaniky.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService service) : ControllerBase
{
    private readonly IProductService _service = service;

    [HttpGet]
    public async Task<ProductGetDto[]> GetList()
    {
        var result = await _service.GetList();

        return result;
    }

    [HttpGet("{id}")]
    public async Task<ProductGetDto> GetById(Guid id)
    {
        var result = await _service.GetById(id);

        return result;
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<Guid> Create([FromBody] ProductDto dto)
    {
        var result = await _service.Create(dto);

        return result;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.Delete(id);

        return NoContent();
    }
}
