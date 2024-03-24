namespace Report.Contracts.Requests.RecordRequest
{
    public record UpdateRecordRequest(long RecordId, string Name, string Description);
}