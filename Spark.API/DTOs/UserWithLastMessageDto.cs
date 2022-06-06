namespace Spark.API.DTOs
{
    public class UserWithLastMessageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        //public string Email { get; set; }
        public int Age { get; set; }
        //public string Gender { get; set; }
        //public string Phone { get; set; }
        //public double Latitude { get; set; }
        //public double Longitude { get; set; }
        public string LastMessage { get; set; }
    }
}
