using Application.DAOInterfaces;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
using Shared.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly PostContext context;

    public PostEfcDao(PostContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task UpdateAsync(Post post)
    {
        context.ChangeTracker.Clear();
        context.Posts.Update(post);
        await context.SaveChangesAsync();
    }

    public async Task<Post?> GetByIdAsync(int postId)
    {
        Post? found = await context.Posts
            .AsNoTracking()
            .Include(post => post.creator)
            .SingleOrDefaultAsync(post => post.idPost == postId);
        return found;
    }

    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDTO searchParameters)
    {
        IQueryable<Post> query = context.Posts.Include(post => post.creator).AsQueryable();

        if (searchParameters.idCreatorIs != 0)
        {
            Console.WriteLine("IdCreator: " + searchParameters.idCreatorIs);
            query = query.Where(t => t.creator.idUser == searchParameters.idCreatorIs);
        }
        
        List<Post> result = await query.ToListAsync();
        return result;
    }

    public async Task DeleteAsync(int id)
    {
        Post? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"Post with id {id} not found");
        }

        context.Posts.Remove(existing);
        await context.SaveChangesAsync();
    }
}