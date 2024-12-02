using System.Reflection;

namespace AdventOfCode2024;

public static class SolverFactory
{
    public static ISolver CreateSolver(int day)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var solverType = assembly.GetType($"{assembly.GetName().Name}.Day{day}Solver") 
                         ?? throw new NotImplementedException();
        var solverObject = Activator.CreateInstance(solverType) 
                           ?? throw new NullReferenceException("Can not initialise solver");
        return new Solver(solverObject);
    }
}

public class Solver : ISolver
{
    private readonly object solverObject;
    
    public Solver(object solverObject) => this.solverObject = solverObject;

    public string SolvePart1(string input)
    {
        return (solverObject.GetType()
            .GetMethod(nameof(ISolver.SolvePart1), BindingFlags.Instance | BindingFlags.Public)!
            .Invoke(solverObject, new object[] { input }) as string)!;
    }

    public string SolvePart2(string input)
    {
        return (solverObject.GetType()
            .GetMethod(nameof(ISolver.SolvePart2), BindingFlags.Instance | BindingFlags.Public)!
            .Invoke(solverObject, new object[] { input }) as string)!;
    }
}