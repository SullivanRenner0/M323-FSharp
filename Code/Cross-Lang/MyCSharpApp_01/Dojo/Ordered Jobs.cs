using System;
using System.Linq;

namespace MyCSharpApp_01.Dojo;

internal interface IOrdered_Jobs
{
    void Register(char job);
    void Register(char job, char dependency);
    string Sort();
}
internal class Ordered_Jobs : IOrdered_Jobs
{
    private readonly Dictionary<char, HashSet<char>> _jobDependencies = [];

    public void Register(char job)
    {
        if (_jobDependencies.ContainsKey(job) == false)
            _jobDependencies[job] = [];
    }
    public void Register(char job, char dependency)
    {
        Register(job);
        Register(dependency);

        if (job != dependency)
            _jobDependencies[job].Add(dependency);
    }

    public string Sort()
    {
        var result = new List<char>();
        var visited = new Dictionary<char, bool>();

        foreach (var job in _jobDependencies.Keys)
        {
            if (visited.ContainsKey(job))
                continue;

            if (DFSSearch(job, visited, result) == false)
                throw new InvalidOperationException("Circular dependency detected");
        }

        return new string(result.ToArray());
    }

    private bool DFSSearch(char job, Dictionary<char, bool> visited, List<char> result)
    {
        if (visited.TryGetValue(job, out var res))
            return res;

        visited[job] = false;
        foreach (var dependecy in _jobDependencies[job])
        {
            if (DFSSearch(dependecy, visited, result) == false)
                return false;
        }

        visited[job] = true;
        result.Add(job);
        return true;
    }
}
