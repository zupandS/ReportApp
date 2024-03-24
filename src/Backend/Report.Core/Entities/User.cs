namespace Report.Core.Entities
{
    public class User : BaseEntity<Guid>
    {
        public string Login { get; set; }
        
        public string PasswordHash { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenLifeTime { get; set; }
        
        public ICollection<Record> Records { get; set; }
    }
}