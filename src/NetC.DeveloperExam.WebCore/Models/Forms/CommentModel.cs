namespace NetC.DeveloperExam.WebCore.Models.Forms
{
    public class CommentModel
    {
        public int BlogId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }
        
        public string? Message { get; set; }
    }

    public class ReplyCommentModel : CommentModel
    {
        public int CommentNumber { get; set;}
    }
}