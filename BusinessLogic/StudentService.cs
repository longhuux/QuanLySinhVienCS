using StudentManagement.Models;
using StudentManagement.DataAccess;

namespace StudentManagement.BusinessLogic
{
    public class StudentService
    {
        private DataRepository _repository;

        public StudentService()
        {
            _repository = DataRepository.Instance;
        }

        public double CalculateGPA(string studentId)
        {
            var scores = _repository.Scores.Where(s => s.StudentID == studentId).ToList();
            if (scores.Count == 0) return 0;

            double totalPoints = 0;
            int totalCredits = 0;

            foreach (var score in scores)
            {
                var subject = _repository.Subjects.FirstOrDefault(s => s.SubjectID == score.SubjectID);
                if (subject != null)
                {
                    totalPoints += score.TotalScore * subject.Credits;
                    totalCredits += subject.Credits;
                }
            }

            return totalCredits > 0 ? Math.Round(totalPoints / totalCredits, 2) : 0;
        }

        public bool CheckEligibility(string studentId)
        {
            var gpa = CalculateGPA(studentId);
            return gpa >= 5.0;
        }

        public double GetAttendanceRate(string studentId, string subjectId)
        {
            var attendances = _repository.Attendances
                .Where(a => a.StudentID == studentId && a.SubjectID == subjectId)
                .ToList();

            if (attendances.Count == 0) return 0;

            int presentCount = attendances.Count(a => a.Status == "Present");
            return Math.Round((double)presentCount / attendances.Count * 100, 2);
        }

        public bool HasLowAttendance(string studentId, string subjectId, double threshold = 80)
        {
            return GetAttendanceRate(studentId, subjectId) < threshold;
        }

        public List<Student> GetStudentsWithLowGPA(double threshold = 5.0)
        {
            var result = new List<Student>();
            foreach (var student in _repository.Students)
            {
                var gpa = CalculateGPA(student.StudentID);
                if (gpa < threshold)
                {
                    result.Add(student);
                }
            }
            return result;
        }

        public List<Student> GetStudentsWithLowAttendance(double threshold = 80)
        {
            var result = new List<Student>();
            foreach (var student in _repository.Students)
            {
                foreach (var subject in _repository.Subjects)
                {
                    if (HasLowAttendance(student.StudentID, subject.SubjectID, threshold))
                    {
                        if (!result.Contains(student))
                        {
                            result.Add(student);
                        }
                    }
                }
            }
            return result;
        }

        public Dictionary<string, int> GetGenderStatistics()
        {
            return _repository.Students
                .GroupBy(s => s.Gender)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public Dictionary<string, int> GetClassStatistics()
        {
            return _repository.Students
                .GroupBy(s => s.ClassID)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public int GetTotalStudents()
        {
            return _repository.Students.Count;
        }

        public int GetStudentsWithDebt()
        {
            return GetStudentsWithLowGPA(5.0).Count;
        }

        public double GetAverageAttendanceRate()
        {
            if (_repository.Attendances.Count == 0) return 0;

            int presentCount = _repository.Attendances.Count(a => a.Status == "Present");
            return Math.Round((double)presentCount / _repository.Attendances.Count * 100, 2);
        }
    }
}

