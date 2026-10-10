using System.Text.Json;

// Creativity beyond the core requirements: the player's title and level rise as
// their score grows, and a progress bar shows how close they are to the next level.
const string SaveFile = "eternal-quest.json";
List<Goal> goals = new();
int score = 0;
LoadIfPresent();

while (true)
{
    Console.WriteLine("\n=== Eternal Quest ===");
    Console.WriteLine($"Score: {score} | Level {GetLevel(score)} — {GetTitle(score)}");
    Console.WriteLine($"Next level: {GetProgressBar(score)}");
    Console.WriteLine("1. List goals\n2. Create goal\n3. Record goal event\n4. Save\n5. Load\n6. Quit");
    Console.Write("Choose an option: ");
    switch (Console.ReadLine())
    {
        case "1": ListGoals(); break;
        case "2": CreateGoal(); break;
        case "3": RecordGoal(); break;
        case "4": Save(); break;
        case "5": Load(); break;
        case "6": Save(); return;
        default: Console.WriteLine("Please choose 1–6."); break;
    }
}

void ListGoals()
{
    if (goals.Count == 0) { Console.WriteLine("No goals yet."); return; }
    for (int i = 0; i < goals.Count; i++)
        Console.WriteLine($"{i + 1}. {goals[i].StatusMark} {goals[i].Name} — {goals[i].Details}");
}

void CreateGoal()
{
    Console.WriteLine("Goal type: 1. Simple  2. Eternal  3. Checklist");
    string type = Console.ReadLine() ?? "";
    string name = Ask("Name: ");
    string description = Ask("Description: ");
    int points = ReadInt("Points per completion: ", 1);
    Goal goal;
    switch (type)
    {
        case "1": goal = new SimpleGoal(name, description, points); break;
        case "2": goal = new EternalGoal(name, description, points); break;
        case "3":
            int target = ReadInt("Required completions: ", 1);
            int bonus = ReadInt("Bonus points on completion: ", 0);
            goal = new ChecklistGoal(name, description, points, target, bonus);
            break;
        default: Console.WriteLine("Unknown goal type."); return;
    }
    goals.Add(goal);
    Console.WriteLine("Goal created.");
}

void RecordGoal()
{
    if (goals.Count == 0) { Console.WriteLine("Create a goal first."); return; }
    ListGoals();
    int index = ReadInt("Goal number to record: ", 1, goals.Count) - 1;
    int earned = goals[index].RecordEvent();
    score += earned;
    Console.WriteLine(earned > 0 ? $"Quest progress recorded! +{earned} points." : "That goal is already complete.");
    Console.WriteLine($"Score: {score} | Level {GetLevel(score)} — {GetTitle(score)}");
}

void Save()
{
    SaveData data = new(score, goals.Select(goal => goal.ToData()).ToList());
    File.WriteAllText(SaveFile, JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
    Console.WriteLine($"Saved to {Path.GetFullPath(SaveFile)}");
}

void Load()
{
    if (!File.Exists(SaveFile)) { Console.WriteLine("No save file found."); return; }
    try
    {
        SaveData data = JsonSerializer.Deserialize<SaveData>(File.ReadAllText(SaveFile));
        if (data is null || data.Goals is null || data.Score < 0) { Console.WriteLine("Save file is empty or invalid."); return; }
        score = data.Score;
        goals = data.Goals.Select(Goal.FromData).ToList();
        Console.WriteLine("Save loaded.");
    }
    catch (Exception ex) { Console.WriteLine($"Could not load save: {ex.Message}"); }
}

void LoadIfPresent() { if (File.Exists(SaveFile)) Load(); }
string Ask(string prompt) { Console.Write(prompt); return Console.ReadLine()?.Trim() ?? ""; }
int ReadInt(string prompt, int min, int max = int.MaxValue)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max) return value;
        Console.WriteLine($"Enter a whole number from {min} to {max}.");
    }
}
int GetLevel(int points) => points / 500 + 1;
string GetTitle(int points) => points switch { >= 5000 => "Eternal Champion", >= 2500 => "Quest Master", >= 1000 => "Pathfinder", >= 500 => "Seeker", _ => "Initiate" };
string GetProgressBar(int points)
{
    int progress = points % 500;
    int filled = progress / 50;
    return $"[{new string('#', filled)}{new string('-', 10 - filled)}] {500 - progress} points remaining";
}
