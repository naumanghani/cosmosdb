using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SampleCmdQueries
{
    public class DataDto: IMapFrom<Item>
    {
        public string Id { get; set; }
        public string PartitionKey { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Item, DataDto>();
                //.ForMember(dest=> dest.Id, src=> src.MapFrom(s=> s.Id * 2));
        }
    }
}
