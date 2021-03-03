using System.Linq;
using DataLayer;
using DataLayer.DAO;
using DataLayer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DataLayerUnitTest
{
    [TestClass]
    public class DBStoreTest
    {
        private readonly DBConnect dBConnect = new DBConnect();


        [TestMethod]
        public void AddRemoveEntityTest()
        {
            DBStore dB = new DBStore(this.dBConnect);
            var sp = new Store()
            {
                Name = "Netto",
                DistrictID = 1
            };


            var stores = dB.GetAll();
            var oldCount = stores.Count();

            dB.Create(sp);
            Assert.IsTrue(dB.GetAll().Count() > oldCount, "Store not created");

            stores = dB.GetAll();
            sp = stores.Last();

            dB.Delete(sp.ID);

            Assert.IsTrue(dB.GetAll().Count() == oldCount, "Store not removed");
        }

        [TestMethod]
        public void GetAllTest()
        {
            DBStore dB = new DBStore(this.dBConnect);
            var ppl = dB.GetAll();

            Assert.IsNotNull(ppl, "Null object returned");
            Assert.IsTrue(ppl.Count() > 0, "There are no stores");
        }


        [TestMethod]
        public void UpdateGetEntityTest()
        {
            DBStore dB = new DBStore(this.dBConnect);

            var sp = dB.Get(1);
            Assert.IsNotNull(sp, "Store not retrieved");

            var oldName = sp.Name;

            sp.Name = "Testttt";
            dB.Update(sp);
            Assert.IsTrue(dB.Get(sp.ID).Name != oldName, "Name not changed");

            sp.Name = oldName;

            dB.Update(sp);

            Assert.IsTrue(dB.Get(sp.ID).Name == oldName, "Name not reverted");

        }

        [TestMethod]
        [ExpectedException(typeof(IllegalDataArgumentException))]
        public void AddIllegalTest()
        {
            DBStore dB = new DBStore(this.dBConnect);
            dB.Create(new Store()
            {
                Name = null
            });
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalDataArgumentException))]
        public void RemoveIllegalNegativeTest()
        {
            DBStore dB = new DBStore(this.dBConnect);
            dB.Delete(-1);
        }


        [TestMethod]
        [ExpectedException(typeof(IllegalDataArgumentException))]
        public void UpdateIllegalNegativeTest()
        {
            DBStore dB = new DBStore(this.dBConnect);
            var sp = new Store() { ID = -4 };
            dB.Update(sp);
        }
    }
}
