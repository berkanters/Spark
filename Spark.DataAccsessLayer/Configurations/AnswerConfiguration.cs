using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Spark.Core.Models;

namespace Spark.DataAccessLayer.Configurations
{
    public class AnswerConfiguration: IEntityTypeConfiguration<Answer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(s => s.QuestionId).IsRequired();
            builder.Property(x => x.AnswerText).IsRequired().HasMaxLength(50);
            builder.HasOne(x => x.Question).WithMany(q => q.Answers).HasForeignKey(x => x.QuestionId);
            builder.ToTable("tblAnswers");
        }
}
