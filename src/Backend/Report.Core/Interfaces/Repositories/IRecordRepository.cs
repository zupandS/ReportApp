using Report.Core.Entities;

namespace Report.Core.Interfaces.Repositories
{
    public interface IRecordRepository
    {
        Task<Record> AddRecordAsync(Record record);

        Task<Record> UpdateRecordAsync(Record record);

        Task<Record> DeleteRecordAsync(Record record);

        Task<Record> GetRecordAsync(long recordId);

        Task<IEnumerable<Record>> GetRecordsAsync(Guid userId);
    }
}