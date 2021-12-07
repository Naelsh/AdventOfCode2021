using NUnit.Framework;
using System.Collections.Generic;
using AdventOfCode2021.Extensions;

namespace AdventOfCode2021.Test.Unit.Extensions
{
    [TestFixture]
    class ListExtensionTest
    {
        [Test]
        public void GetProperUniqeListFromIntegerList()
        {
            List<int> list = new List<int>();
            for (int count = 0; count < 10; count++)
            {
                list.Add(count);
                list.Add(count);
            }
            list = list.RemoveDuplicates();

            Assert.AreEqual(10, list.Count);
        }
    }
}
