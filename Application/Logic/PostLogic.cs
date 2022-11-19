using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;

    public PostLogic(IPostDao postDao)
    {
        this.postDao = postDao;
    }
    
    public async Task<Post> CreateAsync(PostCreationDTO dto)
    {
        ValidateData(dto);
        Post toCreate = new Post
        {
            idCreator = dto.idCreator,
            title = dto.title
        };
    
        Post created = await postDao.CreateAsync(toCreate);
    
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDTO dto)
    {
        return postDao.GetAsync(dto);
    }

    public async Task DeleteAsync(int idPost)
    {
        await postDao.DeleteAsync(idPost);
    }

    public async Task<Post> UpdateAsync(PostUpdateDTO dto)
    {
        Post toUpdate = new Post
        {
            idPost = dto.idPost,
            idCreator = dto.idCreator,
            title = dto.title
        };
        Post updated = await postDao.UpdateAsync(toUpdate);
        return updated;
    }

    private static void ValidateData(PostCreationDTO postToCreate)
    {
        String title = postToCreate.title;

        if (title.Length < 3)
            throw new Exception("Title must be at least 3 characters!");

        if (title.Length > 40)
            throw new Exception("Title must be less than 40 characters!");
    }
}