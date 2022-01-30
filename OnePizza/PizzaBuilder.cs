namespace OnePizza
{
    public class PizzaBuilder
    {
        private List<Client> _clients = new();

        public List<Client> Clients => _clients;
        public int ClientCount => _clients.Count;

        public string ProducePizza(SortedSet<string> ingredients) => ingredients.Count.ToString() + " " + string.Join(' ', ingredients);

        public SortedSet<string> MixIngredients()
        {
            HashSet<string> accept = new();
            HashSet<string> reject = new();
            foreach (string? like in from client in _clients
                                 from string? like in client.Likes
                                 select like)
            {
                accept.Add(like);
            }
            foreach (string? dislike in from client in _clients
                                from string? dislike in client.Dislikes
                                select dislike)
            {
                reject.Add(dislike);
            }

            foreach (var r in from r in reject
                              where accept.Contains(r)
                              select r)
            {
                accept.Remove(r);
            }

            return new SortedSet<string>(accept);
        }

        public async void ParseInput(string input)
        {
            int lineCounter = 1;
            using (StringReader reader = new StringReader(input))
            {
                var firstLine = await reader.ReadLineAsync();
                var clients = int.Parse(firstLine);
                int maxLines = clients * 2 + 1;
                var client = new Client();

                while (lineCounter < maxLines)
                {
                    bool isLike = lineCounter % 2 == 1;
                    var line = await reader.ReadLineAsync();
                    lineCounter++;
                    var preferences = client.ParsePreferenceLine(line);
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
    }
}
