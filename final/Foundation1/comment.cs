using System.Transactions;

class Comment
{
   string _author;
   string _comment;

   public Comment(string author, string comment)
   {
        _author = author;
        _comment = comment;
   }
}