using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Data
{
    public class UtilityFunctions
    {
        public static bool IsEmailValid(string email)
        {
            if(string.IsNullOrEmpty(email)) return false;
            var indexOfAt = email.IndexOf('@');
            var indexOfDot = email.IndexOf('.');

            return indexOfAt > 0 && indexOfAt + 1 < indexOfDot && indexOfDot < email.Length - 1;
        }
    }
}
