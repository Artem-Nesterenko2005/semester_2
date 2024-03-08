namespace TestStackCalculator
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestArrayStackFractionalNumber()
        {
            var errorCode = (ErrorCodes)0;
            var createArrayStack = new StackCalculator(new ArrayStack(3));
            Assert.IsTrue(StackCalculator.CalculateExpression("1.2 3.5 +", ref errorCode) == 0 && errorCode == ErrorCodes.INCORRECT_SYMBOL);
        }

        [Test]
        public void TestListStackFractionalNumber()
        {
            var errorCode = (ErrorCodes)0;
            var createArrayStack = new StackCalculator(new ArrayStack(3));
            Assert.IsTrue(StackCalculator.CalculateExpression("1.2 3.5 +", ref errorCode) == 0 && errorCode == ErrorCodes.INCORRECT_SYMBOL);
        }

        [Test]
        public void TestArrayStackNegativeNumber()
        {
            var errorCode = (ErrorCodes)0;
            var createArrayStack = new StackCalculator(new ArrayStack(5));
            Assert.IsTrue(StackCalculator.CalculateExpression("-3 -4 + -5 -", ref errorCode) == -2 && errorCode == ErrorCodes.OK_CODE);
        }

        [Test]
        public void TestListStackNegativeNumber()
        {
            var errorCode = (ErrorCodes)0;
            var createArrayStack = new StackCalculator(new ArrayStack(5));
            Assert.IsTrue(StackCalculator.CalculateExpression("-3 -4 + -5 -", ref errorCode) == -2 && errorCode == ErrorCodes.OK_CODE);
        }

        [Test]
        public void TestArrayStackLongNumber()
        {
            var errorCode = (ErrorCodes)0;
            var createArrayStack = new StackCalculator(new ArrayStack(5));
            Assert.IsTrue(StackCalculator.CalculateExpression("174556 5367 - 12 *", ref errorCode) == 2030268 && errorCode == ErrorCodes.OK_CODE);
        }

        [Test]
        public void TestListStackLongNumber()
        {
            var errorCode = (ErrorCodes)0;
            var createArrayStack = new StackCalculator(new ArrayStack(5));
            Assert.IsTrue(StackCalculator.CalculateExpression("174556 5367 - 12 *", ref errorCode) == 2030268 && errorCode == ErrorCodes.OK_CODE);
        }

        [Test]
        public void TestArrayStackStringWithoutSpace()
        {
            var errorCode = (ErrorCodes)0;
            var createArrayStack = new StackCalculator(new ArrayStack(3));
            Assert.IsTrue(StackCalculator.CalculateExpression("12+", ref errorCode) == 0 && errorCode == ErrorCodes.ERROR_STACK);
        }

        [Test]
        public void TestListStackStringWithoutSpace()
        {
            var errorCode = (ErrorCodes)0;
            var createArrayStack = new StackCalculator(new ArrayStack(3));
            Assert.IsTrue(StackCalculator.CalculateExpression("12+", ref errorCode) == 0 && errorCode == ErrorCodes.ERROR_STACK);
        }

        [Test]
        public void TestArrayStackIncorrectString()
        {
            var errorCode = (ErrorCodes)0;
            var createArrayStack = new StackCalculator(new ArrayStack(5));
            Assert.IsTrue(StackCalculator.CalculateExpression("qiaud", ref errorCode) == 0 && errorCode == ErrorCodes.INCORRECT_SYMBOL);
        }

        [Test]
        public void TestListStackStringIncorrectString()
        {
            var errorCode = (ErrorCodes)0;
            var createArrayStack = new StackCalculator(new ArrayStack(5));
            Assert.IsTrue(StackCalculator.CalculateExpression("abfke", ref errorCode) == 0 && errorCode == ErrorCodes.INCORRECT_SYMBOL);
        }
    }
}
