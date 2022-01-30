using System.Linq;

namespace OnePizza;
public class Client
{
    public List<string> Likes { get; set; } = new();
    public List<string> Dislikes { get; set; } = new();

    public List<string> ParsePreferenceLine(string line)
    {
        List<string> result = new();
        string[] parts = line.Split(' ')[1..];
        if (parts.Length == 0)
            return result;
        result.AddRange(from string v in parts
                        select v);
        return result;
    }
}
