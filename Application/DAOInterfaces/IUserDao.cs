﻿using Shared.DTOs;
using Shared.Models;

namespace Application.DAOInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string userName);
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDTO searchParameters);
}