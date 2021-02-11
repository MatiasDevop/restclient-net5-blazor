using Microsoft.EntityFrameworkCore;
using MockServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockServiceApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<RestClient> RestClients { get; set; }
        public DbSet<MockResponse> MockResponses { get; set; }
    }
}
