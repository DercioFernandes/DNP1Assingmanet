using Shared.Models;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserCreationDTO dto);
    Task<IEnumerable<User>> GetUsers(string? usernameContains = null);
    Task<UserBasicDTO> GetUserById(int idUser);
}