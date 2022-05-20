using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using Spark.Core.Models;

namespace Spark.DataAccessLayer.Seed
{
    public class AnswerSeed : IEntityTypeConfiguration<Answer>
    {
        private readonly Guid[] _guids;

        public AnswerSeed(Guid[] guids)
        {
            _guids = guids;
        }

        public void Configure(EntityTypeBuilder<Answer> builder)
        {

            builder.HasData(
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 0.1",
                    QuestionId = _guids[0]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 0.2",
                    QuestionId = _guids[0]
                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 0.3",
                    QuestionId = _guids[0]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 0.4",
                    QuestionId = _guids[0]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 1.1",
                    QuestionId = _guids[1]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 1.2",
                    QuestionId = _guids[1]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 1.3",
                    QuestionId = _guids[1]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 1.4",
                    QuestionId = _guids[1]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 2.1",
                    QuestionId = _guids[2]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 2.2",
                    QuestionId = _guids[2]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 2.3",
                    QuestionId = _guids[2]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 2.4",
                    QuestionId = _guids[2]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 3.1",
                    QuestionId = _guids[3]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 3.2",
                    QuestionId = _guids[3]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 3.3",
                    QuestionId = _guids[3]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 3.4",
                    QuestionId = _guids[3]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 4.1",
                    QuestionId = _guids[4]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 4.2",
                    QuestionId = _guids[4]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 4.3",
                    QuestionId = _guids[4]

                }, 
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 4.4",
                    QuestionId = _guids[4]

                }, 
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 4.5",
                    QuestionId = _guids[4]

                },
                new Answer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = "Answer 4.6",
                    QuestionId = _guids[4]

                }
            );
        }

    }
}
