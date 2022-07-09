using Microsoft.EntityFrameworkCore;
using template_csharp_blog.Models;

namespace template_csharp_blog
{
    public class BlogContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb; Database=BlogDB_06232022; Trusted_Connection=True";
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category() { Id = 1, Name = "Drumming" },
            new Category() { Id = 2, Name = "Video Games" },
            new Category() { Id = 3, Name = "Mountain Biking" }
            );
            modelBuilder.Entity<Post>().HasData(
                new Post() { Id = 1, CategoryId = 1, Author = "Matt Garstka", Body = "Here is the body a blog that Matt would write!", Title = "Practicing your rudiments blog." },
                new Post() { Id = 2, CategoryId = 1, Author = "Thomas Haawke", Body = "Body of a blog that Thomas Haawke would write!", Title = "Mastering time space relationship in music blog." },
                new Post() { Id = 3, CategoryId = 1, Author = "Alex Bent", Body = "Alex would write a blog here about drumming with Trivium.", Title = "Blogging Trivium drumming journey."},

                new Post() { Id = 4, CategoryId = 2, Author = "Aden Langdon", Body = "A blog that i would write about video games.", Title = "Video game blog by Aden." },
                new Post() { Id = 5, CategoryId = 2, Author = "Summit1g", Body = "A blog but instead its just a tweet about video game developers.", Title = "Why did they do this?" },
                new Post() { Id = 6, CategoryId = 2, Author = "Pestily", Body = "Just another tweet about 'thursday'.", Title = "Its thursday." },

                new Post() { Id = 8, CategoryId = 3, Author = "Seth", Body = "Here is where the blog would be if I was Seth and wanted to write a blog", Title = "Building Berm Park blog." },
                new Post() { Id = 9, CategoryId = 3, Author = "Aden Langdon", Body = "This is where I would write my blog about mountain biking. But, since I am the developer I am going to develop the app first :).", Title = "How to make more time, a blog." },
                new Post() { Id = 10, CategoryId = 3, Author = "Phil", Body = "Downhill mountain bike racing is an adrenaline filled action sport but there's a big risk", Title = "Conqering yourself and achieving your goals blog." }
                );
        }
    }
}
