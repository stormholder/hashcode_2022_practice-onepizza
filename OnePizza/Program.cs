using OnePizza;

if (args.Length < 2)
{
	Console.WriteLine("2 arguments required: Input file, output file");
	return;
}

try
{
    string file = "";
	using (var sr = new StreamReader(args[0]))
    {
        file = sr.ReadToEnd();
    }
    var simulation = new Simulation(file);
    var pizzaBuilder = new PizzaBuilder();
    var ingredients = pizzaBuilder.MixIngredientsForClients(
        simulation.Clients.SelectMany(c => c.Likes),
        simulation.Clients.SelectMany(c => c.Dislikes)
    );
    string? output = pizzaBuilder.ProducePizza(ingredients);
    int score = simulation.Run(ingredients);

    Console.WriteLine("Score for this simulation: " + score);

    using (var sw = new StreamWriter(args[1]))
    {
        sw.WriteLine(output);
    }
}
catch (Exception ex)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(ex.Message);
    return;
}