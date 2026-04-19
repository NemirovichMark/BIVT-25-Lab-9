using System;

namespace Lab9.Green
{
    public class Mark
    {
        public string StudentId { get; set; }
        public string SubjectId { get; set; }
        public double Score { get; set; }

        public Mark() { }

        public Mark(string studentId, string subjectId, double score)
        {
            StudentId = studentId;
            SubjectId = subjectId;
            Score = score;
        }

        public void DisplayMark()
        {
            Console.WriteLine($"Student ID: {StudentId} | Subject ID: {SubjectId} | Score: {Score}");
        }
    }
}
