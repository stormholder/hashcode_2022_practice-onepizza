using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace OnePizza.Test;
public class ParseTest
{
    private const string _input1 = @"3
2 cheese peppers
0
1 basil
1 pineapple
2 mushrooms tomatoes
1 basil";
    private const string _input2 = @"5
2 akuof byyii
0
2 dlust luncl
0
2 akuof luncl
0
2 dlust vxglq
0
2 dlust xveqd
0
";
    private const string _input3 = @"10
3 akuof byyii dlust
1 xdozp
3 dlust luncl qzfyo
1 xdozp
3 akuof luncl vxglq
1 qzfyo
3 dlust vxglq luncl
0
3 dlust xveqd tfeej
0
3 qzfyo vxglq luncl
1 byyii
3 luncl xdozp xveqd
1 sunhp
3 byyii xdozp tfeej
1 qzfyo
3 dlust akuof tfeej
1 xveqd
3 vxglq dlust byyii
1 akuof
";
    
    [TestCase(_input1, 3)]
    [TestCase(_input2, 5)]
    [TestCase(_input3, 10)]
    public void Test1(string input, int count)
    {
        var builder = new PizzaBuilder();
        builder.ParseInput(input);
        Assert.AreEqual(count, builder.ClientCount);
    }

    [Test, TestCaseSource(typeof(ParseTestData), nameof(ParseTestData.TestCases))]
    public SortedSet<string> Test2(string value)
    {
        var builder = new PizzaBuilder();
        builder.ParseInput(value);
        var ingredients = builder.MixIngredients();
        return ingredients;
    }

    public class ParseTestData
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(_input1).Returns(new SortedSet<string>() { "cheese", "mushrooms", "tomatoes", "peppers" });
                yield return new TestCaseData(_input2).Returns(new SortedSet<string>() { "akuof", "byyii", "dlust", "luncl", "vxglq", "xveqd" });
            }
        }
    }
}
