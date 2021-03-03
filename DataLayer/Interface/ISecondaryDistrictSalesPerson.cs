using System.Collections.Generic;
using DataLayer.Model;

namespace DataLayer.Interface
{
    public interface ISecondaryDistrictSalesPerson
    {
        void AddSecondary(int DistrictID, int SalesPersonID);
        void RemoveSecondary(int DistrictID, int SalesPersonID);
        IEnumerable<SalesPerson> GetPossibleSecondary(int DistrictID);
    }
}
