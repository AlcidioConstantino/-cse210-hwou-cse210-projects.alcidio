using System;

/*
 * EXCEEDING CORE REQUIREMENTS (Criterion 12 - 7 pts):
 * 1. No repeated questions: ReflectActivity tracks questions already shown during
 *    the session, ensuring none repeat until all questions have been asked.
 * 2. Input validation: Activity.DisplayStartingMessage uses int.TryParse to ensure
 *    the user enters a positive whole number and prevent input-related exceptions.
 * 3. Empty item filtering: ListingActivity ignores empty or whitespace-only input,
 *    so only valid items are included in the final count.
 */

class Program
{
    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program Menu:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Choose an option: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;
                case "2":
                    ReflectActivity reflect = new ReflectActivity();
                    reflect.Run();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;
                case "4":
                    Console.WriteLine("\nThank you for taking time for your well-being. See you soon!");
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Press ENTER to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
