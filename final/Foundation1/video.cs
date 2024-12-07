public class Video
{
    public string _title {get; set;}
    public string _author {get; set;}
    public int _length {get; set;}
    public List<Comment> comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        comments = new List<Comment>();
    }

    public void AddComment(string author, string statement)
    {
        Comment comment = new Comment(author, statement);
        comments.Add(comment);
    }

    public int CommentCount()
    {
        return comments.Count;
    }

    
}