using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Persistence.Configurations
{
    internal class MyUserConfiguration : IEntityTypeConfiguration<MyUser>
    {
        public void Configure(EntityTypeBuilder<MyUser> builder)
        {
            
        }
    }
}
