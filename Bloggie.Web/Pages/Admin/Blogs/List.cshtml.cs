using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class ListModel : PageModel
{
    private readonly IBlogPostRepository _blogPostRepository;

    public IEnumerable<BlogPost> BlogPosts { get; set; }

    public ListModel(IBlogPostRepository blogPostRepository)
    {
        _blogPostRepository = blogPostRepository;
    }

    public async Task OnGet()
    {
        BlogPosts = await _blogPostRepository.GetAllAsync();
    }
}
