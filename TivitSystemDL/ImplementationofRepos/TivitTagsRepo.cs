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
    public class TivitTagsRepo:Repository<TivitTags,int>,ITivitTagsRepo
    {
        public TivitTagsRepo(MyContext context) : base(context)
        {

        }
    }
}
