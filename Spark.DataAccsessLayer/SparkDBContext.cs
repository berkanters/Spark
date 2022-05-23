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
            Guid a1 = Guid.NewGuid();
            Guid a2 = Guid.NewGuid();
            Guid a3 = Guid.NewGuid();
            Guid a4 = Guid.NewGuid();
            Guid a5 = Guid.NewGuid();
            Guid a6 = Guid.NewGuid();
            Guid a7 = Guid.NewGuid();
            Guid a8 = Guid.NewGuid();
            Guid a9 = Guid.NewGuid();
            Guid a10 = Guid.NewGuid();
            Guid a11 = Guid.NewGuid();
            Guid a12 = Guid.NewGuid();
            Guid a13 = Guid.NewGuid();
            Guid a14 = Guid.NewGuid();
            Guid a15 = Guid.NewGuid();
            Guid a16 = Guid.NewGuid();
            Guid a17 = Guid.NewGuid();
            Guid a18 = Guid.NewGuid();
            Guid a19 = Guid.NewGuid();
            Guid a20 = Guid.NewGuid();
            Guid a21 = Guid.NewGuid();
            Guid a22 = Guid.NewGuid();
            Guid u1 = Guid.NewGuid();
            Guid u2 = Guid.NewGuid();
            Guid u3 = Guid.NewGuid();
            Guid u4 = Guid.NewGuid();
            Guid u5 = Guid.NewGuid();
            Guid u6 = Guid.NewGuid();
            Guid u7 = Guid.NewGuid();
            Guid u8 = Guid.NewGuid();
            Guid u9 = Guid.NewGuid();
            Guid u10 = Guid.NewGuid();
            Guid u11 = Guid.NewGuid();
            Guid u12 = Guid.NewGuid();
            Guid u13 = Guid.NewGuid();
            Guid u14 = Guid.NewGuid();
            Guid u15 = Guid.NewGuid();
            Guid u16 = Guid.NewGuid();
            Guid u17 = Guid.NewGuid();
            Guid u18 = Guid.NewGuid();
            Guid u19 = Guid.NewGuid();
            Guid u20 = Guid.NewGuid();
            Guid u21 = Guid.NewGuid();
            Guid u22 = Guid.NewGuid();
            Guid u23 = Guid.NewGuid();
            Guid u24 = Guid.NewGuid();
            Guid u25 = Guid.NewGuid();
            Guid u26 = Guid.NewGuid();
            Guid u27 = Guid.NewGuid();
            Guid u28 = Guid.NewGuid();
            Guid u29 = Guid.NewGuid();
            Guid u30 = Guid.NewGuid();
            Guid u31 = Guid.NewGuid();
            Guid u32 = Guid.NewGuid();
            Guid u33 = Guid.NewGuid();
            Guid u34 = Guid.NewGuid();
            Guid u35 = Guid.NewGuid();
            Guid u36 = Guid.NewGuid();
            Guid u37 = Guid.NewGuid();
            Guid u38 = Guid.NewGuid();
            Guid u39 = Guid.NewGuid();
            Guid u40 = Guid.NewGuid();




            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new UserAnswerConfiguration());

            modelBuilder.ApplyConfiguration(new QuestionSeed(new Guid[] { q1, q2, q3, q4, q5, q6, q7 ,q8,q9}));
            modelBuilder.ApplyConfiguration(new AnswerSeed(new Guid[] { q1, q2, q3, q4, q5, q6, q7, q8,q9}));
            //modelBuilder.ApplyConfiguration(new AnswerSeed(new Guid[] { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20, a21, a22 }));
            //modelBuilder.ApplyConfiguration(new UserAnswerSeed(new Guid[] { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20, a21, a22 }));
            //modelBuilder.ApplyConfiguration(new UserSeed(new Guid[] { u1, u2, u3, u4, u5, u6, u7, u8, u9, u10, u11, u12, u13, u14, u15, u16, u17, u18, u19, u20, u21, u22, u23, u24, u25, u26, u27, u28, u29, u30, u31, u32, u33, u34, u35, u36, u37, u38, u39, u40 }));
            //modelBuilder.ApplyConfiguration(new UserAnswerSeed(new Guid[] { u1, u2, u3, u4, u5, u6, u7, u8, u9, u10, u11, u12, u13, u14, u15, u16, u17, u18, u19, u20, u21, u22, u23, u24, u25, u26, u27, u28, u29, u30, u31, u32, u33, u34, u35, u36, u37, u38, u39, u40 }));






            modelBuilder.ApplyConfiguration(new UserSeed());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
