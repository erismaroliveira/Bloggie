namespace Bloggie.Web.Models.Domain;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid BlogPostId { get; set; }
}
