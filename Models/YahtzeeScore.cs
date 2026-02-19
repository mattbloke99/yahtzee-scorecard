namespace Yahtzee.Models;

public class YahtzeeScore
{
    // Upper Section
    public int? Ones { get; set; }
    public int? Twos { get; set; }
    public int? Threes { get; set; }
    public int? Fours { get; set; }
    public int? Fives { get; set; }
    public int? Sixes { get; set; }

    // Lower Section - Variable Scores
    public int? ThreeOfKind { get; set; }
    public int? FourOfKind { get; set; }
    public int? Chance { get; set; }

    // Lower Section - Fixed Scores
    public int? FullHouse { get; set; }
    public int? SmallStraight { get; set; }
    public int? LargeStraight { get; set; }
    public int? Yahtzee { get; set; }

    // Yahtzee Bonuses (each worth 100)
    public List<bool> YahtzeeBonuses { get; set; } = new();

    // Calculated Properties
    public int UpperTotal => (Ones ?? 0) + (Twos ?? 0) + (Threes ?? 0) +
                             (Fours ?? 0) + (Fives ?? 0) + (Sixes ?? 0);

    public int UpperBonus => UpperTotal >= 63 ? 35 : 0;

    public int LowerTotal => (ThreeOfKind ?? 0) + (FourOfKind ?? 0) + (Chance ?? 0) +
                             (FullHouse ?? 0) +
                             (SmallStraight ?? 0) +
                             (LargeStraight ?? 0) +
                             (Yahtzee ?? 0) +
                             (YahtzeeBonuses.Count(b => b) * 100);

    public int GrandTotal => UpperTotal + UpperBonus + LowerTotal;
}
