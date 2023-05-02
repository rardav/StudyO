﻿namespace Aggregator.Models
{
    public record CourseModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;


    }
}
