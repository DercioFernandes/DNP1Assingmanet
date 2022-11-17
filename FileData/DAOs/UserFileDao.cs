using System.Net.Mime;
using Shared.DTOs;
using Shared.Models;

namespace FileData.DAOs;

using Application.DAOInterfaces;


public class UserFileDao : IUserDao
{
    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.idUser);
            userId++;
        }

        user.idUser = userId;

        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing =
            context.Users.FirstOrDefault(u => u.userName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDTO searchParameters)
    {
        IEnumerable<User> users = context.Users.AsEnumerable();
        if (searchParameters.UsernameContains != null)
        {
            users = context.Users.Where(u => u.userName.Contains(searchParameters.UsernameContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(users);
    }
}