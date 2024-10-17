using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop02 World!");
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

     }
     public void showEntries()
     {

     }
     public void save(string fileName)
     {

     }
     public void load (string fileName)
     {

     }

}

class Prompts
{
    public List<string>;
    
    public void randPrompt()
    {

    }
}