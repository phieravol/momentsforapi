using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentsFor.Domain.Abstractions
{
    public abstract class DomainException: Exception
    {
        public string Title { get; }

        protected DomainException(string title, string message): base(message)
        {
            Title = title;
        }
    }
}
