namespace Spark.API.DTOs
{
    public class LikeDto
    {
        public Guid UserId { get; set; }
        public Guid LikedUserId { get; set; }
        public bool IsMatch { get; set; }
        public bool IsWin { get; set; }
    }
}
