using NetC.DeveloperExam.WebCore.Models;

namespace NetC.DeveloperExam.WebCore.ViewModels
{
    public class BlogViewModel
    {
        public BlogViewModel(BlogPost blogPost)
        {
            Id = blogPost.Id;
            Date = blogPost.Date;
            Title = blogPost.Title;
            Image = blogPost.Image;
            HtmlContent = blogPost.HtmlContent;
            Comments = blogPost.Comments
                ?.Select(x => new CommentViewModel(x))
                .ToList();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? HtmlContent { get; set; }
        public List<CommentViewModel>? Comments { get; set; }
    }

    public class CommentViewModel : BaseCommentViewModel
    {
        public CommentViewModel(Comment comment) : base(comment)
        {
            Replies = comment.Replies
                ?.Select(x => new BaseCommentViewModel(x))
                .ToList();
        }

        public List<BaseCommentViewModel>? Replies { get; set; }
    }

    public class BaseCommentViewModel
    {
        public BaseCommentViewModel(BaseComment comment)
        {
            Name = comment.Name;
            Date = comment.Date;
            Message = comment.Message;
        }

        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string? Message { get; set; }
    }
}