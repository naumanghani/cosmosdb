using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SampleCmdQueries
{
    public class SaveDataCmd: IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsComplete { get; set; }
    }

    public class SaveDataCmdHandler: IRequestHandler<SaveDataCmd, bool>
    {
        public SaveDataCmdHandler(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        public ICosmosDbService _cosmosDbService { get; }


        public async Task<bool> Handle(SaveDataCmd request, CancellationToken cancellationToken)
        {
            await _cosmosDbService.AddAsync(new Item() { PartitionKey = Guid.NewGuid().ToString(), Id = Guid.NewGuid().ToString(), Completed = true, Description = "Second", Name = "Saved Item" });
            return true;
        }
    }
}
