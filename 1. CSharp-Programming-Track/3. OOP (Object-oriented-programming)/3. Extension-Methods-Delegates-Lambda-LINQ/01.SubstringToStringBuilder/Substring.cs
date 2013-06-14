using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SubstringToStringBuilder
{
    public static class SubStringToStringBuilder
    {
        public static StringBuilder SubString(this StringBuilder subString, int index, int lenght)
        {
            StringBuilder newString = new StringBuilder();

            //check for corrext entered variables
            if (index < 0)
            {
                throw new FormatException("Index must be possitive number");
            }
            else if (lenght < 0)
            {
                throw new FormatException("Number of position must be possitive number");
            }
            else if (subString.Length < index)
            {
                throw new IndexOutOfRangeException("Index is bigger than lenght of string.");
            }
            else if (subString.Length < index + lenght)
            {
                throw new IndexOutOfRangeException("Index is bigger than lenght of string.");
            }
            else
            {
                for (int i = index; i < index + lenght; i++)
                {
                    newString.Append(subString[i]);
                }
            }

            return newString;
        }
    }
}
