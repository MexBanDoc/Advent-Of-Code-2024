using AdventOfCode2024;

var now = DateTime.UtcNow;
var day = 1;
if (now is {Year: 2024, Month: 12, Day: <= 25})
    day = now.Day;

Console.WriteLine("# Advent of Code 2024");
Console.WriteLine($"# Current day is {day}");
Console.WriteLine();

// todo (belov 02.12.2024): добавить загрузку файлов с сайта
var exampleInput = File.ReadAllText($@"Day{day}\example.txt");
var input = File.ReadAllText($@"Day{day}\input.txt");

var solver = SolverFactory.CreateSolver(day);

var exampleAns1 = solver.SolvePart1(exampleInput);
var exampleAns2 = solver.SolvePart2(exampleInput);
Console.WriteLine($"Example Part 1: {exampleAns1}");
Console.WriteLine($"Example Part 2: {exampleAns2}");
Console.WriteLine();

var ans1 = solver.SolvePart1(input);
var ans2 = solver.SolvePart2(input);
Console.WriteLine($"Part 1: {ans1}");
Console.WriteLine($"Part 2: {ans2}");