using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spark.Core.Models;

namespace Spark.DataAccessLayer.Seed
{
    public class QuestionSeed : IEntityTypeConfiguration<Question>
    {
        private readonly Guid[] _guids;

        public QuestionSeed(Guid[] guids)
        {
            _guids = guids;
        }

        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasData(
               new Question
               {
                   Id = _guids[0],
                   QuestionBody = "What is your favorite color?",
                   
               },
               new Question
               {
                   Id = _guids[1],
                   QuestionBody = "What is your favorite animal?",
                   
               },
               new Question
               {
                   Id = _guids[2],
                   QuestionBody = "What is your favorite food?",
                   
               },
               new Question
               {
                   Id = _guids[3],
                   QuestionBody = "What is your favorite sport?",
                   
               },
               new Question
               {
                   Id = _guids[4],
                   QuestionBody = "What is your favorite movie?",
                   
               },
               new Question
               {
                   Id = _guids[5],
                   QuestionBody = "What is your favorite book?",
                   
               },
               new Question
               {
                   Id = _guids[6],
                   QuestionBody = "What is your favorite TV show?",
                   
               },
               new Question
               {
                   Id = _guids[7],
                   QuestionBody = "What is your favorite movie?",
                   
               },
               new Question
               {
                   Id = _guids[8],
                   QuestionBody = "What is your favorite book?",
                   
               }

           );
        }
    }
}
