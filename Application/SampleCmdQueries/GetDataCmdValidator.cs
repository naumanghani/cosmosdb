using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SampleCmdQueries
{
    public class GetDataCmdValidator: AbstractValidator<GetDataCmd>
    {
        public GetDataCmdValidator()
        {
            RuleFor(v => v.Id)
             .MinimumLength(1);
        }
    }
}
