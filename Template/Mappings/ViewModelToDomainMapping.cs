using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Core.Models;
using Template.ViewModels;

namespace Template.Mappings
{
    public class ViewModelToDomainMapping : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            base.Configure();
            Mapper.CreateMap<DummyItemViewModel, DummyItem>();
        } 
    }
}