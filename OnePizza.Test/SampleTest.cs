using NUnit.Framework;

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
        var builder = new PizzaBuilder();
        builder.ParseInput(_input);
        Assert.AreEqual(3, builder.ClientCount);
        Assert.AreEqual(2, builder.Clients[0].Likes.Count);
    }

    [Test]
    public void Test2()
    {
        const string expected = "4 cheese mushrooms tomatoes peppers";
        var client = new Client();
        var parsedExpected = client.ParsePreferenceLine(expected);
        parsedExpected.Sort();

        var builder = new PizzaBuilder();
        builder.ParseInput(_input);
        var ingredients = builder.MixIngredients();
        Assert.AreEqual(parsedExpected, ingredients);
    }
}