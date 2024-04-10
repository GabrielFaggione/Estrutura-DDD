using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities.TodoAggregates
{
    public class Todo : BaseEntity
    {
        public Todo(string description)
        {
            Description = description;
            CreatedAt = DateTime.Now;
        }

        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsCompleted { get; set; }

    }
}
