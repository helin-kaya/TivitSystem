using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TivitSystemEL.Entities;
using TivitSystemEL.ViewModels;

namespace TivitSystemEL.Mappings
{
    public class Maps:Profile
    {
        public Maps()
        {
            CreateMap<UserTivit, UserTivitViewModel>().ReverseMap();
            CreateMap<UserTivitMedia, UserTivitMediaViewModel>().ReverseMap();
            CreateMap<TivitTags, TivitTagsViewModel>().ReverseMap();
        }
    }
}
