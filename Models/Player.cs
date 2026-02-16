namespace Yahtzee.Models;

public class Player
{
    public string Name { get; set; } = string.Empty;
    public YahtzeeScore Scores { get; set; } = new();
}
