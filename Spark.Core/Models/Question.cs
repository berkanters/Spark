using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Core.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string QuestionBody { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
