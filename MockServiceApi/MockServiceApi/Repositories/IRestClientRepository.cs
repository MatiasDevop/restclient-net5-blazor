using MockServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockServiceApi.Repositories
{
    public interface IRestClientRepository
    {
        Task<RestClient> GetItemAsync(Guid id);
        Task<IEnumerable<RestClient>> GetItemsAsync();

        Task CreateItemAsync(RestClient item);
        Task UpdateItemAsync(RestClient item);

        Task DeleteItemAsync(Guid id);
    }
}
