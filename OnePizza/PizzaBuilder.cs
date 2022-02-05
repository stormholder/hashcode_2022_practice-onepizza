using System.Linq;

namespace OnePizza
{
    public class PizzaBuilder
    {
        public string ProducePizza(SortedSet<string> ingredients) => ingredients.Count.ToString() + " " + string.Join(' ', ingredients);

        public SortedSet<string> MixIngredientsForClients(IEnumerable<string> likes, IEnumerable<string> dislikes)
        {
            SortedSet<string> result = new();
            Dictionary<string, int> accept = new();
            Dictionary<string, int> reject = new();

            foreach (var like in likes)
            {
                if (!accept.ContainsKey(like))
                {
                    accept.Add(like, 0);
                }
                accept[like]++;
            }

            foreach (var dislike in dislikes)
            {
                if (!reject.ContainsKey(dislike))
                {
                    reject.Add(dislike, 0);
                }
                reject[dislike]++;
            }

            foreach (var ingredient in accept.Keys)
            {
                if (!reject.ContainsKey(ingredient))
                {
                    result.Add(ingredient);
                    continue;
                }
                if (reject[ingredient] < accept[ingredient])
                {
                    result.Add(ingredient);
                }
            }

            return result;
        }
    }
}
