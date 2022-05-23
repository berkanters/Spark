namespace Spark.API.DTOs
{
    public class ChatDto
    { 
        public Guid User1Id { get; set; }
        public Guid User2Id { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
