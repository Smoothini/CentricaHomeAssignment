using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataLayerUnitTest
{
    public interface IDBUnitTests
    {
        [TestMethod]
        public void GetAllTest();


        [TestMethod]
        public void AddRemoveEntityTest();


        [TestMethod]
        public void UpdateEntityTest();


        [TestMethod]
        [ExpectedException(typeof(DataLayer.IllegalDataArgumentException))]
        public void AddIllegalTest();


        [TestMethod]
        [ExpectedException(typeof(DataLayer.IllegalDataArgumentException))]
        public void RemoveIllegalTest();


        [TestMethod]
        [ExpectedException(typeof(DataLayer.IllegalDataArgumentException))]
        public void UpdateIllegalTest();


    }
}
