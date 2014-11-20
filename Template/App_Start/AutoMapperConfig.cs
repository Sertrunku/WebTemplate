using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Mappings;

namespace Template
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMapping>();
                x.AddProfile<ViewModelToDomainMapping>();
            });
        }
    }
}