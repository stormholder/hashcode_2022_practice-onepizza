using System.Linq;

namespace OnePizza;
public class Simulation
{
    private string _input;
    public string Input => _input;
    private List<Client> _clients = new();
    public List<Client> Clients => _clients;
    public int ClientCount => _clients.Count;

    public Simulation(string input)
    {
        _input = input;
        ParseInput(_input);
    }

    public List<string> ParsePreferenceLine(string line)
    {
        List<string> result = new();
        string[] parts = line.Split(' ')[1..];
        if (parts.Length == 0)
            return result;
        result.AddRange(from string v in parts select v);
        return result;
    }

    public async void ParseInput(string input)
    {
        int lineCounter = 1;
        using (StringReader reader = new StringReader(input))
        {
            var firstLine = await reader.ReadLineAsync();
            var clients = int.Parse(firstLine!);
            int maxLines = clients * 2 + 1;
            var client = new Client();

            while (lineCounter < maxLines)
            {
                bool isLike = lineCounter % 2 == 1;
                var line = await reader.ReadLineAsync();
                lineCounter++;
                var preferences = ParsePreferenceLine(line!);
                if (isLike)
                {
                    client.Likes.AddRange(preferences);
                }
                else
                {
                    client.Dislikes.AddRange(preferences);
                    _clients.Add(client);
                    client = new Client();
                }
            }
        }
    }

    public int Run(SortedSet<string> ingredients)
    {
        int score = 0;

        foreach(var client in _clients)
        {
            bool allLikes = client.Likes.Where(like => !ingredients.Contains(like)).Count() == 0;
            bool allDislikes = client.Dislikes.Where(dislike => ingredients.Contains(dislike)).Count() == 0;
            if (allLikes && allDislikes)
            {
                score++;
            }
        }

        return score;
    }
}
