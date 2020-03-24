using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ConsoleApp2;

namespace filter_out_evensTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            List<int> fullList = new List<int>() {1, 2, 3, 4, 5, 6, 22, 65, 99, 813, 22222 };
            List<int> evenList = new List<int>() { 1, 3, 5, 65, 99, 813 };
            
            //Act
            List<int> oddList = filter_out_evens(fullList);

            //Assert
            Assert.AreEqual(evenList, oddList);
        }
    }
}
