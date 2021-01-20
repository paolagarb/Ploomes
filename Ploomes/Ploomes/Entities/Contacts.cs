namespace Ploomes.Entities
{
    public class Contacts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Neighborhoood  { get; set; }
        public int ZipCode { get; set; }
        public int OriginId { get; set; }
        public int CompanyId { get; set; }
        public string StreetAddressNumber { get; set; }
        public int TypeId { get; set; }
        public Phones Phones { get; set; }
        public Contacts()
        {

        }
    }
}
