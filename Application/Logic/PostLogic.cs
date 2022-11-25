using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }
    
    public async Task<Post> CreateAsync(PostCreationDTO dto)
    {
        ValidateData(dto);
        User? user = await userDao.GetByIdAsync(dto.idUser);
        if (user == null)
        {
            throw new Exception($"User with id {dto.idUser} was not found.");
        }

        Post toCreate = new Post
        {
            creator = user,
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
        User? user = await userDao.GetByIdAsync(dto.idCreator);
        if (user == null)
        {
            throw new Exception($"User with id {dto.idCreator} was not found.");
        }

        Post toUpdate = new Post
        {
            idPost = dto.idPost,
            creator = user,
            title = dto.title
        };
        await postDao.UpdateAsync(toUpdate);
        return toUpdate;
    }

    public async Task<PostBasicDTO> GetByIdAsync(int idPost)
    {
        if (idPost == 0)
        {
            
        }
        Post? post = await postDao.GetByIdAsync(idPost);
        if (post == null)
        {
            throw new Exception($"Post with id {idPost} not found");
        }

        return new PostBasicDTO(post.idPost, post.creator, post.title);
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