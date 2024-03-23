namespace Report.Core.Entities
{
    public class User : BaseEntity<Guid>
    {
        public string Login { get; set; }
        
        public string PasswordHash { get; set; }

        public ICollection<Record> Records { get; set; }
    }
}