using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities.TodoAggregates
{
    public class TodoUpdateRequest
    {
        public bool IsCompleted { get; set; }
    }
}
