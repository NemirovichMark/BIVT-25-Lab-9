using System;

namespace Lab9.Green
{
    public class Task3
    {
        public string StudentId { get; set; }
        public string SubjectId { get; set; }
        public double Score { get; set; }

        public Task3() { }

        public Task3(string studentId, string subjectId, double score)
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
