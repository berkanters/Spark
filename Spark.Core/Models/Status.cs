using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Core.Models
{
    public class Status
    {
        public Guid Id { get; set; }
        public Guid LikeOwnerId { get; set; }
        public Guid LikeTargetId { get; set; }
        public bool IsMatch { get; set; }
        public bool IsWin { get; set; }
        public virtual User LikeOwner { get; set; }
        public virtual User LikeTarget { get; set; }
    }
}
