using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SampleCmdQueries
{
    public class GetDataCmd: IRequest<DataDto>
    {
        public string Id { get; set; }

    }

    public class GetDataCmdHandler : IRequestHandler<GetDataCmd,DataDto>
    {
        private readonly ICosmosDbService _cosmosDbService;

        public GetDataCmdHandler(IApplicationDbContext applicationDbContext, ICosmosDbService cosmosDbService, IMapper mapper)
        {
            //_applicationDbContext = applicationDbContext;            
            _mapper = mapper;

            _cosmosDbService = cosmosDbService ?? throw new ArgumentNullException(nameof(cosmosDbService));
        }
    

        //public IApplicationDbContext _applicationDbContext { get; }

        public IMapper _mapper { get; }

        public async Task<DataDto> Handle(GetDataCmd request, CancellationToken cancellationToken)
        {

            string qry = $"select * from c Where c.id = '8939e64b-b540-43ca-a37d-8a23fe889969'";
            //IEnumerable<Item> entity = await _cosmosDbService.GetMultipleAsync(qry);


            
            //IEnumerable<Item> entities = await _cosmosDbService.GetMultipleAsync(qry);
            //if (entities == null)

            //    throw new NotFoundException($"Entity with Id {request.Id} Not Found");
            //Item entity = entities.FirstOrDefault();
            //return _mapper.Map<DataDto>(entity);



            Item entity = await _cosmosDbService.GetAsync("8939e64b-b540-43ca-a37d-8a23fe889969", "903478e9-5598-401e-ad51-356276b1bef7");
            if (entity == null)
                throw new NotFoundException($"Entity with Id {request.Id} Not Found");
            return _mapper.Map<DataDto>(entity);
        }
    }
}
