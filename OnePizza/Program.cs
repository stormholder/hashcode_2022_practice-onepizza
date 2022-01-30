Console.WriteLine("Hello, World!");
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
    var pizzaBuilder = new OnePizza.PizzaBuilder();
    pizzaBuilder.ParseInput(file);
    var ingredients = pizzaBuilder.MixIngredients();
    string? output = pizzaBuilder.ProducePizza(ingredients);

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