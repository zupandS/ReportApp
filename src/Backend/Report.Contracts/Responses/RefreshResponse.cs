namespace Report.Contracts.Responses
{
    public record RefreshResponse(Guid UserId, string RefreshToken, string AccessToken);
}