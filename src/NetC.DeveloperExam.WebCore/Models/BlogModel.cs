using Newtonsoft.Json;

namespace NetC.DeveloperExam.WebCore.Models
{
    public class BlogRoot
    {
        [JsonProperty(PropertyName = "blogPosts")]
        public List<BlogPost>? BlogPosts { get; set; }
    }

    public class BlogPost
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string? Title { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string? Image { get; set; }

        [JsonProperty(PropertyName = "htmlContent")]
        public string? HtmlContent { get; set; }

        [JsonProperty(PropertyName = "comments")]
        public List<Comment>? Comments { get; set; }
    }

    public class Comment : BaseComment
    {
        [JsonProperty(PropertyName = "replies")]
        public List<BaseComment>? Replies { get; set; }
    }

    public class BaseComment
    {
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "emailAddress")]
        public string? EmailAddress { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string? Message { get; set; }
    }
}