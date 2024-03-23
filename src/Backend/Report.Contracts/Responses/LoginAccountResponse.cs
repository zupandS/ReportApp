namespace Report.Contracts.Responses
{
    public record LoginAccountResponse(Guid UserId, string RefreshToken, string AccessToken);
}