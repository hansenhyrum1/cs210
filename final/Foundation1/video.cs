class Video
{
     string _title {get; set;}
    string _author {get; set;}
    int _length {get; set;}
    List<Comment> comments;

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