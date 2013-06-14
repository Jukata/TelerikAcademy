// ##########################################################
// <copyright file="StringExtensions.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ##########################################################
namespace StringExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Contains useful extensions for <see cref="System.String"/> class
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Calculate hash code of input string with MD5 algorithm
        /// </summary>
        /// <param name="input">The string whose hash method calculate</param>
        /// <returns>MD5 of input string</returns>
        /// <example>
        /// This sample example shows how to use ToMd5Hash method
        /// <code>
        /// class TestMd5Hash
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "sample string";
        ///         System.Console.WriteLine(StringExtensions.ToMd5Hash(value));
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <seealso href="http://en.wikipedia.org/wiki/Md5"/>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Interpret input string as <see cref="System.Boolean"/> True or False value.
        /// </summary>
        /// <param name="input">The string to be interpreted as True or False.</param>
        /// <returns>
        /// True if input string can be interpreted as True.
        /// False if the string can't be interpreted as True
        /// </returns>
        /// <example>
        /// This sample example shows how to use ToBoolean method.
        /// <code>
        /// class TestToBooleanExtensions
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "yes";
        ///         System.Console.WriteLine(StringExtensions.ToBoolean(value));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Convert input string representation of number to its <see cref="System.Int16"/> equivalent.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns><see cref="System.Int16"/> Value of the string if it represent number 
        /// or zero if it isn't successful.
        /// </returns>
        /// <example>
        /// This sample example shows how to use ToShort method.
        /// <code>
        /// class TestToShortExtension
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "11057";
        ///         System.Console.WriteLine(StringExtensions.ToShort(value));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Convert input string representation of number to its <see cref="System.Int32"/> equivalent.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns><see cref="System.Int32"/> Value of the string if it represent number 
        /// or zero if it isn't successful.
        /// </returns>
        /// <example>
        /// This sample example shows how to use ToInteger method.
        /// <code>
        /// class TestToIntegerExtension
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "31121057";
        ///         System.Console.WriteLine(StringExtensions.ToInteger(value));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Convert input string representation of number to its <see cref="System.Int64"/> equivalent.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns><see cref="System.Int64"/> Value of the string if it represent number 
        /// or zero if it isn't successful.
        /// </returns>
        /// <example>
        /// This sample example shows how to use ToLong method.
        /// <code>
        /// class TestToLongExtension
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "5531121057";
        ///         System.Console.WriteLine(StringExtensions.ToLong(value));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Convert input string representation of a date and time to its <see cref="System.DateTime"/> equivalent.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns><see cref="System.DateTime"/> equivalent of input string if the conversion is successful 
        /// or 1.1.0001 00:00:00 if the conversion isn't successful. </returns>
        /// <example>
        /// This sample example shows how to use ToDateTime method.
        /// <code>
        /// class TestToDateTimeExtension
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "11.11.2011 16:33:12";
        ///         System.Console.WriteLine(StringExtensions.ToDateTime(value));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Return copy of the string with first letter converted to uppercase.
        /// </summary>
        /// <param name="input">The string to capitalize</param>
        /// <returns>The copy of the string with first letter converted to uppercase.
        /// Null if string is null or <see cref="System.String.Empty"/> if string is empty.</returns>
        /// <example>
        /// This sample example shows how to use CapitalizeFirstLetter method.
        /// <code>
        /// class TestCapitalizeFirstLetterExtension
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "example";
        ///         System.Console.WriteLine(StringExtensions.CapitalizeFirstLetter(value));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns a substring which is between <paramref name="startString"/> and <paramref name="endString"/>.
        /// The search starts from <paramref name="startFrom"/> index.
        /// </summary>
        /// <param name="input">Returns substring from this string.</param>
        /// <param name="startString">Indicate the leftmost left border of substring</param>
        /// <param name="endString">Indicate the leftmost right border of substring</param>
        /// <param name="startFrom">The zero-based starting character position.
        /// This parameter is optional and if not specified it's equal to zero.</param>
        /// <returns>
        /// Substring which is between <paramref name="startString"/> and <paramref name="endString"/>.
        /// The search starts from <paramref name="startFrom"/> index. 
        /// If input doesn't contains <paramref name="startString"/> or <paramref name="endString"/> returns <see cref="System.String.Empty"/>.
        /// </returns>
        /// <example>
        /// This sample example shows how to use GetStringBetween method.
        /// <code>
        /// class TestGetStringBetweenExtension
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "Sample string for testing string extensions.";
        ///         System.Console.WriteLine(StringExtensions.GetStringBetween(value,"str","test",3));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Convert all cyrillic letters in input text to their latin letters equivalents. 
        /// </summary>
        /// <param name="input">String to convert</param>
        /// <returns>
        /// Returns new string in which all occurrences of cyrillic letters are replaced with their latin letters equivalents.
        /// </returns>
        /// <example>
        /// This sample example shows how to use ConvertCyrillicToLatinLetters method.
        /// <code>
        /// class TestConvertCyrillicToLatinLettersExtension
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "Пример със sample string написан на шльокавица.";
        ///         System.Console.WriteLine(StringExtensions.ConvertCyrillicToLatinLetters(value));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Convert all latin letters in input text to their cyrillic letters equivalents. 
        /// </summary>
        /// <param name="input">String to convert</param>
        /// <returns>
        /// Returns new string in which all occurrences of latin letters are replaced with their cyrillic letters equivalents.
        /// </returns>
        /// <example>
        /// This sample example shows how to use ConvertLatinToCyrillicKeyboard method.
        /// <code>
        /// class TestConvertLatinToCyrillicKeyboardExtension
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "This is example with sample string написан на shljokavica.";
        ///         System.Console.WriteLine(StringExtensions.ConvertLatinToCyrillicKeyboard(value));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Convert input username to valid by replacing all cyrillic letters to their latin equivalents and 
        /// removing all non-alphanumeric characters (exclude dot '.' and underscore '_').
        /// </summary>
        /// <param name="input">Input string for convert to valid username.</param>
        /// <returns>
        /// Copy of input string in which all cyrillic letters are replaced by their latin equivalents and
        /// all non-alphanumeric characters (exclude dot '.' and underscore '_') are removed.
        /// </returns>
        /// <example>
        /// This sample example shows how to use ToValidUsername method.
        /// <code>
        /// class TestToValidUsernameExtension
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "книght_!1999--!@";
        ///         System.Console.WriteLine(StringExtensions.ToValidUsername(value));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Convert input filename to valid by replacing all cyrillic letters to their latin equivalents,
        /// removing all non-alphanumeric characters (exclude dot '.' and underscore '_') and
        /// replacing all spaces with hyphens '-'.
        /// </summary>
        /// <param name="input">Input string for convert to valid filename.</param>
        /// <returns>
        /// Copy of input string in which all cyrillic letters are replaced by their latin equivalents and
        /// all non-alphanumeric characters (exclude dot '.' and underscore '_') are removed and
        /// all spaces are replaced with hyphens '-'.
        /// </returns>
        /// <example>
        /// This sample example shows how to use ToValidLatinFileName method.
        /// <code>
        /// class TestToValidLatinFileNameExtension
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "NewМицрософт text доцумент.доц";
        ///         System.Console.WriteLine(StringExtensions.ToValidLatinFileName(value));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns first <paramref name="charsCount"/> characters in input string.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="charsCount">The number of characters in substring</param>
        /// <returns>First <paramref name="charsCount"/> characters in input string or 
        /// input string's length if its length is lesser than <paramref name="charsCount"/>
        /// </returns>
        /// <example>
        /// This sample example shows how to use GetFirstCharacters method.
        /// <code>
        /// class TestGetFirstCharactersExtension
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "Test string.";
        ///         System.Console.WriteLine(StringExtensions.GetFirstCharacters(value,4));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns file extension of given <paramref name="fileName"/>.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>
        /// File extension of the given filename. If fileName is empty or
        /// there isn't extensions returns <see cref="System.String.Empty"/>.
        /// </returns>
        /// <example>
        /// This sample example shows how to use GetFileExtension method.
        /// <code>
        /// class TestGetFileExtensionExtension
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "New Microsoft Text Document.rtf";
        ///         System.Console.WriteLine(StringExtensions.GetFileExtension(value));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the corresponding content type for the specified <paramref name="fileExtension"/>.
        /// </summary>
        /// <param name="fileExtension">File extension (excluding dot '.').</param>
        /// <returns>
        /// Corresponding content type of input <paramref name="fileExtension"/>. 
        /// If there isn't such file extension returns "application/octet-stream".
        /// </returns>
        /// <example>
        /// This sample example shows how to use ToContentType method.
        /// <code>
        /// class TestToContentTypeExtension
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "doc";
        ///         System.Console.WriteLine(StringExtensions.ToContentType(value));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts <paramref name="input"/> string to sequence of bytes. 
        /// </summary>
        /// <param name="input">String to convert.</param>
        /// <returns>
        /// A byte array that is copy of <paramref name="input"/> string. 
        /// </returns>
        /// <example>
        /// This sample example shows how to use ToByteArray method.
        /// <code>
        /// class TestToByteArrayExtension
        /// {
        ///     static void Main()
        ///     {
        ///         string value = "Svetlin Nakov";
        ///         System.Console.WriteLine(StringExtensions.ToByteArray(value));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
