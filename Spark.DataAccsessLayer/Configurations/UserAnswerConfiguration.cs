using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spark.Core.Models;

namespace Spark.DataAccessLayer.Configurations
{
    public class UserAnswerConfiguration : IEntityTypeConfiguration<UserAnswer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserAnswer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.User).WithMany(p => p.UserAnswers).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.Answer).WithMany(p => p.UserAnswers).HasForeignKey(p => p.AnswerId);
            builder.ToTable("tblUserAnswer");

        }
    }
}
