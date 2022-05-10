using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spark.Core.Models;

namespace Spark.DataAccessLayer.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Status> builder)
        {
            
            builder.HasKey(s => s.Id);
            builder.HasOne(x => x.LikeOwner).WithMany(x => x.LikeOwners).HasForeignKey(x => x.LikeOwnerId);
            builder.HasOne(x => x.LikeTarget).WithMany(x => x.LikeTargets).HasForeignKey(x => x.LikeTargetId);
            builder.ToTable("tblStatus");
        }
    }
}
