namespace API.Dto
{
    /// <summary>
    /// Store Data Transfer Object
    /// </summary>
    public class StoreDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int DistrictID { get; set; }

        public string DistrictName { get; set; }

    }
}
