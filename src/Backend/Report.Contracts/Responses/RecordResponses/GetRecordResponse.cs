namespace Report.Contracts.Responses.RecordResponses
{
    public record GetRecordResponse(long RecordId, string Name, string Description);
}