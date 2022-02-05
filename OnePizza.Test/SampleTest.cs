using NUnit.Framework;
using System.Linq;

namespace OnePizza.Test;
public class SampleTest
{
    private const string _input = @"3
2 cheese peppers
0
1 basil
1 pineapple
2 mushrooms tomatoes
1 basil";

    [Test]
    public void Test1()
    {
        var parser = new Simulation(_input);
        Assert.AreEqual(3, parser.ClientCount);
        Assert.AreEqual(2, parser.Clients[0].Likes.Count);
    }

    [Test]
    public void Test2()
    {
        var simulation = new Simulation(_input);
        const string expected = "4 cheese mushrooms tomatoes peppers";
        var parsedExpected = simulation.ParsePreferenceLine(expected);
        parsedExpected.Sort();

        var builder = new PizzaBuilder();
        var ingredients = builder.MixIngredientsForClients(
            simulation.Clients.SelectMany(c => c.Likes),
            simulation.Clients.SelectMany(c => c.Dislikes)
        );
        Assert.AreEqual(parsedExpected, ingredients);
    }

    [Test]
    public void Test3()
    {
        var simulation = new Simulation(_input);
        var builder = new PizzaBuilder();
        var ingredients = builder.MixIngredientsForClients(
            simulation.Clients.SelectMany(c => c.Likes),
            simulation.Clients.SelectMany(c => c.Dislikes)
        );
        var score = simulation.Run(ingredients);
        Assert.AreEqual(2, score);
    }
}