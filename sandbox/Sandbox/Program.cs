using System;
using System.Dynamic;


// Authors: Dax, Dylan, Damen
// Proof of concept
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        // Creating a new home
        Home home1 = new Home("Rexburg home"); // named "Rexburg home"

        // Creating 2 rooms and adding them to the home
        Room livingRoom = new Room("Living room", 1, 1, 1); // named "Living room" has 1 light, 1 heater, 1 TV
        Room bedRoom = new Room("Bed room", 2, 1, 1); // named "Bed room" has 2 lights, 1 heater, 1 TV
        home1.AddRoom(livingRoom); 
        home1.AddRoom(bedRoom);

        // Get the list of rooms in home1
        List<Room> home1Rooms = home1.GetRooms();

        // Turn On some devices
        Console.WriteLine("Turning on all lights in the living room");
        livingRoom.TurnOnLights(); // Turn on lights in the living room
        Console.WriteLine("Turning on all devices in the bed room");
        bedRoom.TurnOnDevices(); // Turn on all devices in the bed room
        Thread.Sleep(3000); // Wait for some time (3 secs)
        Console.WriteLine("Turning off all lights in the bed room");
        bedRoom.TurnOffLights(); // Turn off the lights in the bed room
        Thread.Sleep(2000); // Wait for a while
        Console.WriteLine("Reporting all devices");
        foreach(Room _ in home1Rooms) // Report all devices in home1
        {
           Console.WriteLine(_.ReportDevices());
        }
        Console.WriteLine("Turning off all heaters in the bed room");
        List<SmartHeater> bedRoomHeaters = bedRoom.GetHeaters(); // Get the list of all heaters in the bed room
        foreach (SmartHeater heater in bedRoomHeaters)
        {
            heater.StopDevice(); // Turning off all heaters in the bed room
        }
        Console.WriteLine(bedRoom.ReportDevices());
        Thread.Sleep(3000); // Wait for a while
        Console.WriteLine("Turning off all devices in the living room");
        livingRoom.TurnOffDevices(); // Turning off all devices in the living room
        Thread.Sleep(2000); // Wait for a while
        Console.WriteLine("Turning off all devices in the house");
        foreach(Room _ in home1Rooms)
        {
            _.TurnOffDevices(); // Turning off all devices in home 1
        }
        foreach(Room _ in home1Rooms)
        {
            Console.WriteLine(_.ReportLongestItem()); // Reporting on the longest running device(s) in each room
        }
                Console.WriteLine("Reporting all devices");
        foreach(Room _ in home1Rooms) // Report all devices in home1
        {
           Console.WriteLine(_.ReportDevices());
        }
    }
}