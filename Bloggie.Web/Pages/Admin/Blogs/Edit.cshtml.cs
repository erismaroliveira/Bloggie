using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class EditModel : PageModel
{
    private readonly IBlogPostRepository _blogPostRepository;

    [BindProperty]
    public BlogPost BlogPost { get; set; }

    public EditModel(IBlogPostRepository blogPostRepository)
    {
        _blogPostRepository = blogPostRepository;
    }

    public async Task OnGet(Guid id)
    {
        BlogPost = await _blogPostRepository.GetAsync(id);
    }

    public async Task<IActionResult> OnPostEdit()
    {
        var existingBlogPost = await _blogPostRepository.GetAsync(BlogPost.Id);

        if (existingBlogPost != null)
        {
            existingBlogPost.Heading = BlogPost.Heading;
            existingBlogPost.PageTitle = BlogPost.PageTitle;
            existingBlogPost.Content = BlogPost.Content;
            existingBlogPost.ShortDescription = BlogPost.ShortDescription;
            existingBlogPost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
            existingBlogPost.UrlHandle = BlogPost.UrlHandle;
            existingBlogPost.PublishedDate = BlogPost.PublishedDate;
            existingBlogPost.Author = BlogPost.Author;
            existingBlogPost.Visible = BlogPost.Visible;
        }

        await _blogPostRepository.UpdateAsync(existingBlogPost);
        return RedirectToPage("/Admin/Blogs/List");
    }

    public async Task<IActionResult> OnPostDelete()
    {
        var existingBlogPost = await _blogPostRepository.GetAsync(BlogPost.Id);

        if (existingBlogPost != null)
        {
            await _blogPostRepository.DeleteAsync(existingBlogPost.Id);

            return RedirectToPage("/Admin/Blogs/List");
        }

        return Page();
    }
}
