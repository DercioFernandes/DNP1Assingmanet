using Application.DAOInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext fileContext)
    {
        this.context = fileContext;
    }
    
    public Task<Post> CreateAsync(Post post)
    {
        int postId = 1;
        if (context.Posts.Any())
        {
            postId = context.Posts.Max(u => u.idPost);
            postId++;
        }

        post.idPost = postId;

        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<Post?> GetByIdAsync(int idCreator)
    {
        Post? existing =
            context.Posts.FirstOrDefault(u => (u.idCreator == idCreator));
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDTO searchParameters)
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        if (searchParameters.idCreatorIs != null)
        {
            posts = context.Posts.Where(u => u.idCreator == searchParameters.idCreatorIs);
        }

        return Task.FromResult(posts);
    }
}