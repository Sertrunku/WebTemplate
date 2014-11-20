using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Core.Models;
using Template.ViewModels;

namespace Template.Mappings
{
    public class DomainToViewModelMapping : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
        protected override void Configure()
        {
            base.Configure();
            Mapper.CreateMap<DummyItem, DummyItemViewModel>();
        }
    }
}