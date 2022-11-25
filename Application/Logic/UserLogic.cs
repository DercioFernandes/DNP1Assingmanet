using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }
    
    public async Task<User> CreateAsync(UserCreationDTO dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.userName);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User
        {
            userName = dto.userName,
            password = dto.password
        };
    
        User created = await userDao.CreateAsync(toCreate);
    
        return created;
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDTO searchParameters)
    {
        return userDao.GetAsync(searchParameters);
    }

    public async Task<UserBasicDTO> GetByIdAsync(int idUser)
    {
        User? user = await userDao.GetByIdAsync(idUser);
        if (user == null)
        {
            throw new Exception($"Post with id {idUser} not found");
        }

        return new UserBasicDTO(user.idUser,user.userName,user.password);
    }

    private static void ValidateData(UserCreationDTO userToCreate)
    {
        string userName = userToCreate.userName;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }
}