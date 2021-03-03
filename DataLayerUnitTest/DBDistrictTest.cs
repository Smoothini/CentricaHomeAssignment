using System.Linq;
using DataLayer;
using DataLayer.DAO;
using DataLayer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataLayerUnitTest
{
    [TestClass]
    public class DBDistrictTest : IDBUnitTests
    {
        private readonly DBConnect dBConnect = new DBConnect();

        [TestMethod]
        public void AddRemoveEntityTest()
        {

            DBDistrict dB = new DBDistrict(this.dBConnect);
            var sp = new District()
            {
                Name = "Netto",
                PSPID = 1
            };


            var stores = dB.GetAll();
            var oldCount = stores.Count();

            dB.Create(sp);
            Assert.IsTrue(dB.GetAll().Count() > oldCount, "District not created");

            stores = dB.GetAll();
            sp = stores.Last();

            dB.Delete(sp.ID);

            Assert.IsTrue(dB.GetAll().Count() == oldCount, "District not removed");
        }

        [TestMethod]
        public void GetAllTest()
        {
            DBDistrict dB = new DBDistrict(this.dBConnect);
            var ppl = dB.GetAll();

            Assert.IsNotNull(ppl, "Null object returned");
            Assert.IsTrue(ppl.Count() > 0, "There are no stores");
        }

        [TestMethod]
        public void UpdateEntityTest()
        {
            DBDistrict dB = new DBDistrict(this.dBConnect);

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
        [ExpectedException(typeof(DataLayer.IllegalDataArgumentException))]
        public void AddIllegalTest()
        {
            DBDistrict dB = new DBDistrict(this.dBConnect);
            dB.Create(new District()
            {
                Name = null
            });
        }

        [TestMethod]
        [ExpectedException(typeof(DataLayer.IllegalDataArgumentException))]
        public void RemoveIllegalTest()
        {
            DBDistrict dB = new DBDistrict(this.dBConnect);
            dB.Delete(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(DataLayer.IllegalDataArgumentException))]
        public void UpdateIllegalTest()
        {
            DBDistrict dB = new DBDistrict(this.dBConnect);
            var sp = new District() { ID = -4 };
            dB.Update(sp);
        }

    }
}
