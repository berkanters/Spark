using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Core.Models
{
    public class Like
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid LikedUserId { get; set; }
        public bool IsMatch { get; set; } = false;
        public bool IsWin { get; set; } = false;

        public virtual User User { get; set; }
        public virtual User LikedUser { get; set; }
        


    }
}
