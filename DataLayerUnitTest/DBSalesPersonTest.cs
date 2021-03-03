using System.Linq;
using DataLayer;
using DataLayer.DAO;
using DataLayer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataLayerUnitTest
{
    [TestClass]
    public class DBSalesPersonTest
    {

        private readonly DBConnect dBConnect = new DBConnect();


        [TestMethod]
        public void AddRemoveEntityTest()
        {
            DBSalesPerson dB = new DBSalesPerson(this.dBConnect);

            var sp = new SalesPerson() { Name = "Johnny", Surname = "Test" };

            var ppl = dB.GetAll();
            var oldCount = ppl.Count();

            dB.Create(sp);
            Assert.IsTrue(dB.GetAll().Count() > oldCount, "Salesperson not created");

            ppl = dB.GetAll();
            sp = ppl.Last();

            dB.Delete(sp.ID);

            Assert.IsTrue(dB.GetAll().Count() == oldCount, "Salesperson not removed");
        }


        [TestMethod]
        public void GetAllTest()
        {
            DBSalesPerson dB = new DBSalesPerson(this.dBConnect);
            var ppl = dB.GetAll();

            Assert.IsNotNull(ppl, "Null object returned");
            Assert.IsTrue(ppl.Count() > 0, "There are no salesmen");
        }


        [TestMethod]
        public void UpdateGetEntityTest()
        {
            DBSalesPerson dB = new DBSalesPerson(this.dBConnect);

            var sp = dB.Get(1);
            Assert.IsNotNull(sp, "Salesperson not retieved");

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
            DBSalesPerson dB = new DBSalesPerson(this.dBConnect);
            dB.Create(new SalesPerson()
            {
                Name = null,
                Surname = "Smith"
            });
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalDataArgumentException))]
        public void RemoveIllegalNegativeTest()
        {
            DBSalesPerson dB = new DBSalesPerson(this.dBConnect);
            dB.Delete(-1);
        }


        [TestMethod]
        [ExpectedException(typeof(IllegalDataArgumentException))]
        public void UpdateIllegalNegativeTest()
        {
            DBSalesPerson dB = new DBSalesPerson(this.dBConnect);
            var sp = new SalesPerson() { ID = -4 };
            dB.Update(sp);
        }
    }
}
