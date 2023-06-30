﻿namespace Aggregator.Models
{
    public record ReviewModel
    {
        public Guid Id { get; set; }
        public string AuthorEmail { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CourseId { get; set; }
        public int Rating { get; set; }
    }
}