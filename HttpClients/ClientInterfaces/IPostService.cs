using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<Post> Create(PostCreationDTO dto);
    Task Delete(int id);
    Task Update(PostUpdateDTO dto);
    Task<IEnumerable<Post>> GetPosts(int? idCreator);

    Task<Post> GetByIdAsync(int id);
}