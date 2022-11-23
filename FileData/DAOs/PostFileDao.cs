/*using Application.DAOInterfaces;
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
            context.Posts.FirstOrDefault(u => (u.idUser == idCreator));
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDTO searchParameters)
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        if (searchParameters.idCreatorIs != null)
        {
            posts = context.Posts.Where(u => u.idUser == searchParameters.idCreatorIs);
        }

        return Task.FromResult(posts);
    }

    public async Task DeleteAsync(int idPost)
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        if (idPost != null)
        {
            posts = context.Posts.Where(u => u.idPost == idPost);
        }
        context.Posts.Remove(posts.FirstOrDefault());
        context.SaveChanges();
    }

    public async Task<Post> UpdateAsync(Post post)
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        if (post.idPost != null)
        {
            posts = context.Posts.Where(u => u.idPost == post.idPost);
        }
        foreach (var poste in posts)
        {
            if(!post.title.Equals(poste.title))
                post.title = poste.title;
            if(post.idUser!=poste.idUser)
                post.idUser = poste.idUser;
            context.Posts.Remove(poste);
            context.SaveChanges();
        }

        Post resultPost = posts.FirstOrDefault();
        return resultPost;
    }
}*/