namespace StudentRegistration.Data.Entities
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredOn { get; set; }
    }
}
