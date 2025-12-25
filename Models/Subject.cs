namespace StudentManagement.Models
{
    public class Subject
    {
        public string SubjectID { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
        public int Credits { get; set; }

        public Subject() { }

        public Subject(string id, string name, int credits)
        {
            SubjectID = id;
            SubjectName = name;
            Credits = credits;
        }

        public override string ToString()
        {
            return $"{SubjectID} - {SubjectName} ({Credits} tín chỉ)";
        }
    }
}

