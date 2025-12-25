namespace StudentManagement.Models
{
    public class Score
    {
        public string StudentID { get; set; } = string.Empty;
        public string SubjectID { get; set; } = string.Empty;
        public double ProcessScore { get; set; } // Điểm thành phần
        public double FinalScore { get; set; } // Điểm thi
        public double TotalScore { get; set; } // Điểm tổng kết
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        public Student? Student { get; set; }
        public Subject? Subject { get; set; }

        public Score() 
        {
            CreatedDate = DateTime.Now;
        }

        public Score(string studentId, string subjectId, double processScore, double finalScore)
        {
            StudentID = studentId;
            SubjectID = subjectId;
            ProcessScore = processScore;
            FinalScore = finalScore;
            CalculateTotalScore();
            CreatedDate = DateTime.Now;
        }

        public void CalculateTotalScore()
        {
            // Công thức: Điểm TP * 0.3 + Điểm Thi * 0.7
            TotalScore = Math.Round(ProcessScore * 0.3 + FinalScore * 0.7, 2);
        }

        public string GetGrade()
        {
            if (TotalScore >= 8.5) return "A";
            if (TotalScore >= 8.0) return "B+";
            if (TotalScore >= 7.0) return "B";
            if (TotalScore >= 6.5) return "C+";
            if (TotalScore >= 5.5) return "C";
            if (TotalScore >= 5.0) return "D+";
            if (TotalScore >= 4.0) return "D";
            return "F";
        }

        public bool IsPassed()
        {
            return TotalScore >= 5.0;
        }
    }
}

