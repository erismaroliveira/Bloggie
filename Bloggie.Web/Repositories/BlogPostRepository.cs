using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories;

public class BlogPostRepository : IBlogPostRepository
{
    private readonly BloggieDbContext _dbContext;

    public BlogPostRepository(BloggieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<BlogPost>> GetAllAsync()
    {
        return await _dbContext.BlogPosts.AsNoTracking().ToListAsync();
    }

    public async Task<BlogPost> GetAsync(Guid id)
    {
        return await _dbContext.BlogPosts.FindAsync(id);
    }

    public async Task<BlogPost> AddAsync(BlogPost post)
    {
        await _dbContext.BlogPosts.AddAsync(post);
        await _dbContext.SaveChangesAsync();

        return post;
    }

    public async Task<BlogPost> UpdateAsync(BlogPost post)
    {
        var existingBlogPost = await _dbContext.BlogPosts.FindAsync(post.Id);

        if (existingBlogPost != null)
        {
            _dbContext.BlogPosts.Update(post);
            await _dbContext.SaveChangesAsync();
        }

        return existingBlogPost;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existingBlogPost = await _dbContext.BlogPosts.FindAsync(id);

        if (existingBlogPost != null)
        {
            _dbContext.BlogPosts.Remove(existingBlogPost);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
