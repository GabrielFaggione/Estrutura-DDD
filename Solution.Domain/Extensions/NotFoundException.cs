using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Extensions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Entity not found.") { }
    }

    public class NotFoundException<T> : Exception where T : BaseEntity
    {
        public NotFoundException(Guid id) : base($"Entity from type {typeof(T)} and Id {id} not found.") { }
    }

}
