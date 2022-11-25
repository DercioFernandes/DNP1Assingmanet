using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDTO userToCreate);
    Task<IEnumerable<User>> GetAsync(SearchUserParametersDTO searchParameters);
    Task<UserBasicDTO> GetByIdAsync(int id);
}