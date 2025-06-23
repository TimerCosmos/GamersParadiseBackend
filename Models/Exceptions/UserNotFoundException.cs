using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string? Email { get; set; }
        public UserNotFoundException(string email) : base($"User with the email {email} was not found.")
        {
            Email = email;
        }
        public UserNotFoundException(string message, string? email = null) : base(message)
        {
            Email = email;
        }
        public UserNotFoundException(string message, Exception innerException, string? email = null) : base(message, innerException)
        {
            Email = email;
        }
    }
}
