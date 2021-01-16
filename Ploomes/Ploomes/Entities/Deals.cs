namespace Ploomes.Entities
{
    class Deals
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ContactId { get; set; }
        public int Amount { get; set; }
        public int StageId { get; set; }
        public Deals()
        {

        }
    }
}