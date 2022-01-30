using NUnit.Framework;

namespace OnePizza.Test;
public class SampleTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        const string input = @"3
2 cheese peppers
0
1 basil
1 pineapple
2 mushrooms tomatoes
1 basil";
        var builder = new PizzaBuilder();
        builder.ParseInput(input);
        Assert.AreEqual(3, builder.Clients.Count);
        Assert.AreEqual(2, builder.Clients[0].Likes.Count);
    }

    [Test]
    public void Test2()
    {
        const string input = @"3
2 cheese peppers
0
1 basil
1 pineapple
2 mushrooms tomatoes
1 basil";
        const string expected = "4 cheese mushrooms tomatoes peppers";
        var builder = new PizzaBuilder();
        builder.ParseInput(input);
        var ingredients = builder.MixIngredients();
        Assert.AreEqual(4, ingredients.Count);
        var result = builder.ProducePizza(ingredients);
        Assert.AreEqual(expected, result);
    }
}