using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spark.Core.Models;

namespace Spark.DataAccessLayer.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.Users).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.LikedUser).WithMany(x => x.LikedUsers).HasForeignKey(x => x.LikedUserId);
            builder.ToTable("tblLike");

        }
    }
}
