using Shared.DTOs;
using Shared.Models;

namespace Application.DAOInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<Post?> GetByIdAsync(int idCreator);
    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDTO searchParameters);
    Task DeleteAsync(int idPost);
    Task UpdateAsync(Post post);
}