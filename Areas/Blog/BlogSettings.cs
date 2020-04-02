namespace PersonalBlog
{
    public class BlogSettings
    {
        public string Owner { get; set; } = "The Owner";
        public int PostsPerPage { get; set; } = 20;
        public PostListView ListView { get; set; } = PostListView.TitlesAndExcerpts;
        public int CommentsCloseAfterDays { get; set; } = 10;
    }

    public enum PostListView
    {
        TitlesOnly,
        TitlesAndExcerpts,
        FullPosts
    }
}
