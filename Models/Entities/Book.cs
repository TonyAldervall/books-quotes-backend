﻿namespace WebAPI.Models.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string PublishDate { get; set; }

    }
}
