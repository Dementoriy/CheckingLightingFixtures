namespace LabsDB.Entity;

public class Room
{
    public Room()
    {
        Lamps = new List<Lamp>();
    }

    public int Id { get; set; }
    public IEnumerable<Lamp> Lamps { get; set; }
}