using System;
using System.Collections.Generic;
using System.Linq;
namespace Popip.Core
{
    public class EntityValidatorResult<T> : IEntityValidatorResult<T>
    {
        public EntityValidatorResult()
        {
            Errors = Enumerable.Empty<string>();
        }
        public T Entity { get; set; }
        public bool IsValid { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
