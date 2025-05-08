using Domain.Entities;

namespace Application.Dto.Responses.Advert;

public class GetAdvertByIdResponse
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime CreationDateTime { get; set; }
    public Status Status { get; set; }
    public Guid UserId { get; set; }
    public Guid Category { get; set; }
}