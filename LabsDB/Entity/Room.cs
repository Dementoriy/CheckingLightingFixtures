namespace LabsDB.Entity;

public class Room
{
    public Room()
    {
        Lamps = new List<Lamp>();
    }

    public int Id { get; set; }
    public List<Lamp> Lamps { get; set; }
}