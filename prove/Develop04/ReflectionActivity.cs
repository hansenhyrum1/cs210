public class ReflectionActivity : MindfulnessActivity
{
    private string [] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string [] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity: Reflect on your personal strengths.")
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("How long would you like to do this activity?");
        _duration = Convert.ToInt32(Console.ReadLine());
        Thread.Sleep(3000);

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Thread.Sleep(2000);

        int _timeElapsed = 0;
        while (_timeElapsed < _duration)
        {
            foreach (var _question in questions)
            {
                Console.WriteLine(_question);
                Thread.Sleep(4000);
            }
            _timeElapsed += 30;
        }
        EndActivity();
    }
}