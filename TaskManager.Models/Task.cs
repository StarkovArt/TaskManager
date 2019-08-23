namespace TaskManager.Models
{
    using System;

    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public string Description { get; set; }
    }
}
