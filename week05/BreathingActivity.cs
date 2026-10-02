using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by guiding you through slow, deep breathing. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            int inhaleSeconds = Math.Min(4, GetRemainingSeconds(endTime));
            if (inhaleSeconds == 0) break;
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountDown(inhaleSeconds);
            Console.WriteLine();

            int exhaleSeconds = Math.Min(6, GetRemainingSeconds(endTime));
            if (exhaleSeconds == 0) break;
            Console.Write("Breathe out... ");
            ShowCountDown(exhaleSeconds);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
