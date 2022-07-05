using CoreIMS.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreIMS.Application.EnumQueries
{
    /// <summary>
    /// Represent the query to lookup all enums
    /// </summary>
    public class LookupEnumsQuery : IRequest<Dictionary<EnumModelName, IEnumerable<EnumModel>>> { }


    /// <summary>
    /// The Lookup Enum Handler
    /// </summary>
    public class LookupEnumsQueryHandler : IRequestHandler<LookupEnumsQuery, Dictionary<EnumModelName, IEnumerable<EnumModel>>>
    {
        private readonly ILogger _logger;

        public LookupEnumsQueryHandler(ILogger<LookupEnumsQueryHandler> logger)
        {
            _logger = logger;
        }

        public async Task<Dictionary<EnumModelName, IEnumerable<EnumModel>>> Handle(LookupEnumsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Getting All Enums");
            Dictionary<EnumModelName, IEnumerable<EnumModel>> res = EnumModel.CreateEnumDictionary();

            return res;
        }
    }
}
