using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TivitSystemBL.InterfacesOfManagers;
using TivitSystemDL.InterfaceofRepos;
using TivitSystemEL.Entities;
using TivitSystemEL.ViewModels;

namespace TivitSystemBL.ImplementationOfManagers
{
    public class TivitTagsManager:Manager<TivitTagsViewModel,TivitTags,int>,ITivitTagsManager
    {
        public TivitTagsManager(ITivitTagsRepo repo, IMapper mapper) : base(repo, mapper, new string[] { "UserTivit" })
        {

        }
    }
}
