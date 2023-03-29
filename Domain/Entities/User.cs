using System.Text.Json.Serialization;

namespace Domain.Entities;

public class User : BaseEntity<long>
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool IsActive { get; set; }
    public float Rating { get; set; }

    [JsonIgnore] public List<Product> Products { get; set; } = new();
}