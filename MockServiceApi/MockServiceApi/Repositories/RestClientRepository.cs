using MockServiceApi.Data;
using MockServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockServiceApi.Repositories
{
    public class RestClientRepository : IRestClientRepository
    {
        private readonly DataContext _context;

        public RestClientRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateItemAsync(RestClient item)
        {
            await _context.RestClients.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public Task DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<RestClient> GetItemAsync(Guid id)
        {
            var item = _context.RestClients.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task<IEnumerable<RestClient>> GetItemsAsync()
        {
            return await Task.FromResult(_context.RestClients);
        }

        public async Task UpdateItemAsync(RestClient item)
        {
            await Task.FromResult(_context.RestClients.Update(item));
            await _context.SaveChangesAsync();
        }
    }
}
