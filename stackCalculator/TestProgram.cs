/// <summary>
/// class with program test
/// </summary>
public class TestProgram
{
    static private bool TestCase()
    {
        var errorCode = (ErrorCodes)0;
        string expression = "12 -4 +"; 
        var createArrayStack = new StackCalculator(new ArrayStack(expression.Split(' ').Length));
        double resultArray = StackCalculator.CalculateExpression(expression, ref errorCode);

        var createListStack = new StackCalculator(new ListStack(expression.Split(' ').Length));
        double resultList = StackCalculator.CalculateExpression(expression, ref errorCode);
        return resultArray == 8 && resultArray == resultList && errorCode == ErrorCodes.OK_CODE;
    }

    static private bool TestCaseDivisorNull()
    {
        var errorCode = (ErrorCodes)0;
        string expression = "1 0 /";
        var createArrayStack = new StackCalculator(new ArrayStack(expression.Split(' ').Length));
        double resultArray = StackCalculator.CalculateExpression(expression, ref errorCode);

        var createListStack = new StackCalculator(new ListStack(expression.Split(' ').Length));
        double resultList = StackCalculator.CalculateExpression(expression, ref errorCode);
        return resultArray == 0 && resultList == 0 && errorCode == ErrorCodes.DIVISOR_ZERO;
    }

    /// <summary>
    /// tests for a program
    /// </summary>
    /// <returns>result of the tests (true or false)</returns>
    static public bool Test()
    {
        return TestCase() && TestCaseDivisorNull();
    }
}
