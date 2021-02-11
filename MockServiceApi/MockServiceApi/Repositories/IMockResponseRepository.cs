using MockServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockServiceApi.Repositories
{
    public interface IMockResponseRepository
    {
        Task<MockResponse> GetItemAsync(Guid id);
        Task<IEnumerable<MockResponse>> GetItemsAsync();

        Task CreateItemAsync(MockResponse item);
        Task UpdateItemAsync(MockResponse item);

        Task DeleteItemAsync(Guid id);
    }
}
