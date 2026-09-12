Journal journal = new Journal();

string choice = "";

while (choice != "5")
{
    Console.WriteLine();
    Console.WriteLine("Welcome to your Journal!");
    Console.WriteLine();
    Console.WriteLine("Please select one of the following choices:");
    Console.WriteLine("1. Write a new entry");
    Console.WriteLine("2. Display the journal");
    Console.WriteLine("3. Save the journal");
    Console.WriteLine("4. Load the journal");
    Console.WriteLine("5. Quit");

    Console.Write("What would you like to do? ");
    choice = Console.ReadLine() ?? "";

    if (choice == "1")
    {
        string[] prompts =
        {
            "What did you learn today?",
            "What was the best part of your day?",
            "What are you grateful for today?",
            "What was something difficult you faced today?",
            "What is one goal you have for tomorrow?"
        };

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine();
        Console.WriteLine(prompt);
        Console.Write("> ");

        string answer = Console.ReadLine() ?? "";

        string date = DateTime.Now.ToString("MMMM dd, yyyy");

        Entry newEntry = new Entry(
            date,
            prompt,
            answer
        );

        journal._entries.Add(newEntry);

        Console.WriteLine();
        Console.WriteLine("Entry added successfully!");
    }
    else if (choice == "2")
    {
        journal.Display();
    }
    else if (choice == "3")
    {
        journal.SaveToFile("journal.txt");
    }
    else if (choice == "4")
    {
        journal.LoadFromFile("journal.txt");
    }
    else if (choice == "5")
    {
        Console.WriteLine();
        Console.WriteLine("Goodbye!");
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Invalid choice. Please select 1, 2, 3, 4, or 5.");
    }
}