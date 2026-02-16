namespace Yahtzee.Services;

public class ScoreService
{
    public List<int> GetPossibleValues(string category)
    {
        return category switch
        {
            "Ones" => new List<int> { 0, 1, 2, 3, 4, 5 },
            "Twos" => new List<int> { 0, 2, 4, 6, 8, 10 },
            "Threes" => new List<int> { 0, 3, 6, 9, 12, 15 },
            "Fours" => new List<int> { 0, 4, 8, 12, 16, 20 },
            "Fives" => new List<int> { 0, 5, 10, 15, 20, 25 },
            "Sixes" => new List<int> { 0, 6, 12, 18, 24, 30 },
            _ => new List<int>()
        };
    }

    public bool ValidateVariableScore(int value, int min = 5, int max = 30)
    {
        return value >= min && value <= max;
    }
}
