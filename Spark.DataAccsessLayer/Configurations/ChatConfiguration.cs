using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spark.Core.Models;

namespace Spark.DataAccessLayer.Configurations
{
    public class ChatConfiguration:IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(x => x.User1).WithMany(x => x.User1Chats).HasForeignKey(x => x.User1Id).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.User2).WithMany(x => x.User2Chats).HasForeignKey(x => x.User2Id).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x=>x.MessageText).HasMaxLength(500);
            builder.Property(x => x.MessageDate).IsRequired();
            builder.ToTable("tblChatLog");
        }
    }
}
