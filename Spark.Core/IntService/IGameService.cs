﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.Models;

namespace Spark.Core.IntService
{
    public interface IGameService
    {
        Task<IEnumerable<Question>> GetAllWithAnswersAsync();
        Task<IEnumerable<Question>> GetAllQuestions();
        Task<Question> GetWithAnswersByIdAsync(Guid qId);

        Task<List<Answer>> GetFakeAnswers(Guid questId, Guid userId);
    }
}
