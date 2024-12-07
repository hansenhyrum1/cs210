using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("O Holy Night", "The Tabnernacle Choir", 1691);

        video1.AddComment("Hyrum", "I absolutely love this video, I listen to it often");
        video1.AddComment("Becky", "Who is the Tabernacle Choir? I would love to get to know more about this church.");
        video1.AddComment("John", "Most beautiful performance I have ever seen, thank you, thank you.");

        videos.Add(video1);

        Video video2 = new Video("I Saw Three Ships - Richard Elliott Christmas Organ and Percussion Trio", 255);

        video2.AddComment("Hyrum", "I absolutely love the organ, and the percussion just made this over-the-top amazing.");
        video2.AddComment("Sabrina", "Richard Elliot is so talented, I wonder how much he has to practice every week?");
        video2.AddComment("Bart", "I know the middle drummer, he's my cousin. So talented.");

        videos.Add(video2);

        Video video3 = new Video("Sing We Now of Christmas: BYU-Idaho Christmas 2017", 350);

        video3.AddComment("Hyrum", "I remember attending this as a teenager, it was so spectacular to see it in person.");
        video3.AddComment("Timothy", "Wow, I didn't know that BYU-Idaho put on a Christmas show, how amazing is this?");
        video3.AddComment("Nicole", "They are performing again tonight, December 7th at 7:30PM in the I-Center with Laura Osnes");

        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of Comments: {video.comments.Count}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.comments)
            {
                Console.WriteLine($"{comment._author}: {comment._comment}");
            }
            Console.WriteLine();
        }
    }
}