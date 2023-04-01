namespace Application.Abstractions;

public interface IUser
{
    public long Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
}