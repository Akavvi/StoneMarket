namespace Application.Abstractions;

public interface ICurrentUserProvider
{
    public bool IsAuthenticated { get; set; }
    public long? AccountId { get; set; }
}