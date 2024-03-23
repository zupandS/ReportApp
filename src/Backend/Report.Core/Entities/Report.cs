namespace Report.Core.Entities
{
    public class Record : BaseEntity<long>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid UserId { get; set; }
        
        public User User { get; set; }
    }
}