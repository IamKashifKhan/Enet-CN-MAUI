using System.Text.RegularExpressions;
using EnetCNMAUI.Enums;

namespace EnetCNMAUI.Helpers
{

    public static class StringExtensions
    {
        public static UsernameInputType GetInputType(this string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return UsernameInputType.Invalid;
            }

            if (IsEmail(username))
            {
                return UsernameInputType.Email;
            }
            else if (IsPhoneNumber(username))
            {
                return UsernameInputType.PhoneNumber;
            }
            else
            {
                return UsernameInputType.Invalid;
            }
        }

        private static bool IsEmail(string input)
        {
            var emailPattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            return Regex.IsMatch(input, emailPattern);
        }

        private static bool IsPhoneNumber(string input)
        {
            var phonePattern = @"^(\+1\s?)?(\()?(\d{3})(?(2)\))[\s.-]?(\d{3})[\s.-]?(\d{4})$";
            return Regex.IsMatch(input, phonePattern);
        }
        public static string FirstLetterUpperCase(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return $"{char.ToUpper(value[0])}{value.Substring(1)}";
        }
    }

}

