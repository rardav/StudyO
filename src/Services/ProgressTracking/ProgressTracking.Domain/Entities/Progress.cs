﻿namespace ProgressTracking.Domain.Entities
{
    public class Progress
    {
        public Guid Id { get; set; }
        public string StudentEmail { get; set; }
        public Guid CourseId { get; set; } 
        public Guid LessonId { get; set; }
        public bool CourseFinished { get; set; }
    }
}
