using System.Runtime.Serialization;

namespace DataLayer.Model
{
    [DataContract]
    public class Store
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Info { get; set; }
        [DataMember]
        public int DistrictID { get; set; }
    }
}
