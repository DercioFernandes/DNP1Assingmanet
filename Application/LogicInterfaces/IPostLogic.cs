﻿using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDTO dto);
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDTO dto);
    Task DeleteAsync(int idPost);
    Task<Post> UpdateAsync(PostUpdateDTO dto);
}