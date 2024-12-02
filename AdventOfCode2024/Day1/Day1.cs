namespace AdventOfCode2024.Day1;

public class Day1Solver : ISolver
{
    public string SolvePart1(string input)
    {
        var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var (firstList, secondList) = GetOrderedLists(lines);

        var ans = firstList.Select((t, i) => Math.Max(t, secondList[i]) - Math.Min(t, secondList[i])).Sum();
        return ans.ToString();
    }
    
    public string SolvePart2(string input)
    {
        var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var (firstList, secondList) = GetOrderedLists(lines);

        var ans = firstList.Sum(t => t * secondList.Count(e => e == t));
        return ans.ToString();
    }

    private (List<int>, List<int>) GetOrderedLists(string[] input)
    {
        var firstList = new List<int>();
        var secondList = new List<int>();

        foreach (var line in input)
        {
            var values = line.Split("   ");
            firstList.Add(int.Parse(values[0]));
            secondList.Add(int.Parse(values[1]));
        }

        var orderedFirstList = firstList.OrderBy(e => e).ToList();
        var orderedSecondList = secondList.OrderBy(e => e).ToList();
        
        return (orderedFirstList, orderedSecondList);
    }
}