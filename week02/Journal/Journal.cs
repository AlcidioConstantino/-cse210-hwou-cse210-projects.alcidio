using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("The journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine();
            Console.WriteLine($"Date: {entry._date}");
            Console.WriteLine($"Prompt: {entry._promptText}");
            Console.WriteLine($"Entry: {entry._entryText}");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry._date);
                outputFile.WriteLine(entry._promptText);
                outputFile.WriteLine(entry._entryText);
            }
        }

        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("No saved journal was found.");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);

        for (int i = 0; i < lines.Length; i += 3)
        {
            if (i + 2 < lines.Length)
            {
                Entry entry = new Entry(
                    lines[i],
                    lines[i + 1],
                    lines[i + 2]
                );

                _entries.Add(entry);
            }
        }

        Console.WriteLine("Journal loaded successfully.");
    }
}