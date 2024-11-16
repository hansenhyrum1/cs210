using System;
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;


abstract class SmartDevice
{
    public string Name {get; set; }
    public bool IsOn {get; private set;}
    private DateTime? _turnedOnAt;

    public SmartDevice(string name)
    {
        Name = name;
        IsOn = false;
    }

    public void TurnOn()
    {
        IsOn = true;
        _turnedOnAt = DateTime.Now;
    }

    public void TurnOff()
    {
        IsOn = false;
        _turnedOnAt = null;
    }

    public TimeSpan TimeOn() => IsOn ? DateTime.Now - _turnedOnAt.Value : TimeSpan.Zero;
}

class SmartLight : SmartDevice
{
    public SmartLight(string name) : base(name) { }
}

class SmartHeater : SmartDevice
{
    public SmartHeater(string name) : base(name) { }
}

class SmartTV : SmartDevice
{
    public SmartTV(string name) : base(name) { }
}

class Room
{
    public string Name {get; set;}
    public List<SmartDevice> Devices { get; set; } = new List<SmartDevice>();

    public void AddDevice(SmartDevice device) => Devices.Add(device);

    public void TurnOnAllDevices() => Devices.ForEach(d =>d.TurnOn());
    public void TurnOffAllDevices() => Devices.ForEach(d =>d.TurnOff());

    public void ReportDevices()
    {
        Console.WriteLine($"Devices in {name}:");
        foreach (var device in Devices)
        {
            Console.WriteLine($"{device.Name} is {(device.IsOn ? "On" : "Off")}, Time On: {device.TimeOn()}");
        }

    }
    
}

class House
{
    public List<Room> Rooms { get; set; } = new List<Room>();

    public void AddRoom(Room room) => Rooms.Add(room);

    public void ReportHouseStatus()
    {
        Console.WriteLine("House Report:");
        foreach (var room in Rooms)
        {
            room.ReportDevices();
        }
    }
}

class Program
{
    static void Main()
    {
        House house = new House();
        Room livingRoom = new Room { Name = "Living Room" };
        Room bedroom = new Room { Name = "Bedroom" };

        livingRoom.AddDevice(new SmartLight("Living Room Light"));
        livingRoom.AddDevice(new SmartTV("Living Room TV"));
        bedroom.AddDevice(new SmartHeater("Bedroom Heater"));

        house.AddRoom(livingRoom);
        house.AddRoom(bedroom);

        livingRoom.TurnOnAllDevices();
        bedroom.TurnOnAllDevices();

        house.ReportHouseStatus();

        livingRoom.TurnOffAllDevices();
        bedroom.TurnOffAllDevices();

        house.ReportHouseStatus();
    }
}