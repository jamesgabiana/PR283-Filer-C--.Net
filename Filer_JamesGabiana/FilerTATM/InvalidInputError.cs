using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerTATM
{

    public class InvalidInputError: Exception
    {
        public InvalidInputError()
        {
        }

        public InvalidInputError(string message)
            : base(message)
        {
        }

        public InvalidInputError(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
