using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidRangeException
{
    //Define a class InvalidRangeException<T> that holds information about an error condition
    //related to invalid range. It should hold error message and a range definition [start … end].

    public class InvalidRangeException<T> : ApplicationException
        where T : IComparable<T>
    {

        public T Start { get; set; }

        public T End { get; set;}

        public InvalidRangeException(string msg, T start, T end, Exception innerEx)
            : base(msg, innerEx)
        {
            this.Start = start;
            this.End = end;
        }

        public InvalidRangeException(string msg, T start, T end)
            : base(msg)
        {
            this.Start = start;
            this.End = end;
        }

        public override string Message
        {
            get
            {
                string result = string.Format("{0}! Input out of range [{1}...{2}]", base.Message, this.Start, this.End);
                return result;
            }
        }
    }
}
