using System;
using System.Collections.Generic;

namespace Popip.Core
{
    public interface IEntityValidatorResult<T>
    {
        public T Entity { get; set; }
        public bool IsValid { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
