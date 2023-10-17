using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TivitSystemDL.ContextInfo;
using TivitSystemDL.InterfaceofRepos;
using TivitSystemEL.Entities;

namespace TivitSystemDL.ImplementationofRepos
{
    public class UserTivitRepo:Repository<UserTivit,int>,IUserTivitRepo
    {
        public UserTivitRepo(MyContext context) : base(context)
        {

        }
    }
}
