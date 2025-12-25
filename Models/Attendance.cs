namespace StudentManagement.Models
{
    public class Attendance
    {
        public string StudentID { get; set; } = string.Empty;
        public string SubjectID { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Status { get; set; } = string.Empty; // "Present", "Absent", "Late", "Excused"
        public string? Note { get; set; }

        public Student? Student { get; set; }
        public Subject? Subject { get; set; }

        public Attendance() { }

        public Attendance(string studentId, string subjectId, DateTime date, string status)
        {
            StudentID = studentId;
            SubjectID = subjectId;
            Date = date;
            Status = status;
        }

        public bool IsAbsent()
        {
            return Status == "Absent" || Status == "Late";
        }
    }
}

