namespace Yahtzee.Models;

public class Game
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<Player> Players { get; set; } = new();
    public DateTime Created { get; set; } = DateTime.Now;
    public bool IsComplete { get; set; }
}
