namespace Core.Application;

using Core.Domain;
using Microsoft.Extensions.Logging; 

public class UserService
{
    private readonly IUserStorage _userStorage; 
    private readonly ILogger _logger;

    public UserService(IUserStorage userStorage, ILogger logger)
    {
        _userStorage = userStorage;
        _logger = logger;
    } 

    public async Task<User> GetByIdAsync(Guid id)
    {
        User? user = await _userStorage.GetByIdAsync(id);

        if(user == null)
        {
            throw new NotFoundException($"User {id} not found");
        }

        return user;
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        return _userStorage.GetAllAsync();
    }

    public async Task<User> DeleteAsync(Guid id)
    {
        User user = await GetByIdAsync(id);

        await _userStorage.DeleteAsync(id);

        return user;
    }

    public async Task<User> SetRoleAsync(Guid id, UserRole role)
    {
        User user = await GetByIdAsync(id);

        user.SetRole(role);

        await _userStorage.SaveAsync(user);

        return user;
    }

    //TODO: Create
}
