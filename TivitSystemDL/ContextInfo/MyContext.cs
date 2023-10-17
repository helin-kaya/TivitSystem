using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TivitSystemEL.Entities;
using TivitSystemEL.IdentityModels;

namespace TivitSystemDL.ContextInfo
{
    public class MyContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public MyContext(DbContextOptions<MyContext> opt)
            : base(opt)
        {

        }
        public virtual DbSet<TivitTags> TivitTagsTable { get; set; }
        public virtual DbSet<UserTivit> UserTivitTable { get; set; }
        public virtual DbSet<UserTivitMedia> UserTivitMediaTable { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserTivitMedia>(x =>
            {
                x.ToTable("USERTIVITMEDIA");
            });
            

           
        }
    }
}
