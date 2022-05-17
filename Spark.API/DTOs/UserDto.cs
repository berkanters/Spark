namespace Spark.API.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public short Age { get; set; }
        public String Gender { get; set; }
        public String Phone { get; set; }
    }
}
