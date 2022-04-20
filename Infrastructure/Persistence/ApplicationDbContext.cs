using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public async Task<Entry> GetEntry(int Id)
        {
            return new Entry() { Id = Id * 5 };
        }

        public Task<List<Item>> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
