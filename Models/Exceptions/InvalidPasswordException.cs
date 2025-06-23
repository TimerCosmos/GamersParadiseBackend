using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string email)
            : base($"Invalid password for user with email: {email}")
        {
        }
        public InvalidPasswordException(string email, Exception innerException)
            : base($"Invalid password for user with email: {email}", innerException)
        {
        }
    }
}
