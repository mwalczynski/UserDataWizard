using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserDataWizard
{
    public static class ValidationMethods
    {
        public static bool ContainsNumber(string property)
        {
            var regex = new Regex(@"[0-9]");
            return regex.IsMatch(property);
        }

        public static bool ContainsLetter(string property)
        {
            var regex = new Regex(@"[A-Za-z]");
            return regex.IsMatch(property);
        }

        public static bool ContainsSpecialCharacters(string property)
        {
            var regex = new Regex("[^A-Za-z0-9ĄĆĘŁŃÓŚŹŻąćęłńóśźż]");
            return regex.IsMatch(property);
        }

        public static bool IsNumber(string property)
        {
            var regex = new Regex(@"^[0-9]+$");
            return regex.IsMatch(property);
        }

        public static bool StartWithCapitalLetters(string property)
        {
            var regex = new Regex(@"^([A-ZĄĆĘŁŃÓŚŹ])");
            return regex.IsMatch(property);
        }
    }
}
