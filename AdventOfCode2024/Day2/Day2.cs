namespace AdventOfCode2024.Day2;

public class Day2Solver : ISolver
{
    public string SolvePart1(string input)
    {
        return input
            .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line
                .Split()
                .Select(int.Parse)
                .ToList())
            .Select(GetDiffs)
            .Count(IsSafe)
            .ToString();
    }

    public string SolvePart2(string input)
    {
        return input
            .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line
                .Split()
                .Select(int.Parse)
                .ToList())
            .Count(IsSafeWithoutOne)
            .ToString();
    }

    private bool IsMonotonous(List<int> diffs)
        => diffs.All(e => e >= 0) || diffs.All(e => e <= 0);

    private bool IsDiffBounded(List<int> diffs)
        => diffs.All(e => Math.Abs(e) >= 1 && Math.Abs(e) <= 3);

    private bool IsSafe(List<int> diffs)
        => IsMonotonous(diffs) && IsDiffBounded(diffs);

    private bool IsSafeWithoutOne(List<int> values)
    {
        return values
            .Select((_, i) => values
                .Take(i)
                .Concat(values
                    .Skip(i + 1)
                    .Take(values.Count - i - 1))
                .ToList())
            .Select(GetDiffs)
            .Any(IsSafe);
    }

    private List<int> GetDiffs(List<int> values)
    {
        var diffs = new List<int>();
        for (var i = 0; i < values.Count - 1; i++)
            diffs.Add(values[i] - values[i + 1]);
        return diffs;
    }
}