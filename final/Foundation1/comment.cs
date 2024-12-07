using System.Transactions;

public class Comment
{
   public string _author;
   public string _comment;

   public Comment(string author, string comment)
   {
        _author = author;
        _comment = comment;
   }
}