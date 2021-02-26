using System.Collections.Generic;
using System.Runtime.Serialization;
using DataLayer.Model;

namespace DataLayer.Model
{
    [DataContract]
    public class District
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public SalesPerson PrimarySalesPerson { get; set; }
        [DataMember]
        public IEnumerable<SalesPerson> SecondarySalesPersons { get; set; }
    }
}
