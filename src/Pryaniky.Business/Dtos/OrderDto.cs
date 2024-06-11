namespace Pryaniky.Business;

public record OrderGetDto(Guid Id, ProductGetDto[] Products);