using System;
using System.Collections.Generic;

namespace WebApiExample.Domain.Entities
{
    public class Task
    {
        public long TaskId { get; set; }
        public string Subject { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DateCompleted { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public byte[] Timestamp { get; set; }
        public DateTime CreatedDate { get; set; }
        private readonly IList<User> _users = new List<User>();
        public IList<User> Users => _users;
        private readonly IList<Category> _categories = new List<Category>();
        public IList<Category> Categories { get { return _categories; } }
    }
}
