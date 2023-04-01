namespace Application.Abstractions;

public interface IUserService
{
    public Task<IEnumerable<string>?> CreateAsync(string email, string password);
    public Task<IUser?> FindByIdAsync(long userId);
    public Task<IUser?> FindByEmailAsync(string email);
    public Task<IUser?> FindByUsernameAsync(string username);
    public Task<IEnumerable<string>> GetRolesAsync(IUser user);
}