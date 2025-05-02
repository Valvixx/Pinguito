namespace Domain.Entities;

public class Advert
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

public enum Status
{
    Active,
    Archive
}