﻿namespace ConcertMAUI.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Concert> Concerts { get; set; }
    }
}
