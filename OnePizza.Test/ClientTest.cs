using NUnit.Framework;
using System.Linq;

namespace OnePizza.Test;

[TestFixture]
public class ClientTest
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("4 cheese mushrooms tomatoes peppers", 4)]
    [TestCase("2 mushrooms tomatoes", 2)]
    [TestCase("0", 0)]
    [TestCase("1 basil", 1)]
    public void Test1(string value, int count)
    {
        var client = new Client();
        var r1 = client.ParsePreferenceLine(value);
        Assert.AreEqual(count, r1.Count());
    }
}
