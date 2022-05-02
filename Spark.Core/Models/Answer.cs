using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Core.Models
{
    internal class Answer
    {
        public Guid Id { get; set; }
        public string AnswerText { get; set; }

        public Guid QuestionId { get; set; }

        public virtual Question Question { get; set; }

    }
}
