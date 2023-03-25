namespace Domain.Entities;

public class Product : BaseEntity<long>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }
    public long OwnerId { get; set; }
    public User Owner { get; set; } = null!;
}