using MockServiceApi.Data;
using MockServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockServiceApi.Repositories
{
    public class MockResponseRepository : IMockResponseRepository
    {
        private readonly DataContext _context;

        public MockResponseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateItemAsync(MockResponse item)
        {
            await _context.MockResponses.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public Task DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<MockResponse> GetItemAsync(Guid id)
        {
            var item = _context.MockResponses.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task<IEnumerable<MockResponse>> GetItemsAsync()
        {
            return await Task.FromResult(_context.MockResponses.ToList());
        }

        public async Task UpdateItemAsync(MockResponse item)
        {
            await Task.FromResult(_context.MockResponses.Update(item));
            await _context.SaveChangesAsync();
        }
    }
}
