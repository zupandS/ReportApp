namespace Report.Application.Interfaces
{
    public interface IPasswordHashService
    {
        string HashPassword(string password);

        bool IsCorrect(string password, string HashPassword);
    }
}