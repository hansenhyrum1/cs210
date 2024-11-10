public class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity: List positive things in your life.")
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("How long do you want to do this activity in seconds?");
        _duration = Convert.ToInt32(Console.ReadLine());
        Thread.Sleep(3000);

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Thread.Sleep(2000);

        Console.WriteLine("Start listing now...");
        List<string> items = new List<string>();
        int timeElapsed = 0;
        while (timeElapsed < _duration)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
            timeElapsed += 5;
        }

        Console.WriteLine($"You listed {items.Count} items.");
        EndActivity();
    }
}