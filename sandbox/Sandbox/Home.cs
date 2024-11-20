using System;

public class Home
{
    private string _name;
    private List<Room> _rooms;

    public Home(string name) // Constructor
    {
        _name = name;
        _rooms = new List<Room>();
    }

    public void AddNewRoom(string name, int ligthCount=1, int heaterCount=1, int tvCount=1)
    {
        _rooms.Add(new Room(name, ligthCount, heaterCount, tvCount));
    }
    public void AddRoom(Room _)
    {
        _rooms.Add(_);
    }
    public List<Room> GetRooms()
    {
        return _rooms;
    }
}