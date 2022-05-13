using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spark.Core.Models;
using Spark.DataAccessLayer.Configurations;
using Spark.DataAccessLayer.Seed;

namespace Spark.DataAccessLayer
{
    public class SparkDBContext : DbContext
    {
        public SparkDBContext(DbContextOptions<SparkDBContext> options) : base(options)
        {

        }

        DbSet<User> Users { get; set; }
        DbSet<Like> Likes { get; set; }
        DbSet<Answer> Answers { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<UserAnswer> UserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
     

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new UserAnswerConfiguration());





            modelBuilder.ApplyConfiguration(new UserSeed());
        }
    }
}
