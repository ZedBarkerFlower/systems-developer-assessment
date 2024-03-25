using Microsoft.AspNetCore.Mvc;
using NetC.DeveloperExam.WebCore.Models.Forms;
using NetC.DeveloperExam.WebCore.Services;
using NetC.DeveloperExam.WebCore.ViewModels;

public class BlogController(BlogService blogService) : Controller
{
    private readonly BlogService _blogService = blogService;

    public IActionResult Index(int id)
    {
        var blogPost = _blogService.GetBlog(id);
        if (blogPost == null)
        {
            return View("~/Views/Error/Index.cshtml");
        }

        return View(new BlogViewModel(blogPost));
    }

    public IActionResult SubmitComment([FromForm] CommentModel model)
    {
        if (model == default
            || string.IsNullOrWhiteSpace(model?.Name)
            || string.IsNullOrWhiteSpace(model?.Email)
            || !_blogService.AddComment(model))
        {
            return View("~/Views/Error/Index.cshtml");
        }

        return Redirect($"/blog/{model.BlogId}");
    }

    public IActionResult SubmitCommentReply([FromForm] ReplyCommentModel model)
    {
        if (model == default
            || string.IsNullOrWhiteSpace(model?.Name)
            || string.IsNullOrWhiteSpace(model?.Email)
            || !_blogService.AddCommentReply(model))
        {
            return View("~/Views/Error/Index.cshtml");
        }

        return Redirect($"/blog/{model.BlogId}");
    }
}