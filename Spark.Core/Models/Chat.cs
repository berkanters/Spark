using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Core.Models
{
    public class Chat
    {
        public Guid Id { get; set; }
        public Guid User1Id { get; set; }
        public Guid User2Id { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageDate { get; set; }

        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
    }
}
