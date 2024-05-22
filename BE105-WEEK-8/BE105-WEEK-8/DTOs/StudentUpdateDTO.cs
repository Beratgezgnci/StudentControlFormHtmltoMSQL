namespace BE105_WEEK_8.DTOs
{
    public class StudentUpdateDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int StudentNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
