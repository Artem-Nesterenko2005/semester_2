namespace TestBor
{
    public class Tests
    {
        private Bor testBor;

        [SetUp]
        public void Setup()
        {
            testBor = new Bor();
        }

        [Test]
        public void TestAddEmptyString()
        {
            Assert.IsFalse(testBor.Add(""));
        }

        [Test]
        public void TestAddIdenticalStrings()
        {
            Assert.IsTrue(testBor.Add("qwe"));
            Assert.IsFalse(testBor.Add("qwe"));
            Assert.IsTrue(testBor.size == 1);
        }

        [Test]
        public void TestAddDifferentStrings()
        {
            Assert.IsTrue(testBor.Add("qwe"));
            Assert.IsTrue(testBor.Add("asd"));
            Assert.IsTrue(testBor.size == 2);
        }

        [Test]
        public void TestContainedStrings()
        {
            Assert.IsTrue(testBor.Add("qwe"));
            Assert.IsTrue(testBor.Add("qwer"));
            Assert.IsTrue(testBor.Contains("qwe"));
            Assert.IsFalse(testBor.Contains("qw"));
            Assert.IsTrue(testBor.Contains("qwer"));
        }

        [Test]
        public void TestContainedEmptyString()
        {
            Assert.IsFalse(testBor.Contains("qwe"));
        }

        [Test]
        public void TestRemoveString()
        {
            Assert.IsTrue(testBor.Add("qwe"));
            Assert.IsTrue(testBor.Add("qwer"));
            Assert.IsFalse(testBor.Remove("qw"));
            Assert.IsTrue(testBor.Remove("qwe"));
            Assert.IsFalse(testBor.Remove(""));
            Assert.IsTrue(testBor.Contains("qwer"));
            Assert.IsFalse(testBor.Contains("qwe"));
        }

        [Test]
        public void TestPrefixCountString()
        {
            Assert.IsTrue(testBor.Add("qwe"));
            Assert.IsTrue(testBor.Add("qwer"));
            Assert.IsTrue(testBor.HowManyStartsWithPrefix("qw") == 2);
            Assert.IsTrue(testBor.HowManyStartsWithPrefix("asd") == 0);
            Assert.IsTrue(testBor.HowManyStartsWithPrefix("qwerty") == 0);
        }
    }
}
