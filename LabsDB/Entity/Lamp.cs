namespace LabsDB.Entity;

public class Lamp
{
    public int id { get; set; }
    public bool Glows { get; set; }
    public DateTime TimeStamp { get; set; }
    public Room Room { get; set; }
    public int RoomId { get; set; }
    
    public Lamp()
    {
        Glows = false;
        TimeStamp = DateTime.Now;
        Room = new Room();
    }

    public Lamp(bool glows, DateTime timeStamp, Room room)
    {
        Glows = glows;
        TimeStamp = timeStamp;
        Room = room;
        RoomId = room.Id;
    }
}