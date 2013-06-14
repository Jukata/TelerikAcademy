// ##########################################################
// <copyright file="TestStringExtensions.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ##########################################################
namespace StringExtensions
{
    using System;

    /// <summary>
    /// Class for manual testing <see cref="StringExtensions"/>
    /// </summary>
    public class TestStringExtensions
    {
        /// <summary>
        /// Entry point of the application. 
        /// </summary>
        public static void Main()
        {
            string value = "sample string";
            string hashedString = StringExtensions.ToMd5Hash(value);
            Console.WriteLine("MD5 hash -> " + hashedString);

            string boolForCheck = "yes";
            Console.WriteLine("Boolean convert -> " + StringExtensions.ToBoolean(boolForCheck));

            string shortRepresentationString = "11122";
            Console.WriteLine("Short convert ->" + StringExtensions.ToShort(shortRepresentationString));

            string inttRepresentationString = "13111228";
            Console.WriteLine("Integer convert -> " + StringExtensions.ToInteger(inttRepresentationString));

            string dateTimeToConvert = "333.2112.122";
            Console.WriteLine("DateTime convert -> " + StringExtensions.ToDateTime(dateTimeToConvert));
            dateTimeToConvert = "11.11.1111";
            Console.WriteLine("DateTime convert -> " + StringExtensions.ToDateTime(dateTimeToConvert));

            string stringToCapitalize = "example";
            Console.WriteLine("Capitalize first letter -> " + StringExtensions.CapitalizeFirstLetter(stringToCapitalize));

            string stringToSbustr = "Sa Sample Sa string to AA to test extensionest.";
            Console.WriteLine("Getting string between -> " + StringExtensions.GetStringBetween(stringToSbustr, "Sa", "to", 1));

            string cyrillicToLatinStr = "Пример със sample string написан на шльокавица.";
            Console.WriteLine("Convert to latin -> " + StringExtensions.ConvertCyrillicToLatinLetters(cyrillicToLatinStr));

            string latinToCyrillicStr = "Tova e primer sys sample string napisan на shljokavica.";
            Console.WriteLine("Convert to cyrillic -> " + StringExtensions.ConvertLatinToCyrillicKeyboard(latinToCyrillicStr));

            string usernameForValidate = "кнight_!@1999-";
            Console.WriteLine("Valid username -> " + StringExtensions.ToValidUsername(usernameForValidate));

            string fileNameForValidate = "NewМицрософт text доцумент.доц";
            Console.WriteLine("Valid latin filename -> " + StringExtensions.ToValidLatinFileName(fileNameForValidate));

            string stringForGettingFirstCharacters = "Test string.";
            Console.WriteLine("Get first characters -> " + StringExtensions.GetFirstCharacters(stringForGettingFirstCharacters, 4));

            string fileName = "New Microsoft Text Document.rtf";
            Console.WriteLine("File extension -> " + StringExtensions.GetFileExtension(fileName));

            string fileExtension = "doc";
            Console.WriteLine("File extension -> " + StringExtensions.ToContentType(fileExtension));

            string strToConvert = "Svetlin Nakov";
            byte[] byteArray = StringExtensions.ToByteArray(strToConvert);
            Console.WriteLine("To byte array:");
            foreach (byte b in byteArray)
            {
                Console.Write(b + " ");
            }

            Console.WriteLine();
        }
    }
}
