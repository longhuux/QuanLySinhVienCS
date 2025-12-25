namespace StudentManagement.Models
{
    public class Student
    {
        public string StudentID { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ClassID { get; set; } = string.Empty;
        public Classroom? Classroom { get; set; }

        public Student() { }

        public Student(string id, string name, DateTime dob, string gender, string email, string classId)
        {
            StudentID = id;
            FullName = name;
            DateOfBirth = dob;
            Gender = gender;
            Email = email;
            ClassID = classId;
        }

        public override string ToString()
        {
            return $"{StudentID} - {FullName}";
        }

        public int Age => DateTime.Now.Year - DateOfBirth.Year - 
            (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);
    }
}

