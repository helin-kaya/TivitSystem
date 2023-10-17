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
    public class UserTivitMediaManager : Manager<UserTivitMediaViewModel, UserTivitMedia, int>, IUserTivitMediaManager
    {
        public UserTivitMediaManager(IUserTivitMediaRepo repo, IMapper mapper) : base(repo, mapper, new string[] { "UserTivit" })
        {

        }
    }
}
