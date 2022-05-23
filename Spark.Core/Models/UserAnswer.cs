using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Core.Models
{
    public class UserAnswer
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid AnswerId { get; set; }
        public Guid QuestionId { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual Question Question { get; set; }
    }
}
