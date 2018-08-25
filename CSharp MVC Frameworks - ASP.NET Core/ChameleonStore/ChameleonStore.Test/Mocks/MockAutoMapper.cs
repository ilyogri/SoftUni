using AutoMapper;
using ChameleonStore.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChameleonStore.Test.Mocks
{
    public static class MockAutoMapper
    {
        static MockAutoMapper()
        {
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
        }

        public static IMapper GetAutoMapper() => Mapper.Instance;
    }
}
