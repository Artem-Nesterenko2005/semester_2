public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestAddDataToList()
    {
        List<int> list = new List<int>();
        list.Add(1, 1);
        list.Add(2, 3);
        Assert.IsTrue(list.data == 0 && list.next.data == 1 && list.next.next.data == 3);
    }

    [Test]
    public void TestAddSameDataToUniqueList()
    {
        UniqueList<int> uniqueList = new UniqueList<int>();
        uniqueList.AddUniqueList(1, 1);
        uniqueList.AddUniqueList(3, 2);
        Assert.Throws<RepeatingElement>(() => uniqueList.AddUniqueList(4, 2));
    }

    [Test]
    public void TestDeleteDataFromList()
    {
        List<int> list = new List<int>();
        list.Add(1, 1);
        list.Add(2, 3);
        list.Remove(2, 3);
        Assert.IsTrue(list.data == 0 && list.next.data == 1 && list.next.next.data == 0);
    }

    [Test]
    public void TestDeleteNonExistentDataFromList()
    {
        List<int> list = new List<int>();
        list.Add(1, 1);
        list.Add(2, 2);
        Assert.Throws<BeyondListBoundaries>(() => list.Remove(2, 3));
    }

    [Test]
    public void TestChangeByIndex()
    {
        List<int> list = new List<int>();
        list.Add(3, 4);
        list.Add(5, 2);
        Assert.Throws<BeyondListBoundaries>(() => list.ChangeByIndex(6, 2));
    }

    [Test]
    public void TestChangeByIndexUniqueList()
    {
        UniqueList<int> uniqueList = new UniqueList<int>();
        uniqueList.AddUniqueList(1, 1);
        uniqueList.AddUniqueList(3, 2);
        Assert.Throws<NonExistentElement>(() => uniqueList.ChangeByIndexUniqueList(2, 4));
    }
}
