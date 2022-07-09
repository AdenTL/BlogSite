namespace template_csharp_blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        



        //public Post(string title, string body, string author, DateTime publishDate, Category category)
        //{
        //    Title = title;
        //    Body = body;
        //    Author = author;
        //    PublishDate = publishDate;
        //    Category = category;
        //}
    }
}
