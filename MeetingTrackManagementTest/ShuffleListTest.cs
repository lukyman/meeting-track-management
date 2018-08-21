using MeetingTrackManagement.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MeetingTrackManagementTest
{
    [TestClass]
    public class ShuffleListTest
    {
        [TestMethod]
        public void ShuffleTest_LengthDoesNotChange_True()
        {
            var mylist = new List<int>();
            mylist.Add(9);
            mylist.Add(7);
            mylist.Add(3);
            var shuffled = ShuffleList.Shuffle<int>(mylist);
            Assert.AreEqual(3, shuffled.Count);
        }
        [TestMethod]
        public void ShuffleTest_ItemChangeIndex_True()
        {
            var mylist = new List<int>();
            mylist.Add(9);
            mylist.Add(7);
            mylist.Add(3);
            var shuffled = ShuffleList.Shuffle<int>(mylist);
            Assert.AreNotEqual(1, shuffled.IndexOf(7));
        }
    } 
}
