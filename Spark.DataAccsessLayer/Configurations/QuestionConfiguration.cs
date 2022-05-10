using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spark.Core.Models;

namespace Spark.DataAccessLayer.Configurations
{
    public class QuestionConfiguration:IEntityTypeConfiguration<Question>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.QuestionBody).IsRequired().HasMaxLength(400);
            builder.ToTable("tblQuestions");
        }
    }
}
