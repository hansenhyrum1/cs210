using System;

class Program
{
    static void Main(string[] args)
    {
        Journal newJournal = new Journal();
        Prompts prompt = new Prompts();
    
        int run = 1;
        
        while(run == 1)
        {


            Console.WriteLine("1. New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal to File");
            Console.WriteLine("4. Load Journal from File");
            Console.WriteLine("5. Quit");
            int option = Convert.ToInt32(Console.ReadLine());

            if (option == 1)
            {
                string randPrompt = prompt.randPrompt();
                Console.WriteLine($"Your prompt: {randPrompt}");
                string response = Console.ReadLine();
                Entry newEntry = new Entry(randPrompt, response);
                newJournal.addEntry(newEntry);

            }
            if (option == 2)
            {
                newJournal.showEntries();
            }
            if (option == 3)
            {
                Console.WriteLine("What is the file name?");
                string fileName = Console.ReadLine();
                newJournal.save(fileName);
                
            }
            if (option == 4)
            {
                Console.WriteLine("What is the file name?");
                string fileName = Console.ReadLine();
                newJournal.load(fileName);
            }
            if (option == 5)
            {
                run = 0;
            }
        }
    }
} 
class Entry
{
    public string _prompt;
    public string _response;
    public string _date;

    public Entry(string prompt, string response)
    {
        _prompt = prompt;
        _response = response;
        _date =  DateTime.Now.ToString(); 
    }   
    
    
}

class Journal
{
     public List<Entry> journalEntries = new List<Entry>();

     public void addEntry(Entry entry)
     {
        journalEntries.Add(entry);
        Console.WriteLine("Entry added!");
     }
     public void showEntries()
     {
        foreach (Entry entry in journalEntries)
        {
            Console.WriteLine($"Date: {entry._date}");
            Console.WriteLine($"Prompt: {entry._prompt}");
            Console.WriteLine($"Entry: {entry._response}");
        }
     }
     public void save(string fileName)
     {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in journalEntries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }
     }
     public void load (string fileName)
     {
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                string date = parts[0];
                string prompt = parts[1];
                string response = parts[2];

                Entry loadedEntry = new Entry(prompt, response);
                loadedEntry._date = date;

                journalEntries.Add(loadedEntry);
            }
        }
     }

}

class Prompts
{
    public List<string> promptList = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What Spiritual Impressions did I have today?"
    };
    
    public string randPrompt()
    {
        Random ranPrompt = new Random();
        int index = ranPrompt.Next(promptList.Count);
        return promptList[index];
    }
}