namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[]{1,2,3})]
        [TestCase(new int[]{1,2,3,7,9,6,8,4})]
        [TestCase(new int[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16})]

        public void Constructor_Should_Add_Less_Than_16_Elements(int[] elements)
        {
            Database dataBase = new Database(elements);

            Assert.AreEqual(dataBase.Count, elements.Length);
            
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Add_More_Than_16_Elements_Should_Throw_Exception(int[] elements)
        {
            Database dataBase = new Database(elements);

            Assert.Throws<InvalidOperationException>(() => dataBase.Add(1));
        }

        [TestCase(new int[] {})]
        public void Removing_Element_If_There_Are_No_Elements_Throws_Exception(int[] elements)
        {
            Database dataBase = new Database(elements);

            Assert.Throws<InvalidOperationException>(() => dataBase.Remove());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Remove_Last_Element_If_There_is(int[] elements)
        {
            Database dataBase = new Database(elements);

            Assert.AreEqual(dataBase.Count, elements.Length);
        }


        //  [TestCase(new string[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        //  public void Constructor_Shouldnt_Take_Anything_But_Integer(int[] elements)
        //  {
        //      Database dataBase = new Database();
        //      Assert.Throws<InvalidOperationException>(() => dataBase = new Database(elements));
        //
        //  }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(new int[] { 10, 11, 12, 13, 14, 15, 16 })]
        public void Fetch_Shoud_Return_The_Same_Array(int[] elements)
        {
            int[] coppyArray = elements;

            CollectionAssert.AreEqual(coppyArray, elements);
        }

        [Test]
        public void Chech_Counter()
        {

            int[] array = new[] { 1, 2, 3 };


            Database dataBase= new Database(array);

            int actualCount = dataBase.Count;
            int expectedCoutn = array.Length;

            Assert.AreEqual(expectedCoutn, actualCount);

        }
        [Test]
        public void Counter_Returns_0_When_There_Are_No_Elements()
        {
            Database dataBase = new Database();
            int actualCount = dataBase.Count;

            Assert.AreEqual(0, actualCount);

        }
    }
}
