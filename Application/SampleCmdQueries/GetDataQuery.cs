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
    public class GetDataQuery: IRequest<List<DataDto>>
    {

    }

    public class GetDataQueryHandler : IRequestHandler<GetDataQuery, List<DataDto>>
    {
        private readonly ICosmosDbService _cosmosDbService;

        public GetDataQueryHandler(IApplicationDbContext applicationDbContext, ICosmosDbService cosmosDbService, IMapper mapper)
        {
    
            _mapper = mapper;
            _cosmosDbService = cosmosDbService ?? throw new ArgumentNullException(nameof(cosmosDbService));
        }
    



        public IMapper _mapper { get; }

        public async Task<List<DataDto>> Handle(GetDataQuery request, CancellationToken cancellationToken)
        {

            string qry = $"select * from c ";
            //IEnumerable<Item> entity = await _cosmosDbService.GetMultipleAsync(qry);



            IEnumerable<Item> entities = await _cosmosDbService.GetMultipleAsync(qry);
            if (entities == null)
                return new List<DataDto>();
            

            return _mapper.Map<List<DataDto>>(entities);



        }
    }
}
