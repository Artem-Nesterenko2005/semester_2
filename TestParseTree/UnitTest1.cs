public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestCommonExpression()
    {
        var tree = new ParseTree();
        var expression = "( * ( + 1 2 ) 3 )";
        string[] array = expression.Split(' ');
        tree.MakeTree(array);
        Assert.IsTrue(tree.operation!.operation == '*' && tree.rightChild!.operand!.operand == 3 && tree.leftChild!.operation!.operation == '+'
            && tree.leftChild.leftChild!.operand!.operand == 1 && tree.leftChild.rightChild!.operand!.operand == 2 && tree.CalculateResult(tree) == 9);
    }

    [Test]
    public void TestNegativeNumbers()
    {
        var tree = new ParseTree();
        var expression = "( / ( + -7 15 ) 4 )";
        string[] array = expression.Split(' ');
        tree.MakeTree(array);
        Assert.IsTrue(tree.CalculateResult(tree) == 2);
    }

    [Test]
    public void TestMultiDigitNumbers()
    {
        var tree = new ParseTree();
        var expression = "( + 123 ( * 20 ( / 10 2 ) ) )";
        string[] array = expression.Split(' ');
        tree.MakeTree(array);
        Assert.IsTrue(tree.CalculateResult(tree) == 223);
    }

    [Test]
    public void TestDivisorNull()
    {
        var tree = new ParseTree();
        var expression = "( / 10 0 )";
        string[] array = expression.Split(' ');
        tree.MakeTree(array);
        Assert.Throws<DivideByZeroException>(() => tree.CalculateResult(tree));
    }

    [Test]
    public void TestIncorrectExpression()
    {
        var tree = new ParseTree();
        var expression = "( + 1l 2 )";
        string[] array = expression.Split(' ');
        Assert.Throws<IncorrectSymbolInString>(() => tree.MakeTree(array));
    }
}
