namespace StudentManagement.Models
{
    public class Classroom
    {
        public string ClassID { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public List<Student> Students { get; set; } = new List<Student>();

        public Classroom() { }

        public Classroom(string id, string name, string department)
        {
            ClassID = id;
            ClassName = name;
            Department = department;
        }

        public override string ToString()
        {
            return $"{ClassID} - {ClassName}";
        }
    }
}

