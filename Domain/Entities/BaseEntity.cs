namespace Domain.Entities;

public class BaseEntity<TIdentifier>
{
    public TIdentifier Id { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}