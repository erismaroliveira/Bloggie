using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories.Interfaces;

public interface IBlogPostRepository
{
    Task<IEnumerable<BlogPost>> GetAllAsync();
    Task<BlogPost> GetAsync(Guid id);
    Task<BlogPost> AddAsync(BlogPost post);
    Task<BlogPost> UpdateAsync(BlogPost post);
    Task<bool> DeleteAsync(Guid id);
}
