namespace Report.Contracts.Requests
{
    public record RefreshRequest(string RefreshToken, string AccessToken);
}