using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spark.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Spark.DataAccessLayer.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.Users).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.LikedUser).WithMany(x => x.LikedUsers).HasForeignKey(x => x.LikedUserId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("tblLike");

        }
    }
}
