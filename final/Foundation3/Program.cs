using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("8519 Salmonberry Lp", "Hayden", "Idaho", "USA");

        Lecture lecture1 = new Lecture("Hyrum's Gospel Study", "Learn about the Gospel of The Church of Jesus Christ of Latter-day Saints", "Dec 14, 2024", "7:00 PM", address1, "Hyrum Hansen", "25");

        Console.WriteLine(lecture1.GetShort());
        Console.WriteLine();
        Console.WriteLine(lecture1.GetStandard());
        Console.WriteLine();
        Console.WriteLine(lecture1.GetFull());
        Console.WriteLine();

        Address address2 = new Address("345 W 5th S", "Rexburg", "Idaho", "USA");
        Reception reception1 = new Reception("Hyrum's Wedding Reception", "A wedding reception for Hyrum and his wife", "January 15, 2025", "6:00 PM", address2, "hanshyru@gmail.com");

        Console.WriteLine(reception1.GetShort());
        Console.WriteLine();
        Console.WriteLine(reception1.GetStandard());
        Console.WriteLine();
        Console.WriteLine(reception1.GetFull());
        Console.WriteLine();

        Address address3 = new Address("12551 N Government Way", "Hayden", "Idaho", "USA");
        OutdoorGathering outdoorgathering1 = new OutdoorGathering("Fall Festival", "The annual festival for New Leaf Nursery and community vendors", "October 15, 2024", "10 AM - 7 PM", address3, "Partly Cloudy");

        Console.WriteLine(outdoorgathering1.GetShort());
        Console.WriteLine();
        Console.WriteLine(outdoorgathering1.GetStandard());
        Console.WriteLine();
        Console.WriteLine(outdoorgathering1.GetFull());
        Console.WriteLine();


    }
}