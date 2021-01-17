using System;

namespace Ploomes.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public int ContactId { get; set; }
        public Tasks()
        {
                
        }
    }
}
