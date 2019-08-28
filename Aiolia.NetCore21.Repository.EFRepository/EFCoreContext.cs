using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Aiolia.NetCore21.Domain;

namespace Aiolia.NetCore21.Repository.EFRepository
{
    public class EFCoreContext : DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }

        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {

        }

        public override int SaveChanges()
        {
            BeforeSavingChanges();
            return base.SaveChanges();
        }


        void BeforeSavingChanges()
        {
            var entities = this.ChangeTracker
            .Entries();
            

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Unchanged|| entity.State == EntityState.Detached)
                    continue;
                
                if (entity.State == EntityState.Added)
                {
                    BaseEntity be = entity.Entity as BaseEntity;

                    be.CreateDate = DateTime.Now;
                    be.CreateUser = "";
                }
                if (entity.State == EntityState.Modified)
                {
                    BaseEntity be = entity.Entity as BaseEntity;
                    be.LastUpdateDate = DateTime.Now;
                    be.LastUpdateUser = "";
                }
            }

        }
    }
    
}
