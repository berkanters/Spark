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

        public DbSet<User> Users { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid q1 = Guid.NewGuid();
            Guid q2 = Guid.NewGuid();
            Guid q3 = Guid.NewGuid();
            Guid q4 = Guid.NewGuid();
            Guid q5 = Guid.NewGuid();
            Guid q6 = Guid.NewGuid();
            Guid q7 = Guid.NewGuid();
            Guid q8 = Guid.NewGuid();
            Guid q9 = Guid.NewGuid();


            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new UserAnswerConfiguration());

            modelBuilder.ApplyConfiguration(new QuestionSeed(new Guid[] { q1, q2, q3, q4, q5, q6, q7 ,q8,q9}));
            modelBuilder.ApplyConfiguration(new AnswerSeed(new Guid[] { q1, q2, q3, q4, q5, q6, q7, q8,q9}));





            modelBuilder.ApplyConfiguration(new UserSeed());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
