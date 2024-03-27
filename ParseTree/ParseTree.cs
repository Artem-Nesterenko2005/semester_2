/// <summary>
/// a class for a parse tree with arithmetic operations that are performed on numbers lying in the child nodes of the operation, 
/// contains methods for calculating the result of an expression in a tree, printing a tree, building a tree
/// </summary>
public class ParseTree
{
    /// <summary>
    /// integer at a tree node
    /// </summary>
    public Operand ?operand;

    /// <summary>
    /// arithmetic operation at a tree node
    /// </summary>
    public Operations ?operation;

    /// <summary>
    /// one of the children of the current node containing the operation or operand
    /// </summary>
    public ParseTree ?leftChild;

    /// <summary>
    /// one of the children of the current node containing the operation or operand
    /// </summary>
    public ParseTree ?rightChild;

    /// <summary>
    /// the node that is the parent of this node
    /// </summary>
    public ParseTree ?parent;

    /// <summary>
    /// create the root of a tree 
    /// </summary>
    public ParseTree()
    {
        operand = new Operand();
        operation = new Operations();
    }

    private void CreateNode(ref ParseTree tree, string child)
    {
        if (child == "left")
        {
            tree.leftChild = new ParseTree();
            tree.leftChild.parent = tree;
            tree = tree.leftChild;
            return;
        }

        tree.rightChild = new ParseTree();
        tree.rightChild.parent = tree;
        tree = tree.rightChild;
        return;
    }

    private void AddSymbol(ref ParseTree tree, string data)
    {
        switch (data)
        {
            case "+":
            case "-":
            case "/":
            case "*":
                if (tree.operation!.operation == '\0')
                {
                    tree.operation.operation = data[0];
                    return;
                }

                if (tree.leftChild == null)
                {
                    CreateNode(ref tree, "left");
                }
                else
                {
                    CreateNode(ref tree, "right");
                }

                tree.operation!.operation = data[0];
                return;

            case ")":
                tree = tree.parent!;
                break;

            case "(":
            case " ":
            case "":
                return;
              
            default:
                if (tree.leftChild == null)
                {
                    CreateNode(ref tree, "left");
                }
                else
                {
                    CreateNode(ref tree, "right");
                }
                tree.operand!.operand = int.Parse(data);
                tree = tree.parent!;
                return;
        }
    }

    /// <summary>
    /// builds a tree from a given array of strings
    /// </summary>
    /// <param name="expression">an array of strings of elements from the original expression</param>
    /// <exception cref="IncorrectSymbolInString">exception thrown when a character is encountered that should not be in the expression</exception>
    public void MakeTree(string[] expression)
    {
        ParseTree tree = this;
        foreach (var i in expression)
        {
            if (i != "+" && i != "-" && i != "*" && i !="/" && i != "/" && i != ")" && i != "" && i != "(" && i != " " && !int.TryParse(i, out var number))
            {
                throw new IncorrectSymbolInString("this element cannot be in a valid string, there can only be operations, integers, brackets, spaces");
            }
            AddSymbol(ref tree, i.ToString());
        }
    }

    /// <summary>
    /// prints the tree as the original expression
    /// </summary>
    /// <param name="tree">given constructed tree</param>
    public void PrintTree(ParseTree tree)
    {
        if (tree.operation!.operation != '\0')
        {
            Console.Write("( ");
            tree.operation.Print();
        }
        else
        {
            tree.operand!.Print();
        }

        if (tree.leftChild != null)
        {
            PrintTree(tree.leftChild);
        }

        if (tree.rightChild != null)
        {
            PrintTree(tree.rightChild);
            Console.Write(") ");
        }
    }

    /// <summary>
    /// calculates the value of an expression based on the constructed tree
    /// </summary>
    /// <param name="tree">given constructed tree</param>
    /// <returns>result of the expression</returns>
    public int CalculateResult(ParseTree tree)
    {
        if (tree.leftChild == null)
        {
            return tree.operand!.Calculate();
        }
        int number1 = CalculateResult(tree.leftChild);
        int number2 = CalculateResult(tree.rightChild!);
        char operation = tree.operation!.operation;
        return tree.operation.Calculate(number1, number2);
    }
}
