public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Begin deep breathing!")
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("This activity will help you relax by walking you through something called Box Breathing. Clear your mind and focus on your breathing.");

        Console.WriteLine("How long do you want to do this activity?");
        _duration = Convert.ToInt32(Console.ReadLine());
        Thread.Sleep(3000);

        int _timeElapsed = 0;
        while (_timeElapsed < _duration)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(4000);
            Console.WriteLine("Hold breath...");
            Thread.Sleep(4000);
            Console.WriteLine("Breath out...");
            Thread.Sleep(4000);
            Console.WriteLine("Hold...");
            Thread.Sleep(4000);
            _timeElapsed += 16;
        }
        EndActivity();
    }
}