namespace MvcLabManager.Models;

public class Lab
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public string Block { get; set; }

    public Lab() { }

    public Lab(int id, int number, string name, string block)
    {
        Id = id;
        Number = number;
        Name = name;
        Block = block;
    }
}