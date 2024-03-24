using Microsoft.EntityFrameworkCore;
using Report.Core.Entities;
using Report.Core.Interfaces.Repositories;

namespace Report.Infrastructure.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private readonly DataContext _dataContext;

        public RecordRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Record> AddRecordAsync(Record record)
        {
            _dataContext.Records.Add(record);

            await _dataContext.SaveChangesAsync();

            return record;
        }

        public async Task<Record> DeleteRecordAsync(Record record)
        {
            _dataContext.Records.Remove(record);

            await _dataContext.SaveChangesAsync();

            return record;
        }

        public async Task<Record> GetRecordAsync(long recordId)
        {
            var record = await _dataContext.Records.AsNoTracking().FirstOrDefaultAsync(r => r.Id == recordId);

            return record;
        }

        public async Task<IEnumerable<Record>> GetRecordsAsync(Guid userId)
        {
            var user = await _dataContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);

            return user.Records;
        }

        public async Task<Record> UpdateRecordAsync(Record record)
        {
            _dataContext.Records.Update(record);

            await _dataContext.SaveChangesAsync();

            return record;
        }

    }
}